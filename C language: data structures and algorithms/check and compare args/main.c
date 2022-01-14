#include<stdio.h>
#include<stdlib.h>

int main(int argc, char** argv)
{
	//if "-a" is the first argument, display all other arguments
	if (strcmp(argv[1], "-a") == 0)
	{
		printf("argumnets: ");
		for (int i = argc - 1; i > 1; i--)
		{
			printf("%s", argv[i]);
		}
	}
	// otherwise check and compare for "-c"
	else
	{
		//if "-c" is the first argument, display all other arguments in reverse character by character
		printf("Reverse argumnets: ");
		if (strcmp(argv[1], "-c") == 0)
		{
			for (int i = argc - 1; i > 1; i--)
			{
				for (int j = strlen(argv[i]) - 1; j >= 0; j--)
				{
					printf("%c", argv[i][j]);
				}
			}
		}

		//if neither are there display an error message
		else
		{
			fprintf(stderr, "must have -a or-c");
		}
	}
	exit(EXIT_SUCCESS);
}