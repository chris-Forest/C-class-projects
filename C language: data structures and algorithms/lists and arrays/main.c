#include "list.h"
#include <stdio.h>
#include <stdlib.h>

int main()
{
	char* names[10] = { '\0' };
	names[0] = "cheeder"; names[1] = "plause"; names[2] = "moody"; names[3] = "ayg"; names[4] = "peek";
	names[5] = "noot"; names[6] = "bruh"; names[7] = "name"; names[8] = "rust"; names[9] = "pluck";
	StudentN* start= CreateList(10,names);

	char choice = '0';

	//as long as user does not press the key #5 the program will still run
	while (choice != '5')
	{
		choice='0';
		menu();
		scanf_s("%c", &choice,sizeof(char));//scan for user input
		printf("\n");

		//depending on user choice display info
		switch (choice)
		{
			//order by id ascesending
		case '1':
			printf("\n*****************\n");
			orderIDnode(start);
			Display(start, NULL, 0);
			printf("\n*****************\n");
			break;
			//order by grades desending
		case '2':
			printf("\n*****************\n");
			orderMARKnode(start);
			Display(start, NULL, 0);
			printf("\n*****************\n");
			break;
			//display info for all students in array
		case '3':
			printf("\n*****************\n");
			Display(start, NULL, 0);
			printf("\n*****************\n");
			break;
			//display all students who have passed
		case '4':
			printf("\n*****************\n");
			Display(start, NULL, 50);
			printf("\n*****************\n");
			break;
			//exit program
		case '5':
			break;
		default:
			printf("wrong Input\n");
			break;
		}
		getchar();
	}
	exit(EXIT_SUCCESS);
	
	
}