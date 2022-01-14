#pragma once
#ifndef vectors
#define vectors
#include <stdio.h>

//define capacity????
#define INITIAL_CAPACITY 10
typedef struct Vect Vect;

struct Vect
{
	int max; // total size for memory
	int size; //Current number of ints stored. size always <= capacity
	int* data; //Pointer to stored array on heap
};

int vectorSize(Vect* v);
//int vectorCapacity(Vect* v);
//int Value(Vect* v, int index);
void add(Vect* v, int val);
void Grow(Vect* v, int scale, int vb);
void Shrink(Vect* v, int scale, int vb);
void Insert(Vect* v, int val, int loc, int vb);
void Remove(Vect* v, int val, int vb);
int Find(Vect* v,int val);
void vectorShow(Vect* v,int cc);
#endif // !vectors
