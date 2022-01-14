#include <stdlib.h>
#include <stdio.h>
#include "vect.h"

int main(int argc, char** argv)
{
	Vect v = { 0,0,NULL }; //You can use initializers to set initial state
	vectorShow(&v,stdout);
	printf("\n");

	/*for (int i = 0; i < 5; ++i)
		add(&v, i);*/

	add(&v, 1);  //0 postion
	add(&v, 2);  //1
	add(&v, 3);  //2
	add(&v, 4);
	add(&v, 5);  //4
	printf("vector values\n");
	vectorShow(&v,stdout);
	printf("\nNo. of Elements=%d\n", vectorSize(&v));

	Remove(&v, 2, stdout);
	printf("\nvector points removed");
	Remove(&v, 0, stdout);	
	printf("\nvector with removed value(s)\n");
	vectorShow(&v, stdout);
	printf("\nNo. of Elements=%d\n", vectorSize(&v));

	printf("\n");
	v.data[Find(&v,4)];
	printf("found val: %i", v.data[Find(&v, 4)]);
	//vectorShow(&v,4);

	printf("\n\nVectors inseted, set new max");
	Insert(&v, 12, 0, stdout);
	Insert(&v, 15, 0, stdout);
	printf("\nvector with inserted value(s)\n");
	vectorShow(&v, stdout);
	printf("\n");
	if (v.data) free(v.data);
	return EXIT_SUCCESS;
}