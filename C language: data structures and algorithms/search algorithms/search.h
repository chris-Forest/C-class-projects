#pragma once

typedef struct employee
{
	int EmployeeId;
	char* fName;
	char* lName;
} Employee;

typedef struct result
{
	int index;
	int comp;
}result;

 Employee employees[20];

result SeqSearch(int Arr[], int size, int val);
result binarySearch(int arr[], int n, int val);