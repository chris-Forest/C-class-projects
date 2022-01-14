#include "vect.h"
#include <stdlib.h>
#include <stdio.h>

//show current vector size
int vectorSize(Vect* v)
{
	return v->size;
}

//get current vector value
//int Value(Vect* v, int index)
//{
//	//if data being accessed is outside 0 and the max
//	//return an error
//	if (index < 0 || index >= v->max)
//	{
//		fprintf(stderr, "Error: Attempt to access memory out-of-bounds");
//		exit(EXIT_FAILURE);
//	}
//
//	//otherwise return data
//	return v->data[index];
//}

//add to vector
void add(Vect* v, int val)
{
	/* When the first element is added
	   allocate space for 10 elements and set the capacity to 10*/
	if (v->size >= v->max) Grow(v, 2,0);
	v->data[v->size] = val; //add at end
	v->size++;
}

//when adding/inserting vectors
//increase mex vector capacity
void Grow(Vect* v, int scale, int vb)
{
	int newCapacity = v->max * scale;

	//Need to initialize
	if (!v->data || newCapacity < INITIAL_CAPACITY)
		newCapacity = INITIAL_CAPACITY;

	//display ne max size
	if (vb) printf("\nMax is now at %i\n", newCapacity);

	//allocate byte data
	int* newStore = (int*)malloc(sizeof(int) * newCapacity);

	//if no update to byte storage, error
	if (!newStore)
	{
		fprintf(stderr, "Error: Unable to reserve memory for growth.");
		exit(EXIT_FAILURE);
	}

	//Copy old store into new
	for (int i = 0; i < v->size; ++i)
		newStore[i] = v->data[i];

	//release old memory (Make sure you do this before you change the pointer)
	if (v->data) free(v->data); //Don't try to free a null pointer.

	//Point to new storage
	v->data = newStore;

	//set new capacity
	v->max = newCapacity;
}

//shink vector datacap and size when removing vectors vals from it
void Shrink(Vect* v, int scale, int vb)
{
	int newCap = v->max / scale;

	//set new max vector size
	if (newCap < v->size)
		newCap = v->size;	
	if (vb) printf("\nNew Max is %i\n", newCap);
	int* newData = (int*)malloc(sizeof(int) * newCap);

	//if no new (bytes)data allocated, respond with an error
	if (!newData)
	{
		fprintf(stderr, "fatile error");
		exit(EXIT_SUCCESS);
	}

	//allocate new bytes size
	for (int i = 0; i < v->size; i++)
	{
		newData[i] = v->data[i];
	}

	//free up data when done messing with it
	if (v->data) free(v->data);

	//set new max vector size
	//as well as new (bytes)data size
	v->data = newData;
	v->max = newCap;
}

//insect new vals to vector
void Insert(Vect* v, int val, int loc,  int vb)
{
	int temp;

	//if vector is full, grow to be able to add more values to it
	if (v->size >= v->max)Grow(v, 1, vb);

	int testr = v->data[loc];
	
	//add to vector
	if (loc > v->size || loc < 0)add(v,val);

	//otherwise add at specfic point
	else
	{
		//increase count size in vector
		v->size++;

		//show vectors in list
		for (int i = loc; i < v->size; i++)
		{
			temp = v->data[i];
			v->data[i] = val;
			val = temp;
		}
	}
}

//remove a value at a specfic vector point
void Remove(Vect* v, int val, int vb)
{
	int it;
	int vv = v->data[v->size - 1];
	val = val >= 0 ? val : v->size - 1;

	//search and find vector value to be removed
	for (int l = v->size - 1; l > val; l--)
	{
		it = v->data[l - 1];
		v->data[l - 1] = vv;
		vv = it;
	}

	//if removed vector causes vector size to have exccess data
	//shrink max size to a new max size
	v->size--;
	if (v->size < (double)(v->max * (3.0 / 4.0)))Shrink(v, 2, vb);
}

//find a value at a specfic vector point
int Find(Vect* v, int val)
{
	int c = 0;

	//search vector for a value
	for (int i = 0; (i < v->size && v->data[i] != val); i++)c = i + 1;

	//if data cant be found, return -1
	if (v->data[c] != val) return-1;

	//if found return successfuly search value
	return c;
}

//Displays the values of all elements in the vector
//If vector is empty it displays a message accordingly	
void vectorShow(Vect* v,int cc)
{
	//if no data in vector
	if (v->size <= 0) 
	{
		printf("Vector is Empty\n");
		return;
	}
	
	//if there is data in vector
	for (int i = 0; i < v->size; i++)
	{
		/*if (!(i & cc))
			printf("\n");  */  
		printf("%i ", v->data[i]);
	}
}

