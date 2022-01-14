#pragma once
#include <stdio.h>
#include <string.h>

typedef enum{blue=1, brown, gray, green, hazel,red}eyecolor;
typedef struct
{
	char* name;
	eyecolor eyes;

}People;

People createPPL(char* Firstname, eyecolor eye);
People* findEyeColorf(People* data, eyecolor find);
People* reverse(People* data, eyecolor find);