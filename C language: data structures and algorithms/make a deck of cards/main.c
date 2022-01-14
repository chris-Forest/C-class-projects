#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "cards.h"

int main()
{
	Card cCard[52];
	int nCard = 0;
	char sCard[29];

	//biuld deck of cards
	for (int nCountSuit = 0; nCountSuit < 4; nCountSuit++)
	{
		for (int nCountValue = 2; nCountValue < 15; nCountValue++)
		{
			cCard[nCard].suit = nCountSuit;
			cCard[nCard].face = nCountValue;
			nCard++;
		}
	}

	printf("displaying normal deck of cards\n\n");
	for (nCard = 0; nCard < 52; nCard++)
	{
		strcpy_s(sCard, 28, getcards(cCard[nCard]));
		printf("%s", sCard);
		printf("\n");
	}

	printf("\nshuffled deck\n");
	printCards();
	printf("\n");
}

