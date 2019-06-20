/*Program Code*/

#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<string.h>

void main()
{
float tx,exp=0.0;   //declaration of variables used
int z,k,bty,c,ch,count=0;
char un[10],pwd[5];

gotoxy(30,10);      //module for security password check
printf("Username:");
gets(un);
gotoxy(30,12);
printf("Password:");
gets(pwd);  //end of for loop

FILE *fp, *ft ;
char another, choice ;

struct emp           //creation of employee structure
{
char name[40] ;
int age ;
float bs ;
} ; 
struct emp e ;
char empname[40] ;
long int recsize ;
fp = fopen ( "EMP.DAT", "rb+" ) ; //opening file for data storage
if ( fp == NULL )
{
fp = fopen ( "EMP.DAT", "wb+" ) ;
if ( fp == NULL )
{
puts ( "Cannot Open File!!!" ) ;
exit(0) ;
}//end of inner if
}//end of outer if
recsize = sizeof ( e ) ;
while ( 1 )
{
clrscr( ) ;
gotoxy ( 27, 3 ) ;        //code for main menu screen
puts("EMPLOYEE DATABASE SYSTEM");
gotoxy ( 30, 5 ) ;
printf("Welcome %s!",un);
gotoxy ( 30, 7 ) ;
printf ( "1. Add Records" ) ;
gotoxy ( 30, 9 ) ;
printf ( "2. List Records" ) ;
gotoxy ( 30, 11 ) ;
printf ( "3. Modify Records" ) ;
gotoxy ( 30, 13 ) ;
printf ( "4. Delete Records" ) ;
gotoxy ( 30, 15 ) ;
printf ( "5. Salary Details" ) ;
gotoxy ( 30, 17 ) ;
printf ( "6. Misc. Details" ) ;
gotoxy ( 30, 19 ) ;
printf ( "7. M.I.S. Information" ) ;
gotoxy ( 30, 21 ) ;
printf ( "8. Exit" ) ;
gotoxy ( 30, 23 ) ;
printf ( "Your choice....:" ) ;
fflush ( stdin ) ;
choice = getche( ) ;
switch ( choice )
{


case '1' :        //module for entering records
fseek ( fp, 0 , SEEK_END ) ;
another = 'y' ;
while ( another == 'y' )
{
clrscr();
printf ( "\nEnter Employee's Name, Age & Basic Salary: " ) ;
scanf ( "%s %d %f", e.name, &e.age,&e.bs ) ;
fwrite ( &e, recsize, 1, fp ) ;
printf ( "\nAdd Another Record ?(y/n): " ) ;
fflush ( stdin ) ;
another = getche( ) ;
}//end of while
break ;


case '2' :               //module for viewing all records at once
clrscr();
rewind ( fp ) ;
while ( fread ( &e, recsize, 1, fp ) == 1 )
printf ( "\n\tName:%s \t Age:%d  \tSalary:Rs %f", e.name, e.age, e.bs ) ;
getch();
break ;


case '3' :              //module for modifying records
clrscr();
another = 'y' ;
while ( another == 'y' )
{
printf ( "\nWhich Employee to Modify? Enter His Name :" ) ;
scanf ( "%s", empname ) ;
rewind ( fp ) ;
while ( fread ( &e, recsize, 1, fp ) == 1 )
{
if ( strcmp ( e.name, empname ) == 0 )
{
printf ( "\nEnter New Name, Age,& Basic Salary :" ) ;
scanf ( "%s %d %f", e.name, &e.age,&e.bs ) ;
fseek ( fp, - recsize, SEEK_CUR ) ;
fwrite ( &e, recsize, 1, fp ) ;
break ;
}//end of if
}//end of while
printf ( "\nModify Another Record ?(y/n): " ) ;
fflush ( stdin ) ;
another = getche( ) ;
}//end of while
break ;


case '4' :                  //module to delete old records
clrscr();
another = 'y' ;
while ( another == 'y' )
{
printf ( "\nEnter Employee's Name to be Deleted : " ) ;
scanf ( "%s", empname ) ;
ft = fopen ( "TEMP.DAT", "wb" ) ;
rewind ( fp ) ;
while ( fread ( &e, recsize, 1, fp ) == 1 )
{
if ( strcmp ( e.name, empname ) != 0 )
fwrite ( &e, recsize, 1, ft ) ;
}//end of while
fclose ( fp ) ;
fclose ( ft ) ;
remove ( "EMP.DAT" ) ;
rename ( "TEMP.DAT", "EMP.DAT" ) ;
fp = fopen ( "EMP.DAT", "rb+" ) ;
printf ( "Delete Another Record ?(Y/N): " ) ;
fflush ( stdin ) ;
another = getche( ) ;
}//end of while
break ;


case '5':               //module for salary details 
clrscr();               //based on data calculations
gotoxy(30,12);
printf ( "Enter Employee's Name :" ) ;
scanf ( "%s", empname ) ;
rewind ( fp ) ;
while ( fread ( &e, recsize, 1, fp ) == 1 )
{
if ( strcmp ( e.name, empname ) == 0 )
{  
clrscr();
gotoxy(30,10);                //code for sub menu screen
printf("EMPLOYEE SALARY");
gotoxy(30,12);
printf("1. Basic Pay");
gotoxy(30,14);
printf("2. Tax Payable");
gotoxy(30,16);
printf("3. Net Pay");
gotoxy(30,18);
printf("Enter Your Choice:");
scanf("%d",&bty);

switch(bty)
{
case 1: clrscr();
gotoxy ( 30, 8 ) ;
printf("Basic Pay=Rs. %f",e.bs);
getch();
break;
case 2:
clrscr();
gotoxy ( 30, 8 ) ;
printf("Basic Pay=Rs. %f",e.bs);
if(e.bs>100000.0)
{
tx=.25*(e.bs-100000);
gotoxy(30,10);
printf("Tax Applicable=Rs. %f",tx);
}//end of if
else
printf("No Tax Applicable");
getch();
break;
case 3:
clrscr();
gotoxy(30,6);
printf("Employee: %s",e.name);
gotoxy ( 30, 8 ) ;
printf("Basic Pay=Rs. %f",e.bs);
gotoxy(30,10);
if(e.bs>100000.0)
{
tx=.25*(e.bs-100000);
printf("Tax Applicable=Rs. %f",tx);
gotoxy(30,12);
printf("Net Pay=Rs. %f",e.bs-tx);
}//end of if
else
printf("Net Pay=Rs. %f",e.bs);
getch();
break;
}//end of switch
}//end of if
}//end of while
break;


case '6':                //module for other miscellaneous details
clrscr();                //based on data manipulation
gotoxy(30,10);
printf ( "Enter Employee's Name :" ) ; 
scanf ( "%s", empname ) ;
rewind ( fp ) ;
while ( fread ( &e, recsize, 1, fp ) == 1 )
{
if ( strcmp ( e.name, empname ) == 0 )
{
clrscr();
gotoxy(30,10);                //code for sub menu screen
printf("MISCELLANEOUS DETAILS");
gotoxy(30,12);
printf("1. Years of Job Left");
gotoxy(30,14);
printf("2. Work Experience Gained");
gotoxy(30,16);
printf("3. Salary, after 6th Pay Commission");
gotoxy(30,18);
printf("4. Perks Available");
gotoxy(30,20);
printf("Enter Your Choice:");
scanf("%d",&c);
switch(c)
{
case 1:
clrscr();
gotoxy(20,10);
printf("Mr. %s,You have %d years of Job left!",e.name,60-e.age);
getch();
break;

case 2:   clrscr(); gotoxy(3,10);
printf("Mr. %s,You have gained %d years of Work Experience in This Organisation!",e.name,e.age-20);
getch();
break;

case 3:
clrscr();
gotoxy(30,8);
printf("After Sixth Pay Commission");
gotoxy(30,10);
printf("Old Salary:Rs. %f",e.bs);
gotoxy(30,12);
printf("Incremented Salary:Rs. %f",e.bs*1.75);
getch();
break;

case 4:
clrscr();
printf("\nMr. %s , You are entitled for ",e.name);
printf("\n\nFirst/Second(for E1-E4) AC Class in trains, \nfor the Employee & dependents while traveling in LTC(Home/Nationwide)");
printf("\n\nFirst AC Class in trains or Flight(for E6-E9, with prior permissions) \nwhile traveling for Official Purpose");
printf("\n\nQuarters available inside Company Campus or HRA given if quarter\nis not available or in case he resides within 8Km range in his own house");
printf("\n\nRs.1600/Rs. 2500(for E5-E9) per month as Conveyance Allowance");
printf("\n\nFree Medical Facility");
getch();
break;
}//end of switch
}//end of if
}//end of while
break;


case '7':               //module for MIS Informations based on 
clrscr();               //data processing
gotoxy(30,15);
printf("M.I.S. INFORMATION");
gotoxy(30,17);
printf("1.Total Expenditure in a year");
gotoxy(30,19);
printf("2.No. of Retiring Employees");
gotoxy(30,21);
printf("Your Choice...:");
scanf("%d",&k);
switch(k)
{
case 1:
clrscr();
gotoxy(30,15);
rewind ( fp ) ;
while ( fread ( &e, recsize, 1, fp ) == 1 )
{exp+=e.bs;}
printf("Total Expenditure= Rs.%f",exp);
getch();
break;

case 2:
clrscr();
gotoxy(30,15);
rewind ( fp ) ;
while ( fread ( &e, recsize, 1, fp ) == 1 )
{
if(e.age==59)
{
count=count+1;
}//end of if
}//end of while
printf("No. of Retiring Employee =%d",count);
getch();
break;

}//end of switch
break;


case '8' :              //module for closing the application
fclose ( fp ) ;
exit(0) ;


}//end of switch
}//end of while
}// end of main

