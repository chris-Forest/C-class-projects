//********************************************************
//Program:     Methods Assignment 8
//Description: create a running total for time on a cd
//Date:        nov. 12/2019
//Author:      Chris Forest
//Course:      CMPE1300
//Class:       CNTA03
//********************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ICA08
{
    class Program
    {
        static void Main(string[] args)
        {
            int iMinInput;      //track minutes input by user
            int iSecInput;      //track seconds input by user
            int iMinTotal = 0;  //total music minutes
            int iSecTotal = 0;  //total music seconds
            bool bExit = false; //flag for CD is full

            // repeat until user has a full CD
            do
            {
                //get time for a single track
                GetTrack(out iMinInput, out iSecInput);

                //add track to current music total time
                AddTrack(iMinInput, iSecInput, ref iMinTotal, ref iSecTotal);

                //display total time on CD
                DisplayTotal(iMinTotal, iSecTotal);

                //check for CD beong full at 76 minutes
                if(SecTotal(iMinTotal,iSecTotal)>76*60)
                {
                    Console.WriteLine("The CD is full, exiting...");
                    bExit = true;
                }
            }while((YesNo("\nAdd another track?")=="yes")&&!bExit);

        }

        //********************************************************
        //Method:     static private string YesNo(string sentance)
        //Purpose:    prompt user for yes or no, error if not
        //Parameters: string sentance- display prompt set in argument 
        //Returns:   yesNo- from user input
        //********************************************************
        static private string YesNo(string sentance)
        {
            string yesNo; // holds user input for yes/no

            do
            {
                // display prompt
                Console.Write(sentance);

                // ask for user input
                yesNo = Console.ReadLine();

                // error message if yes or no is not entered
                if (yesNo != "yes" && yesNo != "no")
                {
                    Console.WriteLine("\nYou must answer yes or no.");
                }

                // if no says bye message then closes
                if(yesNo=="no")
                {
                    Console.WriteLine("Bye!");
                    Thread.Sleep(1000);
                }

            } while (yesNo != "yes" && yesNo != "no");
            // loop until proper answer is given
            return yesNo;
        }

        //********************************************************
        //Method:     static private void GetTrack(out int MinInput, out int SecInput)
        //Purpose:    display prompt for minutes an dseconds
        //Parameters: out int MinInput- user input for minutes
        //            out int SecInput- user input for seconds
        //Returns:    values returned with refrences
        //********************************************************
        static private void GetTrack(out int MinInput, out int SecInput)
        {
            // user input for minutes with set man and max
            MinInput = GetInt("Enter a number of minutes: ",0,59);

            // user input for seconds with set man and max
            SecInput = GetInt("Enter a number of seconds: ", 0, 59);
        }

        //********************************************************
        //Method:     static private void DisplayTotal(int minutes,int seconds)
        //Purpose:    display current total time in minutes and seconds
        //Parameters: int minutes- displays current total of minutes on cd
        //            int seconds- displays current total of seconds on cd
        //Returns:    nothing because method is void
        //********************************************************
        static private void DisplayTotal(int minutes,int seconds)
        {
            // displays current total on CD in minutes and seconds
            Console.WriteLine("The curent total is: {0:00}:{1:00}", minutes, seconds);
        }

        //********************************************************
        //Method:     static private int SecTotal(int minutesTotal,int secondsTotal)
        //Purpose:    passes the total minutes and seconds and converts it to seconds
        //Parameters: int minutes total- total minutes 
        //            int seconds total- total seconds
        //Returns:    total in seconds value
        //********************************************************
        static private int SecTotal(int minutesTotal,int secondsTotal)
        {
            // returns total seconds paseed to it
            return (minutesTotal * 60) + secondsTotal;
        }

        //********************************************************
        //Method:     static private void AddTrack(int minutes,int seconds,ref int minTotal,ref int secTotal)
        //Purpose:    for ever 60 seconds convert to 1 minute
        //Parameters: int minutes- value of the last minute input entered
        //            int seconds- value of the last seconds input entered 
        //            int minTotal- total minutes on cd
        //            int secTotal- total seconds on cd
        //Returns:    values returned with refrences
        //********************************************************
        static private void AddTrack(int minutes,int seconds,ref int minTotal,ref int secTotal)
        {
            // add to cd length total
            minTotal += minutes;
            secTotal += seconds;

            // for evey 60 seconds convert to 1 minute
            if(secTotal>=60)
            {
                secTotal -= 60;
                minTotal += 1;
            }
        }

        //********************************************************
        //Method:    static private int GetInt(string word, int min, int max)
        //Purpose:   inputs an int value with range checking
        //Parameters:string word- prompt to ask user for an int valsu   
        //           int min- minimun range for int that can be accepted
        //           int max- max range for int that can be accepted
        //Returns:   int- value accepted by the method
        //********************************************************
        static private int GetInt(string word, int min, int max)
        {
            int numInput = 0;      // int input ny user
            bool valid = false;    // error flag ,will check if conditions are met

            // repeat until value is true and in range
            while (!valid)
            {
                // wording set in main()
                Console.Write(word);

                // user input for value
                valid = int.TryParse(Console.ReadLine(), out numInput);

                //error if not a valid number
                if(!valid)
                {
                    Console.WriteLine("\nAn invalid number was entered, please try again.\n");
                }
                

                // if value is less than set minium, error message
                if (numInput < min)
                {
                    Console.WriteLine("\ninput is lower then minium\n");
                    valid = false;
                }

                //if value is over maxium, error message
                if (numInput > max)
                {
                    Console.WriteLine("\ninput is higher then max value\n");
                    valid = false;
                }
            }
            return numInput;
        }

    }
}
