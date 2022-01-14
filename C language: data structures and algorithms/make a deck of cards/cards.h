#pragma once
#ifndef deckOfCards
#define deckOfCards

typedef enum { Clubs, Diamonds, Hearts, Spades }Suit;  // These strings will represent the suit
typedef enum { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }Face;

//A structure name Card that contains two members, one for each of the above enumerations
typedef struct
{
    Suit suit;
    Face face;

}Card;

/* 4. A function (GetName) that accepts a Card and prints out the corresponding string for its name. For
example, it should returns something like ”Ace of Spades”....use a switch
statement that lists all the enumerated possibilities and then concatenate (strcat) or format (sprintf)
the results. */
//void GetCards(Suit cS, Face cV, Card* C, char Suit[20], char Face[20]);
char* getcards(Card c);

void printCards();
#endif // !deckOfCards