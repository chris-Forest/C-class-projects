#pragma once

void empty();// prevtnt infinite loops if needed if strings are inputed instead of numbers

//store all custiomer inffo in struct
typedef struct CarNode
{
	int regNum;
	float egnCapacity;
	char* Name;
	char* nameL;
	char* model;
	char* date;
	float serviceCost;
	struct CarNode* next;

}CarNode;

typedef CarNode* ptr;//define pointer to struct
ptr QueueHeadWait;   //last item to be added to queue
int QueueSizeWait;   //total # of cars in queue

void addQueue();     // add above struct itams to queue
void deleteQueue();  // remove an item from the queue that was in service queue
ptr nextInLine();    // next car to be serviced on from addqueue(waitqueue)
void queuePrint();   // display all in addqueue
void displayOne(ptr info,int servCost); //display info for one car

#define INITIAL_CAPACITY 10

// for service queue
typedef struct Vect
{
	int max; // total size for memory
	int size; //Current number of ints stored. size always <= capacity
	ptr data; //Pointer to stored array on heap
	
}Vect;

Vect serviceQ; //will hold service queue

void Grow(Vect* v, int scale);  //Increase size by scale factor
void Shrink(Vect* v, int scale);//Decrease size by scale factor
void TransferTOserviceQ();      //take car from addqueue to servicequeue
void TransferFROMserviceQ();    // takes car from service queue to billstack
void DisplayserviceQ();         // display all in service queue