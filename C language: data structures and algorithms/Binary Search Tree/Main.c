/************************************************************
 *  File:        Main.c
 *  Project:     Lab 4
 *  Author:      chris forest
 *  Description: building a tree system with employee information
 * *********************************************************/

#include <stdio.h>
#include <stdlib.h>
#include "trees.h"
#include <string.h>

 /*********************************************************************
  * Function:    main
  * Description: takes employees id and salary and build binary trees with them
  *              display in order according to id # and salary
  *              diplay an  menu that will do:
  *              1) search for and employees id and display info about them
  *              2) count the number of employees above a user input salary
  *				 3) display all employees equal to or above the inputed salary
  * ******************************************************************/
int main()
{
	node* IDTree = NULL;
	node* salTree = NULL;
	Employee employees[20];

	//make array data
	int ID[20] = { 23,32,12,18,15,43,8,35,13,31,41,21,19,48,7,38,14,26,33,42 };
	char fNames[20][20] = { "Johny","Andrea","Amelia","Jasmine","Anders","Roberto",
					   "Angelina", "Sherlock","Michael","Marvin","Jenny",
					   "Olive","Amedie","Vanessa","Fenando","Sadio","Selena",
						"Romeo","Juliette","Charlie" };
	char lNames[20][20] = { "Aladin","Torredo","Paradis","Marlon","Ronaldo",
						"Rodriguez","Farmer","Douglas","Stone","Oreo",
						"Bernouilli", "Archimedes","Watt","Curie", "Gamma",
						"Marbella","Danube","Santiego","Rochecoute","Madelon" };

	int Salary[20] = { 3200,2300,4800,2700,4500,5800,2000,1300,3500,4600,2500,2900,5200,6000,
				   5600,1800,2200,2800,3700,5700 };

	//set and store employee info from given arrays
	for (int i = 0; i < 20;i++) 
	{
		employees[i].EmployeeId = ID[i];
		employees[i].salary = Salary[i];
		employees[i].fName = (char*)malloc(20);
		employees[i].lName = (char*)malloc(20);
		strcpy_s(employees[i].fName, 20, fNames[i]);
		strcpy_s(employees[i].lName, 20, lNames[i]);
		IDTree = insertTreeID(IDTree, employees[i]);
		salTree = insertTreeSALARY(salTree, employees[i]);
	}

	printf("Nodes in Order of ID: \n");
	inOrder(IDTree);
	printf("\n\n");
	printf("Nodes in Orderof salary: \n");
	inOrder(salTree);
	printf("\n\n");

	// menu selection, as long as 0 is not pressed
	//program keeps running
	int sel = 0;
	do
	{
		int search;
		int salary;
		printf("1: search for an employee ID\n");// based on id, display info om emploee
		printf("2: count number of employees above threshold salary\n");
		printf("3: display information of employees above threshold salary\n"); // all info of employee(s)
		printf("0: exit\n");
		printf("Enter your choice: ");
		scanf_s("%d", &sel);
		printf("\n");
	
		switch (sel)
		{
		case 1: // search for an employee ID
			printf("Insert the employe ID number you're looking for: ");
			scanf_s("%i", &search);
			Displayemployee(searchTree(IDTree, search));
			break;
		// count number of employees above threshold salary
		case 2:
			printf("Set salary threshold: ");
			scanf_s("%i", &salary);
			printf("%i employees are above $%i salary\n\n", countEqualOrHigher(salTree, salary), salary);
			break;
		//display information of employees above threshold salary
		case 3:
			printf("Set salary threshold: \n");
			printf("Employees above salary amount: ");
			scanf_s("%i", &salary);
			displayEqualOrHigher(salTree, salary);
			printf("\n");
			break;
		case 0:
			//exit
			break;
		default:
			printf("Unknown input");
			break;
		}
	} while (sel != 0);
}