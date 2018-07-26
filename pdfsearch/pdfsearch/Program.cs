using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace pdfsearch
{
    class Program
    { 
        static void Main(string[] args)
        {
            // variable for user input
            string userInput;
            // variable for page number
            string page = "";
            int intpage = 0;
            // empty regular expression
            string pattern = "";
            // empty string variable to fo pdf path
            string pdfpath = "";
            // empty list for data to be inputed into
            var outPut = new List<string>();
            // empty string for results to be printed in
            string result = "";
            // bool variables to exiting loops during execution
            bool exit = false;
            bool mainexit = false;
            bool pageselect = false;

           
            Console.WriteLine("This program will open a pdf determined by the user. The user will have to determine");
            Console.WriteLine("the page number of the pdf.  Then type out the tabulated label from the table. To exit");
            Console.WriteLine("the program at any time just type in exit when prompt for input.");
            Console.WriteLine();
            // main program while loop to find and selects pdf file by year 
            while (mainexit != true)
            {
                Console.WriteLine("Please enter year of LCRAS pdf you would like to open");
                Console.WriteLine("or number indicating the pdf you would like opened");  
                string year = Console.ReadLine();
                Console.WriteLine();
                if(year == "exit") 
                {
                    mainexit = true; 
                    break;
                }
                int con_year = Convert.ToInt32(year); // convert year into integer
                switch (con_year)
                {
                    case 1995:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\Appendix95.pdf";
                            pageselect = false;
                            break;
                        }
                    case 1996:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\Appendix96.pdf";
                            pageselect = false;
                            break;
                        }
                    case 1997:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\Appendix97.pdf";
                            pageselect = false;
                            break;
                        }
                    case 1998:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\appendix98.pdf";
                            pageselect = false;
                            break;
                        }
                    case 1999:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\Appendix99.pdf";
                            pageselect = false;
                            break;
                        }
                    case 2000:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\2000AppendixPart1.pdf";
                            pageselect = false;
                            break;
                        }
                    case 2001:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\01AppendixPart1.pdf";
                            pageselect = false;
                            break;
                        }
                    case 2002:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\02AppendixPart1.pdf";
                            pageselect = false;
                            break;
                        }
                    case 2003:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\2003LCRAS.pdf";
                            break;
                        }
                    case 2004:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\2004LCRAS.pdf";
                            pageselect = false;
                            break;
                        }
                    case 2005:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\2005LCRAS.pdf";
                            pageselect = false;
                            break;
                        }
                    case 2006:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\2006LCRAS.pdf";
                            pageselect = false;
                            break;
                        }
                    case 2007:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\2007LCRAS.pdf";
                            pageselect = false;
                            break;
                        }
                    case 2008:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\2008LCRAS.pdf";
                            pageselect = false;
                            break;
                        }
                    case 2009:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\report09.pdf";
                            pageselect = false;
                            break;
                        }
                    case 2010:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\report10.pdf";
                            pageselect = false;
                            break;
                        }
                    case 2011:
                        {
                            pdfpath = "C:\\Users\\mmiranda\\Downloads\\report11.pdf";
                            pageselect = false;
                            break;
                        }
                        /*
                         * To add to switch statement for a new pdf
                         * case [number]
                         * {
                         *      pdfpath = @"path name for pdf goes here";
                         *      pageselect = false;  // will indicate going to next loop
                         *      break; // breaks out of the loop
                         * }
                         */
              

                } // switch statement to select pdf path 

                // inner while loop for selecting page number 
                while (pageselect != true)
                {
                    Console.WriteLine("Please enter the page number for data collection");
                    Console.WriteLine("Type back if you want to select a different pdf");
                    page = Console.ReadLine();
                    Console.WriteLine();
                    if (page == "back")
                    {
                        pageselect = true;
                        break;
                    }
                    else if (page == "exit")
                    {
                        mainexit = true;
                        break;
                    }
                    intpage = Convert.ToInt32(page);
                    var pdf = pdfText(pdfpath, intpage);
                    exit = false;
                    // inner while loop that reads in input from user to collect data 
                    while (exit != true)
                    {
                        Console.WriteLine("Please enter label of data you would like to collect?");
                        Console.WriteLine("If you would like to reselect a page just type back"); 
                        userInput = Console.ReadLine();
                        Console.WriteLine();
                        if (userInput == "back")
                        {
                            exit = true;
                            break;
                        }
                        else if (userInput == "exit")
                        {
                            mainexit = true;
                            pageselect = true;
                            break;
                        }
                        Console.WriteLine();
                       
                        // label for data 
                        result = result + userInput;
                        // method call to add table values to string regular expression
                        pattern = newpattern(userInput);
                        // library method call to match something in the text file that was converted from pdf
                        MatchCollection matches = Regex.Matches(pdf, pattern);
                        if (matches.Count < 1)
                        {
                            Console.WriteLine("File not readable");
                            result = ""; // resets result variable to empty 

                        }
                        else
                        {
                            result = result + matches[0].Value.Replace(userInput, "").Trim(); //rremoves the matched pattern from the string 

                        }
                        outPut.Add(result); // add string to output list
                        result = ""; // clears result variable
                        foreach (String s in outPut) // prints on to console screen the results 
                        {
                            Console.WriteLine(s);
                        }
                       
                           
                        
                    }

                }

            }

            // when program terminates it is to write into empty txt file 
            var outFile = System.IO.Path.GetTempFileName() + ".txt"; // opens and creates a temp .txt file to be printed into
            TextWriter tw = new StreamWriter(outFile); 

            foreach (String s in outPut) // for loop used to write into the temp .txt file 
            {
                tw.WriteLine(s);
            }
            tw.Close();
            // open file 
            System.Diagnostics.Process.Start(outFile);
            
            Console.ReadKey();

        }

                        
        // method to create string for matching using regular expression 
        public static string newpattern(string pattern)
        {
            string tabvalue = @"((\-?\d+)+?(\.\d+)?)\s"; // this is the regular expression for positive and negative integer or positive negative decimal value
            string new_pattern = @""; // empty string of regular expression
            // combines into a new string uses label userinput and 13 combinations of the regular expression for tabulated data
            new_pattern = pattern + tabvalue + tabvalue + tabvalue + tabvalue + tabvalue + tabvalue + tabvalue + tabvalue + tabvalue + tabvalue + tabvalue + tabvalue + tabvalue;
            return new_pattern;
        }
        public static string pdfText(string path, int page)
        {
            PdfReader reader = new PdfReader(path); // that for pdf
            string text = string.Empty; // empty string for pdf  
                                        //reads a certain page and puts into a string 
            text += PdfTextExtractor.GetTextFromPage(reader, page);

            reader.Close(); //closes file
            return text; //return string 
        }
    }
}
