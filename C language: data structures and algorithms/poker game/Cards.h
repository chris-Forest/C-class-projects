#pragma once


typedef enum { Clubs=1, Diamonds, Hearts, Spades }Suit;  // These strings will represent the suit
typedef enum { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }Face;

//A structure name Card that contains two members, one for each of the above enumerations
typedef struct
{
    Suit suit;
    Face face;
    char* CardSuit;
    char* CardValue;
}Card;

Card Deck[52]; //the deck of cards

void makeDeck();
void Shuffle();
void print();

static const char suitNameArray[5][9] = { "", "Hearts","Diamonds","Clubs","Spades" }; //this array contains strings to use for printing the suit values

static const char valueNameArray[15][6] = { "","","Two","Three","Four","Five","Six",					//this array contains strings to use for printing the card values
                                            "Seven","Eight","Nine","Ten","Jack","Queen","King","Ace" }; //empty strings are to line up the index with enum values

