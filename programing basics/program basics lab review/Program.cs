//*********************************************************************
//Program:    Lab 1 – array of marcks
//Author:     Chris Forest
//Class:      CNT2f
//Instructor: Kevin More
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;
using Utilities;
using System.IO;

namespace CF_LAB1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = new int[1];     //Array of Grades
            ConsoleKeyInfo selection;        //tracks what the user inputs from the menu selection
            int selction;                    //user input for selecting a menu option

            //Set Array to default state
            numArray[0] = -1;

            //Display title
            Console.WriteLine("Lab 1 - Array of Marks");
            Console.WriteLine();

           

            //Continue till user want to exit
            do
            {
                Console.Clear();

                //Display Menu
                menu();

                //input for user selection
                Console.Write("\n\nYour selection: ");
                selection = Console.ReadKey();
                int.TryParse(Console.ReadLine(), out selction);

                //load data from a file
                if (selection.Key == ConsoleKey.NumPad4)
                {
                    LoadFile(ref numArray);
                }

                //save data to a file
                if (selection.Key == ConsoleKey.NumPad5)
                {
                    SaveFile(numArray);
                }

                // generate the random grades when 1 is pressed
                if (selection.Key == ConsoleKey.NumPad1)
                {
                    // user input for array size
                    GetArray(out numArray);
                    Console.WriteLine("\ncurrents contents of array: \n");
                    DisplayArray(numArray);
                }

                //average and display grades when 2 is pressed
                if (selection.Key == ConsoleKey.NumPad2)
                {
                    try
                    {
                        // avg of grades made
                        if (numArray.Length > 0)
                            Stats(numArray);
                    }
                    catch
                    {
                        Console.WriteLine("\n\nData needs to be generated first");
                        Console.Beep(100, 25000);
                    }
                }

                //display menu when m is pressed
                if (selection.Key == ConsoleKey.M)
                {
                    //Displey menu
                    menu();
                }

                // if 3 is pressed the histogram will get drawn
                if (selection.Key == ConsoleKey.NumPad3)
                {
                    DrawHistogram(numArray);
                }
            }
            while (selection.Key != ConsoleKey.Q);
        }

        //********************************************************************************************
        //Method:     static private void menu()
        //Purpose:    display the meu
        //Parameters: none
        //Returns:    void- returns no value
        //*********************************************************************************************
        static private void menu()
        {
            Console.WriteLine("\nSelect a menu option..");
            Console.WriteLine();
            Console.WriteLine("1. Generate random array.");
            Console.WriteLine("2. Display Array stats.");
            Console.WriteLine("3. Display histogram.");
            Console.WriteLine("4. load file.");
            Console.WriteLine("5. save file.");
            Console.WriteLine("m. Display menu.");
            Console.WriteLine("q. Quit the program.");
        }

        //*********************************************************************
        //Method:       private static void Draw(int[] aGrades)
        //Purpose:      Draw The amount of Grades in ranges of 10 up to 100 as bars
        //Parameters:   int[] aGrades - Arrays of Grades
        //Returns:      Nothing
        //*********************************************************************
        private static void DrawHistogram(int[] aGrades)
        {
            int[] numRange = new int[11];          //Store amount of numbers in a each range
            int index;                             //Index of an array
            CDrawer Draw = new CDrawer();          //Window to Draw the histogram
            Color[] cGrade = new Color[11];        //Color of the bar of the histrogram        
            Color cStore;                          //Temporay store colors
            Random rColor = new Random();          //Rng use to generate colors
            string[] stringRange = new string[11]; //Ranges in string form to use as labels
            double height;                         //Height of an bar
            double width;                          //Width of an bar

            //Count amount of numbers in each Range
            for (index = 0; index < aGrades.Length; index++)
            {
                //Check to see if the number is below or above 50
                if (aGrades[index] < 50)
                {
                    //Check to see what range the number is in
                    if ((0 <= aGrades[index]) && (aGrades[index] <= 9))
                    {
                        //Increase the amount in the range 0-9 by 1
                        numRange[0]++;
                    }
                    else if (aGrades[index] <= 19)
                    {
                        //Increase the amount in the range of 10-19 by 1
                        numRange[1]++;
                    }
                    else if (aGrades[index] <= 29)
                    {
                        //Increase the amount in the range 20-29 by 1
                        numRange[2]++;
                    }
                    else if (aGrades[index] <= 39)
                    {
                        //Increase the amount in the range 30-39 by 1
                        numRange[3]++;
                    }
                    else
                    {
                        //Increase the amount in the range 30-39 by 1
                        numRange[4]++;
                    }
                }
                else
                {
                    //Check to see what range the number is in
                    if ((50 <= aGrades[index]) && (aGrades[index] <= 59))
                    {
                        //Increase the amount in the range 50-59 by 1
                        numRange[5]++;
                    }
                    else if (aGrades[index] <= 69)
                    {
                        //Increase the amount in the range 60-69 by 1
                        numRange[6]++;
                    }
                    else if (aGrades[index] <= 79)
                    {
                        //Increase the amount in the range 70-79 by 1
                        numRange[7]++;
                    }
                    else if (aGrades[index] <= 89)
                    {
                        //Increase the amount in the range 80-89 by 1
                        numRange[8]++;
                    }
                    else if (aGrades[index] <= 99)
                    {
                        //Increase the amount in the range 80-89 by 1
                        numRange[9]++;
                    }
                    else
                    {
                        //Increase the amouint that eqaul 100 by 1
                        numRange[10]++;
                    }
                }
            }

            //Add colors and strings to the Arrays
            for (index = 0; index < cGrade.Length; index++)
            {
                //Gerate random colors and make sure they are not already in the array
                do
                {
                    cStore = Color.FromArgb(rColor.Next(0, 255), rColor.Next(0, 255), rColor.Next(0, 255));
                }
                while (cGrade.Contains(cStore));

                //Add the color to the Array
                cGrade[index] = cStore;

                //Add the strings to the Array depending on the Index
                if (index == 0)
                {
                    //If it the first Index store 0 to 9 in the Array
                    stringRange[index] = $"0 to 9";
                }
                else if (index == cGrade.Length - 1)
                {
                    //If it the Last index store the index number follow by a zero in the Array
                    stringRange[index] = $"{index}0";
                }
                else
                {
                    //Any other Index store {index}0 to {index}9 to the Array. 
                    stringRange[index] = $"{index}0 to {index}9";
                }
            }

            //Draw the Histogram
            for (index = 0; index < numRange.Length; index++)
            {
                //Calculate the width of an bar
                width = 800 / numRange.Length;

                //Draw the bar of the Histogram
                if (numRange[index] != 0)
                {
                    //Calculate the Length of an bar
                    height = numRange[index];
                    height /= numRange.Max();
                    height *= 580;

                    //Draw the bars and the amount in the Bars
                    Draw.AddRectangle((Convert.ToInt32(width * index)), 580 - Convert.ToInt32(height), Convert.ToInt32(width), Convert.ToInt32(height), cGrade[index], 0);
                    Draw.AddText($"{numRange[index]}", 20, Convert.ToInt32(width * index), Convert.ToInt32((height / 2) + 564 - Convert.ToInt32(height)), Convert.ToInt32(width), 32, Color.Black);
                }

                //draw the labels of the Historgram
                Draw.AddText($"{stringRange[index]}", 12, Convert.ToInt32(width * index), 580, Convert.ToInt32(width), 20, Color.White);
            }
        }

        //*********************************************************************
        //Method:       private static void GetArray(out int[] aGrades)
        //Purpose:      Generate an array of grades
        //Parameters:   out int[] aGrades - Array of Grades
        //Returns:      Nothing
        //*********************************************************************
        private static void GetArray(out int[] aGrades)
        {
            int arraySize;             //Size of the Array
            int Index;                  //Index of the Array
            Random RNG = new Random();  //Random Number Generator

            //Get the Array Size from the user
            CUtilities.GetValue(out arraySize, "Enter the size of the array: ", 0, 10001);

            //Create the Array
            aGrades = new int[arraySize];

            //Fill the Array with random number
            for (Index = 0; Index < arraySize; Index++)
            {
                aGrades[Index] = RNG.Next(0, 101);
            }

        }

        //********************************************************************************************
        //Method:     static private void Average(double[]aGrades)
        //Purpose:    display various stats in the array
        //Parameters: double[]aGrades- student grades
        //Returns:    void- returns no value
        //*********************************************************************************************
        static private void Stats(int[] aGrades)
        {
            int count;          // adds array numbers 
            double average = 0; // avg of array

            // loop to count the array
            for (count = 0; count < aGrades.Length; count++)
            {
                // adds the array up to be averaged 
                average += aGrades[count];
            }
            average /= aGrades.Length;

            Console.WriteLine($"\n\nThe smallest value is { aGrades.Min():F0}");
            Console.WriteLine($"\nThe average of all marks is {average:0.0}%");
            Console.WriteLine($"\nThe smallest value is { aGrades.Max():F0}");
        }

        //*********************************************************************
        //Method:       DisplayArray(int[] aGradesDisplay)
        //Purpose:      Display an Array of grades
        //Parameters:   int[] aGradesDisplay - an array of grades
        //Returns:      Nothing
        //*********************************************************************
        private static void DisplayArray(int[] aGrades)
        {
            int Index;          //Index of the Array
            int Row = 20;  //Index number to move to next line          

            Console.WriteLine();

            //Display the Array
            for (Index = 0; Index < aGrades.Length; Index++)
            {
                //Check o see if the array is at the end of the line
                if (Index == Row)
                {
                    //Move to the next line
                    Console.WriteLine();
                    Console.WriteLine();
                    Row += 20;
                }

                //Write the Grade
                Console.Write($"{aGrades[Index],-4}");
            }

            Console.WriteLine();
        }

        //*********************************************************************
        //Method:       private static void SaveFile(int[] aGradesSave)
        //Purpose:      Save a Array of Grade to a file chossen by the user
        //Parameters:   int[] aGradesSave - Array of Grades
        //Returns:      Nothing
        //*********************************************************************
        private static void SaveFile(int[] aGrades)
        {
            int index;         //Index of the Array
            StreamWriter save; //File to save to
            string text;       //Name of the file

            try
            {
                //Get name of the file from user
                Console.Write("Enter savefile name: ");
                text = Console.ReadLine();
                save = new StreamWriter($"{@text}.txt");


                //Save to the file
                for (index = 0; index < aGrades.Length; index++)
                {
                    save.WriteLine($"{aGrades[index]}");
                }
                save.Close();

                Console.WriteLine($"{aGrades.Length} values save to the to the file{text}");
            }
            catch (Exception eSave)
            {
                //Display Erro Message
                Console.WriteLine($"Error saving file: {eSave.Message}");
                Console.Beep(200, 25000);
            }
        }

        //*********************************************************************
        //Method:       private static void LoadFile(ref int[] aGradesLoad)
        //Purpose:      Load an Array of Grades from a file
        //Parameters:   ref int[] aGradesLoad - Array of grades
        //Returns:      Nothing
        //*********************************************************************
        private static void LoadFile(ref int[] aGrades)
        {
            StreamReader load;   //File to load Array from
            int count = 0;         //Lines of the file and array
            string text;       //Name of the file to load
            bool bError;            //Error Flag when file doesn't load

            //Continue till no Errors loading file or user want to return
            do
            {
                //Set Error flag to false
                bError = false;

                //Get user to enter the name of the file
                Console.Write("\nEnter file Name to load: ");
                text = Console.ReadLine();

                //Check for Errors opening the file
                try
                {
                    load = new StreamReader($"{@text}.txt");
                    try
                    {
                        //Get the Size of the Array
                        while (load.ReadLine() != null)
                        {
                            //Increase the Array size
                            count++;
                        }

                        //Close and reopen the file at the start
                        load.Close();
                        load = new StreamReader($"{@text}.txt");
                        aGrades = new int[count];

                        //Get each line of a grade into an Array
                        for (count = 0; count < aGrades.Length; count++)
                        {
                            //Check to see if the file only contain numbers
                            if (int.TryParse(load.ReadLine(), out aGrades[count]) == false)
                            {
                                //Display Error Message
                                Console.WriteLine("Please choose a file with only intergers");
                                Console.Beep(200, 25000);

                                //Set Error Flag
                                bError = true;
                            }

                            if ((aGrades[count] < 0) || (aGrades[count] > 100))
                            {
                                //Display Error Message
                                Console.WriteLine("Please choose a file with intergers in the Range of 0<=n<=100");
                                Console.Beep(200, 25000);

                                //Set Error Flag
                                bError = true;
                            }
                        }
                    }
                    catch (Exception eLoad)
                    {
                        //Display Error Message
                        Console.WriteLine($"Error opening file: {eLoad.Message}");
                        Console.Beep(200, 25000);

                        //Set Error flag
                        bError = true;
                    }
                }
                catch (Exception eLoad)
                {
                    //Display Error Message
                    Console.WriteLine($"Error opening file: {eLoad.Message}");
                    Console.Beep(200, 25000);

                    //Set Error flag
                    bError = true;
                }

                //Check to see it the file load
                if (bError != true)
                {
                    //If not display the amount of grades loades
                    Console.WriteLine($"\n{aGrades.Length} values loaded from file {text}");

                    //Also display the current contains of the Array
                    DisplayArray(aGrades);
                }
                else
                {
                    Console.Write("Press <R> to return to the menu, or any other key to load a differnet file: ");

                    if (Console.ReadLine().ToLower() == "r")
                    {
                        //Set Error flag to false
                        bError = false;
                    }
                }
            }
            while (bError != false);
        }
    }
}
