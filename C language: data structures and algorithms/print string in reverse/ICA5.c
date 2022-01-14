#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
	int stringLength = 0;

	//if no args or more then one arg erro msg
	if (argc != 2)
	{
		fprintf(stderr, "please add arg or check for only one arg");
		exit(EXIT_FAILURE);
	}
	else
	{
		// finds string length
		while (argv[1][stringLength] != 0)
			stringLength++;

		//get string length and print it in reverse
		for (stringLength; stringLength >= -0; stringLength--)
		{
			printf("%c", argv[1][stringLength - 1]);
		}
		exit(EXIT_SUCCESS);
	}
}