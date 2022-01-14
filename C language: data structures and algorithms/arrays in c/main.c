#include <stdlib.h>
#include <stdio.h>
#include <time.h>

int main(int argc, char** argv)
{
	srand(time(NULL));
	int array[5];
	int* num = array;
	int size = sizeof(array) / sizeof(array[0]);
	//int size = 5;

	for (int i = 0; i < size; i++)
		array[i] = rand() % 100 + 1;

	//display array
	num++;
	printf("1st Value: %d\n", array[0]);
	printf("2nd Value: %d\n", *num); //swap this val
	num++;
	printf("3rd Value: %d\n", *num);
	num++;
	printf("4th Value: %d\n", *num); // swap this val
	num++;
	printf("5th Value: %d\n", *num);
	printf("\n");

	//swap proccess
	int temp = array[1];
	array[1] = array[3];
	array[3] = temp;

	//re-display array with 2 array points swaped positions
	printf("1st Value: %d\n", array[0]);
	printf("2nd Value: %d\n", array[1]); //swaped val
	num++;
	printf("3rd Value: %d\n", array[2]);
	num++;
	printf("4th Value: %d\n", array[3]); //swaped val
	num++;
	printf("5th Value: %d\n", array[4]);
}
