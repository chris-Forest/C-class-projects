#pragma once
#include "Cards.h"

typedef enum //assigns values to each possible poker hand
{
	pair = 1, twoPair, threeOfAKind, straight, flush, fullHouse, fourOfAKind, straightFlush
}PokerHandsValues;

typedef struct //each player can have a 5 card hand with a hand value and high card
{			   //player number is used when determining the winner after the player array has been sorted
	Card hand[5];
	int handVal;
	int highCard;
	int playNum;
}Play;

Play players[4]; //the array containing a Player struct for each player in the game

void DealHand();				   //deals a hand to each player
void ShowHand(int p);			   //prints a players hand to console
void GetHandValue(int p);		   //gets the hand value of a players hand by calling CheckForMatch and CheckForStraightFlush
void Sort(int p);			   //sorts a plaeyrs hand by card value, ignoring suit
void CheckMatch(int p);		   //finds pairs, 2 pairs, etc
void CheckSF(int p);        //checks the plaeyrs hand for straights, flushes or both
void Winner();			   //determines the winner of the game based on hand values and ties

static const char StringArray[9][20] =
{ "", "Pair", "Two Pair","Three of a Kind","Straight",  //this array contains strings to use for printing the poker hand types
"Flush","Full House","Four of a Kind","Straight Flush" };