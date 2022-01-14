#include <stdio.h>
#include <stdlib.h>
#include "trees.h"

/* This file contains functions to create and access
   a Binary Search Tree (BST) The node structure is defined 
   in trees.h.
   All the functions included here (except newNode) make use of recursion 
   */

// newNode: A utility function to create a new BST node
node* newNode(Employee item) //Employee not int
{
	node* temp = (struct node*)malloc(sizeof(node));
	temp->key = item;
	temp->left = temp->right = NULL;
	return temp;
}

/* InsertTreeID: A utility function to insert a new node with given key in BST
   Parameters:
   We start with a given node. The initial caller of this function will pass
   the root of the tree as the node parameter
   The function returns the modified tree
*/
node* insertTreeID(node* startNode, Employee key)// employee???
{
	/* If the tree is empty, return a new node */
	if (startNode == NULL) 
		return newNode(key);

	/* Otherwise, do recursion down the tree */
	if (key.EmployeeId < startNode->key.EmployeeId)
		startNode->left = insertTreeID(startNode->left, key);
	else if (key.EmployeeId > startNode->key.EmployeeId)
		startNode->right = insertTreeID(startNode->right, key);

	/* return the (unchanged) node pointer */
	return startNode;
}

/* InsertTreeSalary: A utility function to insert a new node with given key in BST
   Parameters:
   We start with a given node. The initial caller of this function will pass
   the root of the tree as the node parameter
   The function returns the modified tree
*/
node* insertTreeSALARY(node* startNode, Employee key)
{
	/* If the tree is empty, return a new node */
	if (startNode == NULL) 
		return newNode(key);

	/* Otherwise,do recursion down the tree */
	if (key.salary < startNode->key.salary)
		startNode->left = insertTreeSALARY(startNode->left, key);
	else if (key.salary > startNode->key.salary)
		startNode->right = insertTreeSALARY(startNode->right, key);

	/* return the (unchanged) node pointer */
	return startNode;
}

/*searchTree: function to search a given key in a given BST
  Parameters: root: The node where the search starts
              key:  The value we are searching for
  returns a pointer to the node containing the value (if found)
  If the value is not found in the tree, the function returns NULL
*/
node* searchTree(node* root, int key)
{
	// Base Cases: root is null or key is present at root 
	if (root == NULL || root->key.EmployeeId == key)
		return root;

	// Key is smaller than root's key id- search left subtree
	if (key < root->key.EmployeeId)
		return searchTree(root->left, key);
	//else?
	// Key is greater than root's key id- search right subtree
	return searchTree(root->right, key);
}

//display Employee info
void Displayemployee(node* root)
{
	printf("Employee ID: %i\n", root->key.EmployeeId);
	printf("First name: %s\n", root->key.fName);
	printf("Last name: %s\n", root->key.lName);
	printf("Employee salary: %i\n", root->key.salary);
}

// A utility function to perform in-order traversal of BST 
void inOrder(node* root)
{
	if (root != NULL)
	{
		inOrder(root->left);
		printf("Employee ID: %i\n", root->key.EmployeeId);
		printf("First name: %s\n", root->key.fName);
		printf("Last name: %s\n", root->key.lName);
		printf("Employee salary: %i\n\n", root->key.salary);
		inOrder(root->right);
	}
}

//Given a salary amount, it counts the number of persons earning that salary or higher.
int countEqualOrHigher(node* startNode,int x)
{
	int counter = 0;
	if (startNode == NULL)
		return 0;

	if (startNode->key.salary < x)
		counter = countEqualOrHigher(startNode->right, x);

	if (startNode->key.salary >= x)
		counter = 1 + countEqualOrHigher(startNode->left,x) + countEqualOrHigher(startNode->right,x);
	
	return counter;
}

//Given a salary amount,displays all persons earning that salary or higher
int displayEqualOrHigher(node* startNode, int x)
{
	int addr = 0;

	if (startNode == NULL)
		return 0;

	if (startNode->key.salary < x)
		addr = displayEqualOrHigher(startNode->right, x);

	if (startNode->key.salary >= x)
	{ 
		addr = displayEqualOrHigher(startNode->left, x) + displayEqualOrHigher(startNode->right, x);
		printf("Employee ID: %i\n", startNode->key.EmployeeId);
		printf("First name: %s\n",startNode->key.fName);
		printf("Last name: %s\n", startNode->key.lName);
		printf("Employee salary: %i\n\n", startNode->key.salary);
	}
}