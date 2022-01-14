#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "Cards.h"

//fills the deck array with 52 cards, one of each value for all 4 suits
void makeDeck()
{
	int index = 0;

	//iterate through each suit
	for (Suit suit = Clubs; suit <= Spades; suit++)
	{
		//iterate through each card value in each suit
		for (Face val = Two; val <= Ace; val++)
		{
			//add a card of each suit and value to the deck and assign strings
			Deck[index] = (Card){ suit,val,suitNameArray[suit],valueNameArray[val] };
			index++;
		}
	}
}

//shuffles the deck array into a random order
void Shuffle()
{
	Card a; //the card to be swapped out of the deck at index i
	Card b; //the card to be swapped into the deck at index i
	int r;  //the randomly selected location of card b in the deck

	//iterate through the deck in reverse order, so the random card is limited to the cards that havent been chosen yet
	for (int i = 51; i > 0; i--)
	{
		//get a random card from remaining deck
		srand(time(0));
		r = rand() % (i);

		//store the 2 cards to swap
		a = Deck[i];
		b = Deck[r];

		//swap 2 cards
		Deck[i] = b;
		Deck[r] = a;
	}
	printf("Deck Shuffled\n\n");
}
void print()
{
	//iterate through the deck and print all values using string arrays
	for (int i = 0; i < 52; i++)
		printf("%s of %s\n",Deck[i].CardValue, Deck[i].CardSuit);

	printf("\n");
}

