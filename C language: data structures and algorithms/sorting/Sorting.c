#include "sort.h"

/*swaps the values of its parameters
 firstval and secondval*/
void swap(Employee* firstval, Employee* secondval)
{
	Employee temp;
	temp = *firstval;
	*firstval = *secondval;
	*secondval = temp;
}

/*Performs the sorting of an array in ascending order
 using Bubble Sort technique
 Parameters are: Arr - The array to be sorted
                 num - the number of elements in the array
*/
void bubbleSort(Employee Arr[], int num)
{
	int count = 0;
	int comp = 0;

/* We have an outer loop that performs n-1 passes over the array
   In the first pass the the highest element will get into its position
   In the second pass the second largest element will reach its position
   In the (n-1)th pass the (n-1)th largest (i.e 2nd smallest) element will
   reach its position, causing the smallest one to be automatically in its
   position*/
	for (int i = 0;i < num-1; i++) 
	{
		//note that in the inner loop, j goes only as far as num-i-2
		// j+1 will be num-i-1
		//elements at positions i to num-1 are already in their 
		//respective positions
		for (int j = 0;j < num-i-1; j++)
		{
			comp++;
			if (Arr[j].EmployeeId > Arr[j + 1].EmployeeId)
			{
				count++;
				swap(&Arr[j], &Arr[j + 1]);
			}			
		}		
	}
	printf("swap %i and compare %i", count, comp);
}

/*Performs the sorting of an array in ascending order
 using selectionSort technique
 Parameters are: Arr - The array to be sorted
				 num - the number of elements in the array
*/
void selectionSort(Employee arr[], int num)
{
	int i, j, max_idx;
	int count = 0;
	int comp = 0;

	// We have num-1 passes 
	//In each pass the largest element in the 
	//unsorted part of the array goes into its position
	for (i = 0; i < num - 1; i++)
	{
		// In each pass start from position 0
		//Find the maximum element in unsorted part of array 
		max_idx = 0;
		for (j = 0; j < num - i; j++)
		{
			comp++;
			if (arr[j].EmployeeId > arr[max_idx].EmployeeId)
			{
				count++;
				max_idx = j;
			}
		}
			
		// Swap the found maximum element with the 
		// last element in the still unsorted part of 
		//the array
		swap(&arr[max_idx], &arr[num-i-1]);
	}
	printf("swap %i and compare %i", count, comp);
}