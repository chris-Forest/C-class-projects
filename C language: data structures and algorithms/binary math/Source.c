#include<stdio.h>
#include<stdlib.h>
#include<stdbool.h>
#include<string.h>

typedef unsigned char uInt;

//*****************************
// method:  PrintBin
// purpose: print the number in its binary form form
//*****************************
void PrintBin(uInt input)
{
	for (int i = 0; i < 8; i++)
	{
		if (input & 128 >> i)
			printf("1");
		else
			printf("0");
	}
	printf("\n");
}

//*****************************
// method:  NumPrint
// purpose: print the inputed number in decimal form
//*****************************
void NumPrint(uInt sign, uInt input)
{
	if (input > -10 && input < 10)
		printf(" ");
	printf("%c%d", sign, input);
}

//*****************************
// method:  uInt TwosCompliment
// purpose: take input an convert it to is binary 2's complement form
//*****************************
uInt TwosCompliment(uInt input)
{
	bool num1 = false;

	for (int c2 = 0; c2 < 8; c2++)
	{
		if (num1)
			input ^= 1 << c2;

		if (input & 1 << c2)
			num1 = true;
	}
	return input;
}

int main(int argc, char** argv)
{
	// err for no args
	if (argc == 1)
	{
		fprintf(stderr, "\nNot enough args... add some!\n\n");
		exit(EXIT_FAILURE);
	}

	// if only 1 arg given
	else if (argc == 2)
	{
		fprintf(stderr, "\n1 args... add more!\n\n");
		exit(EXIT_FAILURE);
	}

	// if only 3 arg given
	else if (argc == 4)
	{
		fprintf(stderr, "\n3 args... add 1 more!\n\n");
		exit(EXIT_FAILURE);
	}

	//err for too many args
	else if(argc>5)
	{
		fprintf(stderr, "\ntoo many args, pkease remove some\n\n");
		exit(EXIT_FAILURE);
	}

	//run the program
	else
	{
		uInt val1;              // first um given
		uInt val2;              // second num given
		uInt sum = 0;           // result of addign number together
		bool CarryOver = false; // tracks the carry of bin numbers

		printf("\n"); 

		// run if 2 args given
		if (argc == 3)
		{
			// convert first arg to int then store it
			val1 = atoi(argv[2]);

			//if "+"
			// display the number and its binary 1's comp version
			if (argv[1][0] == '+')
			{
				NumPrint('+', val1);
				printf("in binary: ");
				PrintBin(val1);
			}

			// if  arg one is "-"
			// run 2's comp and store it
			else if (argv[1][0] == '-')
			{
				NumPrint('-', val1);
				val1 = TwosCompliment(val1);
				printf("twos Compliment: ");
				PrintBin(val1);
			}
			printf("\n");
		}

		// if 4 args run this code
		else if (argc == 5)
		{
			// convert inputed vals to ints, then store 
			val1 = atoi(argv[2]);
			val2 = atoi(argv[4]);

			// check signs for both numbers then print
			if (argv[1][0] == '-')
			{
				NumPrint('-', val1);
				val1 = TwosCompliment(val1);
			}
			else if (argv[1][0] == '+')//***
				NumPrint('+', val1);

			printf(" in binary: ");
			PrintBin(val1);

			if (argv[3][0] == '-')
			{
				NumPrint('-', val2);
				val2 = TwosCompliment(val2);
			}
			else if (argv[3][0] == '+')
				NumPrint('+', val2);

			printf("twos Compliment: ");
			PrintBin(val2);

			// add nums together
			for (int i = 0; i < 8; i++)
			{
				if ((!(val1 & 1 << i)) && (!(val2 & 1 << i)) && (CarryOver))
				{
					sum ^= 1 << i;
					CarryOver = false;
				}
				else if ((!(val1 & 1 << i)) && (val2 & 1 << i) && (!CarryOver))
					sum ^= 1 << i;

				else if ((val1 & 1 << i) && (!(val2 & 1 << i)) && (!CarryOver))
					sum ^= 1 << i;

				else if ((val1 & 1 << i) && (val2 & 1 << i) && (!CarryOver))
					CarryOver = true;

				else if ((val1 & 1 << i) && (val2 & 1 << i) && (CarryOver))
					sum ^= 1 << i;
			}
			printf("\nsum:");

			//print sum in decimal form an binary form for subtraction
			if (sum & 128)
			{
				sum = TwosCompliment(sum);
				NumPrint('-', sum);
				printf(" in binary: ");
				sum = TwosCompliment(sum);
			}
			//print sum in decimal form an binary form for adddition
			else
			{
				NumPrint('+', sum);
				printf(" in binary: ");
			}

			PrintBin(sum);
			printf("\n");
		}
	}
}