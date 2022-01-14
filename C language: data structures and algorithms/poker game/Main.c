#include <stdio.h>
#include <stdlib.h>
#include "Cards.h"
#include "poker.h"

int main(int argc, char** argv)
{
	//bild deck
	makeDeck();
	print();
	// shuffle deck
	Shuffle();
	print();

	// deal out rhe cards
	DealHand();

	// un sorred hands
	for (int p = 0; p < 4; p++)
		ShowHand(p);

	printf("hands sorted\n\n");

	//sort all hands
	for (int p = 0; p < 4; p++)
	{
		Sort(p);
		ShowHand(p);
	}

	//get the hand value of all players and print it
	for (int p = 0; p < 4; p++)
		GetHandValue(p);

	// get winner
	Winner();
}