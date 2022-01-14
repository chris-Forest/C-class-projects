#include <stdio.h>
#include <time.h>
#include <stdlib.h>
#include <malloc.h>
#include "queue.h"
#include "Billing.h"

menu()
{
	printf("\n\n1: to add to the Queue\n");
	printf("2: display waiting queue\n");
	printf("3: to check whats next in line for the srevice queue\n");
	printf("4: to transfer car to serveice queue\n");
	printf("5: to display all information for whats in the queue\n");
	printf("6: to display whtats still in the queues\n");
	printf("7: to delete a car from the queue and add bill to stack\n");
	printf("8: to display all bills on stack\n");
	printf("9: to move a bill off the stack to data storage\n");
	printf("10: to display sum of all unpaid bills\n");
	printf("11: to display sum of all paid bills\n");
	printf("0: to exit \n");
	printf("Enter your choice: ");

	int select;

	do
	{
		if (scanf_s("%d", &select) == 0 || select < 0 || select>11)
		{
			printf("\nPlease Enter a menu option: ");
			//empty
		}
	} while (select < 0 || select>11);

	// take user input and call approiate switch case
	switch (select)
	{
	case 1: //add to queue
		addQueue();
		return 1;
	case 2: // display wait queue
		if (QueueSizeWait > 0)
			queuePrint();
		else
			printf("\nnothing in queue\n");
		return 1;
	case 3:// display whos next in the queue
		if (QueueSizeWait > 0) 
		{
			printf("Next in the queue:\n");
			displayOne(nextInLine(), 0);
		}
		else
			printf("\nnothing in queue\n");
		return 1;
	case 4: // transfer to servecing queue
		if (QueueSizeWait > 0)
			TransferTOserviceQ();
		else
			printf("\nnothing in queue\n");
		return 1;
	case 5: // display service queue
		if (serviceQ.size > 0)
			DisplayserviceQ();
		else
			printf("\nnothing in queue\n");
		return 1;
	case 6:// display whats still in both queues
		if (QueueSizeWait > 0)
			queuePrint();
		else
			printf("\nnothing in queue\n");
		if (serviceQ.size > 0)
			DisplayserviceQ();
		else
			printf("\nnothing in queue\n");
		return 1;
	case 7: //remove a car from the service queue and add the bill to the stack
		if (serviceQ.size > 0)
			TransferFROMserviceQ();
		else
			printf("\nnothing in queue\n");
		return 1;
	case 8://displays all info for all bills currenlty in the stack
		if (billStacksize > 0)
			displayBills();
		else
			printf("\nnothing in queue\n");
		return 1;
	case 9: // transfer from bill stack to data stoarge
		if (billStacksize > 0)
			trnsferFROMbillStack();
		else
			printf("\nnothing in queue\n");
		return 1;
	case 10: // dispaky all unpaid totals 
		if (billStacksize > 0)
			unpaidTotal();
		else
			printf("\nnothing in queue\n");
		return 1;
	case 11: //dispaly all bills ther have been paid
		if (Paidbill.data > 0)
			paidTotal();
		else
			printf("\nnothing in queue\n");
		return 1;
	case 0:
		//exit
		return 0;
	default:
		break;
	}
}



int main()
{
	ptr newN = (ptr)malloc(sizeof(CarNode));
	if (!newN)
		exit(EXIT_FAILURE);

	newN->Name = "AJ";
	newN->nameL = "ok";
	newN->model = "ford";
	newN->date = "April 10th 2020";
	newN->regNum = 15;
	newN->egnCapacity = 2.2;
	newN->serviceCost = 10;

	newN->next = QueueHeadWait;
	QueueHeadWait = newN;
	QueueSizeWait++;

	newN = (ptr)malloc(sizeof(CarNode));

	newN->Name = "jk";
	newN->nameL = "beeeea";
	newN->model = "carhere";
	newN->date = "montober 787th 2036";
	newN->regNum = 100;
	newN->egnCapacity = 12.2;
	newN->serviceCost = 5;

	newN->next = QueueHeadWait;
	QueueHeadWait = newN;
	QueueSizeWait++;

	newN = (ptr)malloc(sizeof(CarNode));

	newN->Name = "john ";
	newN->nameL = "man";
	newN->model = "chase";
	newN->date = "november 10th 2182";
	newN->regNum = 66;
	newN->egnCapacity = 22.2;
	newN->serviceCost = 18;

	newN->next = QueueHeadWait;
	QueueHeadWait = newN;
	QueueSizeWait++;

	billStacksize = 0;

	while (menu());
	//return 1;
}