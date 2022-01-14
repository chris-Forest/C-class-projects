#include <stdio.h>
#include <stdlib.h>
#include "Cards.h"
#include "poker.h"

// deal 5 card hands to the players
void DealHand()
{
	int index = 0;

	// give players designated number value
	for (int p = 0; p < 4; p++)
		players[p].playNum = p + 1;

	// deal cards to each player
	for (int card = 0; card < 5; card++)
	{
		// deal one card at a time to each player
		for (int plr = 0; plr < 4; plr++)
		{
			players[plr].hand[card] = Deck[index];
			index++;
		}
	}
}

//print each players hand to console
void ShowHand(int p)
{
	printf("player %d has:\n", players[p].playNum);

	// loop through each players hand
	for (int c = 0; c < 5; c++)
	{
		//print card value and suit
		printf("%s of %s\n", players[p].hand[c].CardValue, players[p].hand[c].CardSuit);
	}
	printf("\n");
}

//sorts the players hand from smallest to greatest, by value
void Sort(int p)
{
	//iterate through the players hand one card at a time
	for (int cp = 0; cp < 5; cp++)
	{
		//check card cp with all remaining cards in the hand
		for (int i = cp + 1; i < 5; i++)
		{
			//if card cp has a greater value than car i 
			if (players[p].hand[cp].face > players[p].hand[i].face)
			{
				Card a = players[p].hand[cp];
				Card b = players[p].hand[i];
				players[p].hand[cp] = b;
				players[p].hand[i] = a;
			}
		}
	}
}

//checks a players hand for cards of matching values
//determines if player has a pair, three of a kind, four of a kind, 2 pair, or full house
//assigns the player a value for their hand if they have one of them
//also assigns them the value of their highest card in any match
void CheckMatch(int p)
{
	int matching1 = 1; //the number of cards that have the same value in the first set of matches
	int matching2 = 1; //the number of cards that have the same value in the second set of matches
	int valMatch1 = 0; //stores the value of matching cards, used to prevent counting 2 pairs as a three of a kind
	int valmatch2 = 0; //stores the value of the second set of matching cards
	int pairs = 0;     //counts the number of pairs 

	//**************************************************************
	//find how many and what type of matchs the players hand has
	//**************************************************************

	//iterate through the players hand one card at a time
	for (int cp = 0; cp < 5; cp++)
	{
		//check card cp with all remaining cards in the hand
		for (int i = cp + 1; i < 5; i++)
		{
			//if card cp matches card i in value, and no matches have been found yet
			if (players[p].hand[cp].face == players[p].hand[i].face && valMatch1 == 0)
			{
				matching1++;
				pairs++;
				valMatch1 = players[p].hand[cp].face;
			}
			//if 2 cards match and is same as first matching set
			else if ((players[p].hand[cp].face == players[p].hand[i].face) && (players[p].hand[cp].face == valMatch1))
				matching1++;

			//if 2 cards match, and have a different value as the first match
			else if ((players[p].hand[cp].face == players[p].hand[i].face) && (players[p].hand[cp].face != valMatch1))
			{
				valmatch2 = players[p].hand[cp].face;
				matching2++;
				pairs++;
			}
		}
	}

	//******************************************************
	// give play a hand value based on matched values
	//******************************************************

	//if one pair
	if (pairs == 1)
	{
		// find high card
		players[p].highCard = valMatch1;

		//check for pair, 3 or 4 of the same card
		switch (matching1)
		{
		case 2:
			players[p].handVal = pair;
			break;
		case 4:
			players[p].handVal = threeOfAKind;
			break;
		case 7:
			players[p].handVal = fourOfAKind;
			break;
		}
	}

	//if two pair
	else if (pairs == 2)
	{
		// get higher set of pairs
		if (valMatch1 > valmatch2)
			players[p].highCard = valMatch1;
		else
			players[p].highCard = valmatch2;
		
		//if two pair
		if (matching1 == 2 && matching2 == 2)
			players[p].handVal = twoPair;
		//if full house(3x and one pair)
		if (matching1 > 2 || matching2 > 2)
			players[p].handVal = fullHouse;
	}
}

//checks a players hand for a straight, flush or both
void CheckSF(int p)
{
	int fc = 1; //if all cards are the same suit
	int sc = 1; // if cards are in sequential order in value

	/*
	check for flush
	*/

	//iterate through the players hand one card at a time
	for (int i = 0; i < 4; i++)
	{
		// check if cards are int he same suit
		if (players[p].hand[i].suit == players[p].hand[i + 1].suit)
			fc++;
	}
	// give player flush hand if they get it
	if (fc == 5)
		players[p].handVal = flush;

	/*
	check for straight
	*/

	//iterate through the players hand one card at a time
	for (int i = 0; i < 4; i++)
	{
		// check if one card is greater then the previous card
		if (players[p].hand[i].face == players[p].hand[i + 1].face)
			sc++;

		// give player straight and val if they get it
		if (sc == 5)
		{
			// if player has flush give straight flush
			if (players[p].handVal == flush)
				players[p].handVal = straightFlush;

			//give just straight
			else
				players[p].handVal = straight;
		}
	}
}

//checks for all possible hands outcomes to get the best hand for each players hand
//gets the players highest card value
void GetHandValue(int p)
{
	//initalize hand
	players[p].handVal = 0;
	players[p].highCard = 0;

	//check for matching cards
	CheckMatch(p);

	// check for straights,flushes and straight flushes
	CheckSF(p);

	//assign last card as high card
	if (players[p].highCard == 0)
		players[p].highCard = players[p].hand[4].face;

	//print hand
	if (players[p].handVal != 0)
		printf("player %d has an %s\n", players[p].playNum, StringArray[players[p].handVal]);
}

//checks all players hand values and determines a winner
//acounts for ties using players high card values
//prints winner to the console
void Winner()
{
	Play one;
	Play two;

	/*
	sort players by their hands
	*/

	//iterate through each player (p)
	for (int pp = 0; pp < 4; pp++)
	{
		// compare all players hands
		for (int i = pp + 1; i < 4; i++)
		{
			if (players[pp].handVal > players[i].handVal)
			{
				one = players[pp];
				two = players[i];
				players[pp] = two;
				players[i] = one;
			}
		}
	}

	/*
	find winner
	*/

	//if there are no ties, the last player in the array wins
	if (players[3].handVal > players[2].handVal)           // needed?????
		printf("\nplayer %d wins!\n", players[3].playNum);

	// if tie break with high card
	else if (players[3].handVal == players[2].handVal)
	{
		// if p4 has high they win
		if (players[3].highCard > players[2].highCard)
			printf("\nplayer %d wins with %s\n", players[3].playNum, valueNameArray[players[3].highCard]);

		//if the high cards are a tie, determine how many other players have same high card
		else if (players[3].highCard == players[2].highCard)
		{
			//if players[2/1] have the same high card
			if (players[2].highCard == players[1].highCard)
			{
				//if all players have the same high card, they all win
				if (players[1].highCard == players[0].highCard)
					printf("\All players win!\n");

				//if only 3 players have the same high card, those 3 win
				else
					printf("\nplayers %d, %d and %d win!\n", players[3].playNum, players[2].playNum, players[1].playNum);
			}
			//if only 2 players have the same high card, both of them win
			else
				printf("\nplayers %d and %d both win!\n", players[3].playNum, players[2].playNum);
		}
	}
}