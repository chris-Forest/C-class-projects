#include <stdlib.h>
#include <stdio.h>
#include <malloc.h>

int main(int argc, char** argv)
{
	int* array;
	int sum = 0;
	array = (int*)malloc(argc * sizeof(int));//allocate a set size of memmory

	printf("contents of array: \n");
	/* this *(array+c) is used to access the value stored at the address*/
	for (int c = 1; c < argc; c++)
	{
		//convert adressPoint in arguments to an int
		//display the number and add it to total sum
		*(array + c) = atoi(argv[c]);
		printf("%d\n", *(array + c));
		sum += *(array + c);
	}

	printf("\n");
	printf("sum of array: %d",sum);
	free(array);
}

//void main(int argc, char** argv)
//{
//    int i, n, sum = 0;
//    int* a;
//
//    printf("Enter the size of array: ");
//    scanf_s("%d", &n);
//
//    a = (int*)malloc(n * sizeof(int));
//
//    printf("\n");
//    printf("Enter Elements of the List \n");
//    for (i = 0; i < n; i++)
//    {
//        scanf_s("%d", a + i);//*(a+i)?
//    }
//
//    /*  Compute the sum of all elements in the given array */
//
//    for (i = 0; i < n; i++)
//    {
//        sum = sum + *(a + i);
//        /* this *(a+i) is used to access the value stored at the address*/
//    }
//
//    printf("\n");
//    printf("Sum of all elements in array = %d\n", sum);
//    return 0;
//}