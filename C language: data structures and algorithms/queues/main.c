#include <stdio.h>
#include <stdlib.h>
#include "queue.h"
#include <time.h>
#include <malloc.h>

int main()
{
	queueCar Queue = (queueCar){ NULL,NULL };
	char choice = 'a';
	int numIN = 0;
	float ftIN = 0;
	char name[100]; char make[100];

	while (choice != '0')
	{
		choice = '0';
		menu();
		scanf_s("%c", &choice, sizeof(char));
		printf("\n");

		switch (choice)
		{
		case'7':
			deltQueue(&Queue);
			printf("move along boy");
			break;
		case'6':
			printf("Enter an engine capacity:");
			scanf_s("%f", &ftIN, sizeof(float));
			searchQueue(&Queue, ftIN);
			getchar();
			break;
		case'5':
			printf("Num of car in Queue: %i", queueSize(&Queue));
			break;
		case'4':
			displayAll(&Queue);
			break;
		case'3':
			printf("\n");
			nextInLine(&Queue);
			break;
		case'2':
			printf("Enter the registration number remove:");
			scanf_s("%i", &numIN, sizeof(int));
			//del(&Queue, &numIN);
			getchar();
			break;
		case'1':
			printf("\nEnter registration number: ");
			scanf_s("%i", &numIN, sizeof(int));
			printf("\nEnter the engine capacity: ");
			scanf_s("%f", &ftIN, sizeof(float));
			getchar();
			printf("\nEnter Name: ");
			fgets(name, 40, stdin);
			printf("\nEnter make: ");
			fgets(make, 20, stdin);
			enQueue(&Queue, numIN, ftIN, strdup(name), strdup(make));
			break;
		case'0':
			//exit
			break;
		default:
			printf("wrong Input\n");
			break;
		}
		
		//getchar();
	}
	exit(EXIT_SUCCESS);
}
