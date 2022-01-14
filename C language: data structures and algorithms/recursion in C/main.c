#include "NC.h"
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
	eyecolor search = red;//default search arg

	//manual arry for names and eye color
	People person[] =
	{
		createPPL("bert",red),createPPL("morty",hazel),
		createPPL("doc",blue),createPPL("doug",green),
		createPPL("chester",brown),createPPL("rex",blue),
		createPPL("sarge",gray),createPPL("Dick",brown),
		createPPL("rick",green),createPPL("lucy",red),NULL
	};
	
	People* pl;
	//given argument eye color
	//set the search color to that arg color
	//and look for people with that eye color
	for(int i = 0; i < argc; i++)
	{
		//run if any of the colors is the search term//(below if not needed//can use if's inside this one)
		if (strcmp(argv[i], "red") == 0 || strcmp(argv[i], "blue") == 0 || strcmp(argv[i], "brown") == 0 || strcmp(argv[i], "gray") == 0 || strcmp(argv[i], "green") == 0 || strcmp(argv[i], "hazel") == 0)
		{
			//if color is search term set eyecolor search varible to color
			if (strcmp(argv[i], "red") == 0) { search = red; }
			if (strcmp(argv[i], "blue") == 0) { search = blue; }
			if (strcmp(argv[i], "brown") == 0) { search = brown; }
			if (strcmp(argv[i], "gray") == 0) { search = gray; }
			if (strcmp(argv[i], "green") == 0) { search = green; }
			if (strcmp(argv[i], "hazel") == 0) { search = hazel; }
		
		}
		if (person[i].name == NULL)
			return argc;
	}

	printf("People with searched eye color:\n");
	findEyeColorf(person, search);
	printf("\nin reverse:\n");
	reverse(person, search);
}