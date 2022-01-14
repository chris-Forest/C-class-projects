#include<stdio.h>
#include<stdlib.h>

typedef unsigned int num;

int main(int argc, char** argv)
{
	int set; //to track # of set bits for aguments given
	num CheckSet;

	// if there are more then 1 argument
	//start bitwsie proccess
	if (argc > 1)
	{
		//for as many arguments there are
		//run bitwise operation on them
		for (int i = 1; i < argc; i++)
		{
			// if str can be converted to long int and is greater or equal to 0
			//run if statment contents
			if (strtol(argv[i], NULL, 10) >= 0)
			{
				// assign argumnets to be converted to long int
				CheckSet = strtol(argv[i], NULL, 10);				
				set = 0;//set default counter

				// evey 32 bit per arg number update number of set bits
				for (int b = 0; b < 32;b++)
				{
					//take converted arguments and 
					//do bitwise & on them and left shift one postion
					//and then track how many set bits each argument has
					if (CheckSet & (1 << b))
					{
						set++;
					}
				}
				printf("%i has %i set bits\n", CheckSet, set);
			}

			// if argumnets are negative in anyway display an error
			else
			{
				fprintf(stderr, "positvie args only!");
				exit(EXIT_SUCCESS);
			}
		}
	}

	// if no arguments set, display an error
	else
	{
		//error
		fprintf(stderr, "no agrs, add some");
		exit(EXIT_SUCCESS);
	}
}