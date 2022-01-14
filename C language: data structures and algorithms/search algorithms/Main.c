#include <stdio.h>
#include <stdlib.h>
#include "search.h"

int main()
{
	srand(time(NULL));
	result name;
	name.index = 0;
	name.comp = 0;
		
	//make array data
	int ID[] = { 3,7,8,12,13,14,18,20,23,24,27,29,32,33,34,36,39,40,44,49 };
	char fNames[][20] = { "Johny","Andrea","Amelia","Jasmine","Anders","Roberto",
					   "Angelina", "Sherlock","Michael","Marvin","Jenny",
					   "Olive","Amedie","Vanessa","Fenando","Sadio","Selena",
						"Romeo","Juliette","Charlie" };
	char lNames[][20] = { "Aladin","Torredo","Paradis","Marlon","Ronaldo",
						"Rodriguez","Farmer","Douglas","Stone","Oreo",
						"Bernouilli", "Archimedes","Watt","Curie", "Gamma",
						"Marbella","Danube","Santiego","Rochecoute","Madelon" };

	//assign the made employees info to array
	for (int i = 0; i < 20; i++)
	{
		employees[i].EmployeeId = ID[i];    
		(employees[i].fName = fNames[i]); 
		(employees[i].lName = lNames[i]); 
	}

	//run both algorithms 10 times
	for (int i = 0; i < 10; i++)
	{
		int idNum = rand() % 50 + 1;

		//search for a random employee with id # between 0-50
		//through a sequential search algorithm
		name = SeqSearch(ID, 20, idNum);
		//if search is successful display result
		if (name.index > -1)
			printf("ID: %d found by sequential search- position %d- %s %s- %d comparrisons\n", idNum, name.index, employees[name.index].fName, employees[name.index].lName,name.comp);
		//else diplay search was unsuccessful
		else
			printf("ID: %d not found by sequential search- %d comparrisons\n", idNum,name.comp);

		//search for a random employee with id # between 0-50
		//through a binary search algorithm
		name = binarySearch(ID, 20, idNum);
		//if search is successful display result
		if (name.index > -1)
			printf("ID: %d found by binary search- position %d- %s %s- %d comparrisons\n\n", idNum, name.index, employees[name.index].fName, employees[name.index].lName,name.comp);
		//else diplay search was unsuccessful
		else
			printf("ID: %d not found by binary search- %d comparrisons\n\n", idNum,name.comp);
	}	
}