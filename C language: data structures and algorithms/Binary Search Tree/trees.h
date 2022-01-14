#pragma once

// for storing employee info
typedef struct Employee
{
	int EmployeeId;
	char* fName;
	char* lName;
	int salary;
} Employee;

//node structure used to create
// a Binary Search Tree
struct node
{ 
	Employee key;
	struct node* left, * right;
};

typedef struct node node;

node* newNode(Employee item);
node* insertTreeID(node* startNode, Employee key); 
node* insertTreeSALARY(node* startNode, Employee key);
node* searchTree(node* root, int key);
void inOrder(node* root);
int countEqualOrHigher(node* startNode, int x);
int displayEqualOrHigher(node* startNode, int x);
void Displayemployee(node* root);