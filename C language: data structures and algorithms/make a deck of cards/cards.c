#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "cards.h"

// A function (getcards) that accepts a Card and prints out the corresponding string for its name.
char* getcards(Card c)
{
	char* sCardSuit;
	char* sCardValue;
	char sCard[29];

	//get value of cards
	switch (c.face)
	{
	case Two:
		sCardValue = "Two";
		break;
	case Three:
		sCardValue = "Three";
		break;
	case Four:
		sCardValue = "Four";
		break;
	case Five:
		sCardValue = "Five";
		break;
	case Six:
		sCardValue = "Six";
		break;
	case Seven:
		sCardValue = "Seven";
		break;
	case Eight:
		sCardValue = "Eight";
		break;
	case Nine:
		sCardValue = "Nine";
		break;
	case Ten:
		sCardValue = "Ten";
		break;
	case Jack:
		sCardValue = "Jack";
		break;
	case Queen:
		sCardValue = "Queen";
		break;
	case King:
		sCardValue = "King";
		break;
	case Ace:
		sCardValue = "Ace";
		break;
	default:
		sCardValue = "Null";
		break;
	}

	//get card suits
	switch (c.suit)
	{
	case Clubs:
		sCardSuit = "Clubs";
		break;
	case Diamonds:
		sCardSuit = "Diamonds";
		break;
	case Hearts:
		sCardSuit = "Hearts";
		break;
	case Spades:
		sCardSuit = "Spades";
		break;
	default:
		sCardSuit = "Null";
		break;
	}

	//display as "Ace of Spades" format
	sprintf_s(sCard, 28, "%s of %s", sCardValue, sCardSuit);

	return(sCard);
}

//build deck of cards and display it shuffled
void printCards()
{
	//setting card values
	Card cCard[52];
	int nCard = 0;
	char sCard[29];

	for (int nCountSuit = 0; nCountSuit < 4; nCountSuit++)
	{
		for (int nCountValue = 2; nCountValue < 15; nCountValue++)
		{
			cCard[nCard].suit = nCountSuit;
			cCard[nCard].face = nCountValue;
			nCard++;
		}
	}

	//Shuffling deck of cards
	Card a; // card in deck to be swappped
	Card b; // card to swap into a positon in deck
	int r;  // location of card b in deck

	for (int i = 51; i >= 0; i--)
	{
		// get rdm card from deck
		srand(time(0));
		r = rand() % (i + 1);

		// store card swaps
		a = cCard[i];
		b = cCard[r];

		//swap cards
		cCard[i] = b;
		cCard[r] = a;
	}

	// print deck of card shuffled
	for (nCard = 0; nCard < 52; nCard++)
	{
		printf("\n");
		strcpy_s(sCard, 28, getcards(cCard[nCard]));
		printf("%s", sCard);
		//printf("\n");
	}
}
