#include <stdio.h>
#include<time.h>
#include <stdlib.h>
#include <malloc.h>
#include "queue.h"
#include "Billing.h"

//take car info and add it to stack
// add service cost taken by userto bill that is passed
addBills(CarNode cn)
{
	// create node and check if memory was allocated
	ptr newN = (ptr)malloc(sizeof(CarNode));
	if (!newN)
		exit(EXIT_FAILURE);

	//assign a value from the parameter
	*newN = cn;
	
	//display info for car being transfered
	printf("\nmoving vehicle from service to billing stack\n");
	displayOne(&cn, 0);

	//add bill to top of stack
	if (billStackHead)
		newN->next = billStackHead;
	billStackHead = newN;

	// count current size of stack
	billStacksize++;

	//input for user for service cost
	printf("\nInpunt cost of servicing for this bill: $\n");
	scanf_s("%f", &newN->serviceCost);
}

displayBills()
{
	ptr temp = billStackHead; //temp pointer to go through stack

	printf("all current unpaid bills on stack:\n\n");

	//run until at end of stack
	while (temp)
	{
		//pass info to display method and add a line ...
		displayOne(temp, 1);
		temp = temp->next;
	}
}

//take reg number from user, find bill in stack to corisponding reg number
trnsferFROMbillStack()
{
	int redo = 0;                          // flg to reenter reg number
	int nothing = 1;                       // flg if no reg number found
	int reg;                               // # inputed by user
	char choice = NULL;                    // for asking user to try again 
	ptr temp;                              // used to run through stack then add to paid bills
	ptr linker = (ptr)malloc(sizeof(ptr)); // link stack after a bill is paid
	linker = NULL;                         
	
	do
	{
		nothing = 1;

		//prompt user for reg number 
		printf("Enter registration number foe vehicle getting paid off: ");
		scanf_s("%d", &reg);

		//set temp pointer to top of the stack
		temp = billStackHead;

		do
		{
			//if found break loop
			if (temp->regNum == reg)
			{
				redo = 0;
				break;
			}

			// if at end of stack and no match ask user to try again
			if (!temp->next)
			{
				do
				{
					// user input
					printf("registration not found, tryagain? y/n: ");
					scanf_s("%c", &choice, 1);

					// if no go back to main
					if (choice == 'n')
						return;

					//if yes and no match found ask to try again
					else if (choice == 'y')
					{
						nothing = 0;
						redo = 1;
					}
					else
						printf("\n yes or no\n");

					//loop if no y/n input
				} while (choice != 'n' && choice != 'y');				
			}
			// relink with pointer to stack using node to before the one wanted
			else if (temp->next->regNum == reg)
				linker = temp;
			
			//pull bill off stack
			temp = temp->next;

			//loop if no match
		} while (nothing);

		// loop for reinput
	} while (redo);

	//show that right bill was found
	printf("\nmatching bill found with registration number %d:\n\n", reg);
	displayOne(temp, 2);

	//check for room in data 
	if (Paidbill.size >= Paidbill.max)
		Grow(&Paidbill, 2);

	//add bill to data,remove from stack and increment data size
	Paidbill.data[Paidbill.size] = *temp;
	Paidbill.data[Paidbill.size].next = NULL;
	Paidbill.size++;

	//if bill was on top of stack set head to next bill
	if (linker == NULL)
		billStackHead = temp->next;

	// else if link made relink stack
	else if (linker != NULL)
		linker->next = temp->next;

	// free up the memmory
	free(temp);

	//decreese stack size
	billStacksize--;

	printf("Bill succesfully transfered from stack to data(stored)\n");
}

//find and display total bills in stack 
unpaidTotal()
{
	float total = 0;         //total of all bills in stack
	ptr temp = billStackHead;// pointer for looping through stack

	//loop until end of stack
	while (temp)
	{
		// add all service costs, then get next bill
		total += temp->serviceCost;
		temp = temp->next;
	}

	// display sum
	printf("Total unpaid bills: $%.2f\n", total);
}

//find and display total bills in data
paidTotal()
{
	float total = 0;  //total of all bills in data

	//loop until end of data and total servixe cost
	for (int c = 0; c < Paidbill.size; c++)
		total += Paidbill.data[c].serviceCost;

	// display sum
	printf("Total paid bills: $%.2f\n", total);
}