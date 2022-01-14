#pragma once
#include "Queue.h"

ptr billStackHead;  //points to top of stackfor the bills
int billStacksize;  //current number of bills in stack 
Vect Paidbill;      //acts as storeage for all bills that have been paid

addBills(CarNode cn);   //takes car info, adds service cost and move car to billing stack
displayBills();         //displays all info for all bills currenlty in the stack
trnsferFROMbillStack(); //takes reg numberfrom user and transfer to a total
unpaidTotal();          // find current unpaid service costs in queue
paidTotal();            // find current paid service costs in queue 