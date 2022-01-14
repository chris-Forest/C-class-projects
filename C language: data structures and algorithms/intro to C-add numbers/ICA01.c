#include<stdio.h>
#include<stdlib.h>

int main(int argc, char* argv[])
{
	int sum;
	sum = 0;

	//run through command line arguments to see if they are valid numbers or not
	for (int count = 1;argv[count];++count)
	{
		char* endptr;
		sum += strtol(argv[count], &endptr, 10);

		//if not a valid number show an error message and return a failed exit 
		if (*endptr != '\0')
		{
			fprintf(stderr, "error: the '%d-th' argument '%s', is not valid\n", count, argv[count]);
			return EXIT_FAILURE;
		}
	}
	//if command line arguments are valid add the numerical sums of arguments
	printf("sum of %d arguments is: %d\n", argc, sum);
	return EXIT_SUCCESS;
}