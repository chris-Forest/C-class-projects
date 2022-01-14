/************************************************************
 *  File:        Main.c
 *  Project:     Lab 1
 *  Author:      chris forest
 *  Version:     1.0
 *  Date:        feb 14 2020
 *  Course:      CMPE1700
 *  Instructor:  AJ Armstrong
 *  Description: display a running average for bit runs
 * *********************************************************/

#include<stdio.h>
#include<stdlib.h>

 /*********************************************************************
  * Function:    main
  * Arguments:   int argc - number of arguments (1 implicit arg always present)
  *              char** argv - Array of strings containing com. line arguments
  * API:         arg 1 - numbers only, no other arguments will be accepted
  * Description: get a number check for the number of "runs"  for x-bit intigers in binary
  *              display the average for x-int bit
  * ******************************************************************/

int main(int argc, char** argv)
{
	unsigned int NumOfBits = atoi(argv[1]); // input taken by user
	unsigned int RunningAvg = 0;            // the currnet running average of bits
	double rCount = 0;                      // count how many runs are in the given number
	double rTotal = 0;                      // total number of runs in given number
	double Avg = 0;                         // the average runs in number

	if (argc != 2)
	{
		fprintf(stderr, "one arg only");
		exit(EXIT_FAILURE);
	}
	else if (argv[1] <= 0)
	{
		fprintf(stderr, "enter positive numbers only");
		exit(EXIT_FAILURE);
	}

	//  loop throgh all numbers iin tit range
	for (int c = 1; c < (1 << NumOfBits) + 1; c++)
	{
		// loop through bits in number
		for (int i = 0; i < NumOfBits; i++)
		{
			// count the number of runs
			if (c & 1 << i && RunningAvg == 0)
			{
				RunningAvg = 1;
				rCount++;
			}
			else if (!(c & 1 << i) && RunningAvg == 1)
				RunningAvg = 0;
		}

		// calculate running average
		rTotal += rCount;
		Avg = rTotal / c;

		// reset for next number
		RunningAvg = 0;
		rCount = 0;
	}
	printf("%.2f\n", Avg);
	exit(EXIT_SUCCESS);
}