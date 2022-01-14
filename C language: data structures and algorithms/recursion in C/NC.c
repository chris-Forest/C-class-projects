#include "NC.h"
#include <stdio.h>
#include <string.h>
#include <stdlib.h>

//method to make people and eyecolors
//and retun their data
People createPPL(char* Firstname, eyecolor eye)
{
	People ppl;
	ppl.name = Firstname;
	ppl.eyes = eye;
	return ppl;
}

//search people which desired eye color
//and show people who have searched eye color
People* findEyeColorf(People* data, eyecolor find)
{
	//if found eye color show the names
	if (data->eyes == find)
	{
		printf("%s \n", data->name); 
	}

	//check for more then one person for the search eye color
	if ((data + 1)->eyes < 0)
		return data;
	findEyeColorf((data + 1), find);
}

//do same as above but in reverse order
People* reverse(People* data, eyecolor find)
{
	//check for more then one person for the search eye color
	if ((data + 1)->eyes < 0)
		return data;
	reverse((data + 1), find);

	//if found eye color show the names
	if (data->eyes == find)
	{
		printf("%s \n", data->name);
	}	
}