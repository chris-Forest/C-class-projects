#include <stdio.h>
#include<time.h>
#include <stdlib.h>
#include <malloc.h>
#include "queue.h"

// creates a new likned list filled with car data
CarNode* createNode(int regNumber, float eCapcity, char* fN, char* make)
{
	CarNode* temp = (CarNode*)malloc(sizeof(CarNode));
	temp->regNum = regNumber;
	temp->egnCapacity = eCapcity;
	temp->Name = fN;
	temp->model = make;
	temp->next = NULL;
	return temp;
}

// put values at start of the queue
void enQueue(queueCar* QC, int regNumber, float eCapcity, char* fN, char* make)
{
	//temp car variable
	CarNode* temp = createNode(regNumber, eCapcity, fN, make);

	//if null check
	if (QC->front == NULL)
	{
		QC->front = QC->back = temp;
		temp = NULL;
		return;
	}

	//set next car at back to next car
	QC->back->next = temp;
	//set temp to back of queue
	QC->back = temp;

	temp = NULL;
}

//proccess the queue
void deltQueue(queueCar* QC)
{
	//null check
	if (QC->front == NULL)
		return;
	 
	// temp variable
	CarNode* temp = QC->front;

	// for learing purposes
	QC->front = temp->next;
	if (QC->front == NULL)
		QC->back = NULL;

	//free up data
	free(temp);
}

//delete a car from the queue//no working (never did)
void del(queueCar* QC, int regNumber)
{
	CarNode* current = QC->front;
	CarNode* temp;

	//
	while (current != NULL && current->regNum != regNumber)
	{
		current = current->next;
		QC->front=QC->front->next;
	}

	temp = current->next;
	//current = temp;
	current->regNum = temp->regNum;
	current->egnCapacity = temp->egnCapacity;
	current->Name = temp->Name;
	current->model = temp->model;
	current->next = temp->next;
	free(temp);

	current = QC->front;
	while (current->next != NULL)
		current = current->next;
	QC->back = current;
}

//check size of queue
int queueSize(queueCar* QC)
{
	int count = 0;
	CarNode* crnt = QC->front;
	while (crnt != NULL)
	{
		count++;
		crnt = crnt->next;
	};
	return count;
}

//look for a specfic member in the queue
void searchQueue(queueCar* QC, float eCapacity)
{
	CarNode* crnt = QC->front;
	while (crnt != NULL)
	{
		if (crnt->egnCapacity >= eCapacity)
			queuePrint(crnt);
		crnt = crnt->next;
	}
}

//look to see who is next to be proccessed in the queue
void nextInLine(queueCar* QC)
{
	CarNode* temp = QC->front != NULL ? QC->front->next : NULL;

	if (temp != NULL)
	{
		printf("Next: ");
		printf(temp->model);
	}
	else
	{
		printf("ahhhh no cars");
	}
}

//print car info
void queuePrint(CarNode* car)
{
	printf("\n\tName: ");
	printf(car->Name);
	printf("\n\tMake: ");
	printf(car->model);
	printf("\n\tRegistration #: %i \n\tEngine Capacity: %.2f", car->regNum, car->egnCapacity);
}

//display all info for all cars in the queue
void displayAll(queueCar* QC)
{
	CarNode* curnt = QC->front;
	while (curnt!=NULL)
	{
		queuePrint(curnt);
		curnt = curnt->next;
	}
}

//user friendly menu
void menu()
{
	printf("\n\nPress 1 to add to the Queue\n");
	printf("Press 2 to delete a car from the queue\n");
	printf("Press 3 to check whats next in the queue\n");
	printf("Press 4 to display all information for whats in the queue\n");
	printf("Press 5 to display whtats still in the queue \n");
	printf("Press 6 to search \n");
	printf("Press 7 to move along the queue \n");
	printf("Press 0 to exit \n");
	printf("Enter your choice: ");
}