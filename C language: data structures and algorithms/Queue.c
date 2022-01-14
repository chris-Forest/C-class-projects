#include <stdio.h>
#include <time.h>
#include <stdlib.h>
#include <malloc.h>
#include "Billing.h"
#include "queue.h"

// prevent infinite loops IF NEEDED if strings are inputed instead of numbers
void empty()
{
	int no = getchar();
	while (no != '\n' && no != EOF)
		no = getchar();
}

// put values at start of the queue
void addQueue()
{
	// allocate memory for entire name
	char* name = (char*)malloc(sizeof(char) * 30);
	if (!name)
		exit(EXIT_FAILURE);
	char* lname = (char*)malloc(sizeof(char) * 30);
	if (!lname)
		exit(EXIT_FAILURE);

	// allocate memory for VEHICLE MODEL
	char* model = (char*)malloc(sizeof(char) * 30);
	if (!model)
		exit(EXIT_FAILURE);

	// allocate memory for service date
	char* date = (char*)malloc(sizeof(char) * 30);
	if (!date)
		exit(EXIT_FAILURE);

	int regNum = 0;//registration number input by user
	float cap = 0;// engine cap input by user

	//user input for info
	printf("\nEnter customers first name: ");
	scanf_s("%s", name, 30);
	printf("\nEnter customers last name: ");
	scanf_s("%s", lname, 30);
	printf("\nEnter vehicle make: ");
	scanf_s("%s", model, 30);
	printf("\nEnter service date(no spaces): "); // spaces break the code, dont know why
	scanf_s("%s", date, 30);

	//get reg number with error checking
	do
	{
		printf("Enter vehicle registration number: ");
		//take input, if not number tell user and clear
		if (scanf_s("%d", &regNum) == 0)
		{
			printf("\nMust be a number, ");
			empty();
		}

		//if parsed but is less then 0 tell user
		else if (regNum <- 0)// =?
			printf("\nRegistration Number must be positive, ");

	} while (regNum<=0); 

	//get engine cap number with error checking
	do
	{
		printf("Enter vehicle engine capcity: ");
		//taek input , if not number tell uer and clear
		if (scanf_s("%f", &cap) == 0)
		{
			printf("\nMust be a number, ");
			empty();
		}

		//if parsed but is less then 0 tell user
		else if (cap <- 0) // =?
			printf("\nEngine capcity Number must be positive, ");

	} while (cap <= 0);

	// allocate memory 
	ptr newN = (ptr)malloc(sizeof(CarNode));

	//exit if no allocated memory
	if (!newN)
		exit(EXIT_FAILURE);

	// assign node data
	newN->Name = name;
	newN->nameL = lname;
	newN->model = model;
	newN->regNum = regNum;
	newN->egnCapacity = cap;
	newN->date = date;

	// add to front of list
	newN->next = QueueHeadWait;
	QueueHeadWait = newN;

	//increment queue size
	QueueSizeWait++;
}

// remove car from addqueue to service queue and nextinline adjusted
void deleteQueue()
{
	ptr temp = QueueHeadWait; //to find end of queue
	ptr end = NULL;           // new end and set to null 

	//find end of addqueue and node before it
	while (temp->next)
	{
		if (!temp->next->next)
			end = temp;
		temp = temp->next;
	}

	//give new end null pointer
	if (end)
		end->next = NULL;

	// if no new end queuehead is null
	else
		QueueHeadWait = NULL;

	// free up memory
	free(temp);

	//decrement  queue suze
	QueueSizeWait--;	
}

// returns pointer to car that was in addqueue that is now in service queue
// will set new car and wait for servicing
ptr nextInLine()
{
	ptr temp = QueueHeadWait;

	//find end of queue
	for (int c = 1; c < QueueSizeWait; c++)
		temp = temp->next;
	return temp;
}

//display all info for cars in queue
void queuePrint()
{
	ptr temp = QueueHeadWait;

	printf("wait Queue:\n\n");

	//loop through queue
	while (temp)
	{
		// display all info and get next node
		displayOne(temp, 0);
		printf("\n");
		temp = temp->next;
	}
}

// dis[lay info for single customer
void displayOne(ptr info, int servCost)
{
	// the info
	printf("\n\tName: %s \n\tLast: %s", info->Name,info->nameL);
	printf("\n\tMake: %s", info->model);
	printf("\n\tDate: %s", info->date);
	printf("\n\tRegistration #: %i \n\tEngine Capacity: %.2f", info->regNum, info->egnCapacity);

	// get service cost if there is one(muest be set to one to display)
	if (servCost)
		printf("\n\tService cost: %.2f\n\n", info->serviceCost);
}

//when adding/inserting vectors
//increase max vector capacity
void Grow(Vect* v, int scale)
{
	int newCapacity = v->max * scale;

	if (!v->data || newCapacity < INITIAL_CAPACITY)//Need to initialize
		newCapacity = INITIAL_CAPACITY;

	ptr newStore = (ptr)malloc(sizeof(ptr) * newCapacity);
	if (!newStore)
	{
		fprintf(stderr, "Error: Unable to reserve memory for growth.");
		exit(EXIT_FAILURE);
	}

	//Copy old store into new
	for (int i = 0; i < v->size; ++i)
		newStore[i] = v->data[i];

	//release old memory (Make sure you do this before you change the pointer)
	if (v->data) free(v->data); //Don't try to free a null pointer.

	//Point to new store
	v->data = newStore;

	//Reset capacity
	v->max = newCapacity;
}

//shink vector datacap and size when removing vectors vals from it
void Shrink(Vect* v, int scale)
{
	int newCap = v->max / scale;

	if (newCap < v->size)
		newCap = v->size;

	ptr newData = (ptr)malloc(sizeof(ptr) * newCap);
	if (!newData)
	{
		fprintf(stderr, "fatile error");
		exit(EXIT_SUCCESS);
	}

	//Copy old data into new
	for (int i = 0; i < v->size; i++)
	{
		newData[i] = v->data[i];
	}

	if (v->data) free(v->data);

	//Point to new data and set new cap
	v->data = newData;
	v->max = newCap;
}

// takes car from addqueue to service queue
void TransferTOserviceQ()
{
	// check vect capcity
	if (serviceQ.size >= serviceQ.max)
		Grow(&serviceQ, 2);

	//take car in addqueue and bring it to
	serviceQ.data[serviceQ.size] = *nextInLine();
	serviceQ.size ++;

	//remove the carfrom add queue
	deleteQueue(&serviceQ.data);

	printf("\nTransfered next car in wait to service queue\n\n");
}

// remove a car from the front of service queue and add it to bill stack
void TransferFROMserviceQ()
{
	// add next car in service to bill stack
	addBills(serviceQ.data[0]);

	//loop through service queue data
	for (int i = 0; i < serviceQ.size; i++)
		// shift values back one index, overwriting original val
		serviceQ.data[i] = serviceQ.data[i + 1];

	//reduce vect size by 1
	serviceQ.size--;

	//check capacity is only a /4 used
	if (serviceQ.size < serviceQ.max / 4)
		// reduce in size if true
		Shrink(&serviceQ, 2);
}

// display all info for all cars in service queue
void DisplayserviceQ()
{
	printf("\nService queue:\n\n");

	//loop through queue starting with last added car
	for (int c = serviceQ.size - 1; c >= 0; c--)
		// display all car info
		displayOne(&serviceQ.data[c], 0);
}