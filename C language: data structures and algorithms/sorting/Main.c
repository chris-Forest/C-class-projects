#include <stdio.h>
#include <stdlib.h>
#include "sort.h"

int main()
{
	//making array data 
	int ID[] = { 12,23,32,15,18,43,8,31,5,35,41,21,19,48,7,38,14,26,33,42};
	char fNames[][20] = { "Johny","Andrea","Amelia","Jasmine","Anders","Roberto",
					   "Angelina", "Sherlock","Michael","Marvin","Jenny",
					   "Olive","Amedie","Vanessa","Fenando","Sadio","Selena",
						"Romeo","Juliette","Charlie" };
	char lNames[][20] = { "Aladin","Torredo","Paradis","Marlon","Ronaldo",
						"Rodriguez","Farmer","Douglas","Stone","Oreo",
						"Bernouilli", "Archimedes","Watt","Curie", "Gamma",
						"Marbella","Danube","Santiego","Rochecoute","Madelon" };
	
	Employee employees[20];

	for (int i = 0; i < 20; i++)
	{
		employees[i].EmployeeId = ID[i];
		employees[i].fName = fNames[i];
		employees[i].lName = lNames[i];
	}	

	/*Testing the Sorting Algorithms*/

	printf("Before Sorting- myArray:\n");
	for (int posn = 0;posn < 20; posn++) 
	{
		printf("\nID: %i FN: %s, LN: %s",employees[posn].EmployeeId,employees[posn].fName, employees[posn].lName);
	}
	printf("\n\n");

	bubbleSort(employees, 20);

	printf("\narray sorted using Bubble Sort:\n");
	for (int posn = 0;posn < 20; posn++) 
	{
		printf("\nID: %i FN: %s, LN: %s", employees[posn].EmployeeId, employees[posn].fName, employees[posn].lName);
	}
	printf("\n\n");


	selectionSort(employees, 20);
	printf("\narray sorted using Selection Sort:\n");
	for (int posn = 0;posn < 20; posn++) 
	{
		printf("\nID: %i FN: %s, LN: %s", employees[posn].EmployeeId, employees[posn].fName, employees[posn].lName);
	}
	printf("\n");

	return 0;
}