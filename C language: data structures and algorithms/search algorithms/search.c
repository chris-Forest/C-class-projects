#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "search.h"

//itterate through array until a match is found
result SeqSearch(int Arr[], int size, int val)
{
	int num;
	result name;
	name.index = 0;
	name.comp = 0;

	//itterate through array
	for (num = 0; num < size; num++)
	{
		// if match is found, return found result
		if (Arr[num] == val)
		{
			name.index = num;
			return name;
		}
		name.comp++;
	}

	//if at end of list, return not found search item
	if (num >= size)
	{
		// if we reach here, then element was not present 
		name.index = -1;
		return name;
	}		
}

// run a binary search algorithm with a sorted array
result binarySearch(int arr[], int n, int val)
{
	int low = 0, high = n - 1;
	result name;
	name.index = 0;
	name.comp = 0;

	//run while low val is less or equal to the high val
	while (low <= high)
	{
		//find mid point for array
		int mid = (low + high) / 2;

		// Check if val is present at mid 
		if (arr[mid] == val)
		{
			name.index = mid;
			return name;
		}	
		name.comp++;

		// If val is smaller that arr[mid], ignore right half 
		if (val < arr[mid])
			high = mid - 1;

		// If val is greater, ignore left half 
		else
			low = mid + 1;
	}

	// if we reach here, then element was not present 
	name.index = -1;
	return name;
}