#pragma once

typedef struct
{
	int regNum;
	float egnCapacity;
	char* Name;
	char* model;
	struct CarNode* next;

}CarNode;

typedef CarNode* pntr;
typedef struct
{
	CarNode* front;
	CarNode* back;
}queueCar;

CarNode* createNode(int regNumber, float eCapcity, char* fN, char* make);
void enQueue(queueCar* QC, int regNumber, float eCapcity, char* fN, char* make);
void deltQueue(queueCar* QC);
void del(queueCar* QC, int regNumber);
int queueSize(queueCar* QC);
void searchQueue(queueCar* QC, float eCapacity);
void nextInLine(queueCar* QC);
//pntr nextInLine();
void queuePrint(CarNode* car);
void displayAll(queueCar* QC);
void menu();