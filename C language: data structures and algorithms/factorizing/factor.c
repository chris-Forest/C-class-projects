#include <stdio.h>

//take a number given by user and factorize it
void PrintFactors(int n)
{
	//base case
	// if number being factorted is one
	//stop factoring 
	// print up to that number before one
	if (n == 1) 
		return;

	int num = 2;
	// if factored number is divided evenly and not zero
	// factor the number and print the number that is divided evenly
	// and continue until number is fully factored
	while (n % num != 0)
		num++;

	printf("factors are: %d\n", num);
	//Call for string starting at next char.
	PrintFactors(n / num);
}

//runs code on start
int main()
{
	int n;
	printf("insert a number to factor: ");
	scanf_s("\n%d", &n);
	PrintFactors(n);
}