using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquareSiameseMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            /*The Siamese method, or De la Loubère method, 
             * is a simple method to construct any size of n-odd magic squares
             * (i.e. number squares in which the sums of all rows, columns and diagonals are identical).
             */

            Console.WriteLine("How many rows do you want to include in your magic square? ");
            int NoofRows = Convert.ToInt32(Console.ReadLine());

            //Siamese method works only for odd numbers, check the number entered
            check: if (NoofRows % 2 == 0)
            {
                Console.WriteLine("***Siamese method only works for odd no of rows and columns***");
                Console.WriteLine("Please enter an odd number");
                NoofRows = Convert.ToInt32(Console.ReadLine());
 
                goto check;
            }

            int[,] a=new int[NoofRows,NoofRows];
            int ctr=1,i=0,j=0;

            //There are n^2 elements in the magic square
            //A simple arithmetic progression is chosen.(1,2,3,...)
            while(ctr<=(NoofRows*NoofRows))
            {
                //Starting from the central box of the first row with the number 1 
                //(or the first number of any arithmetic progression), the fundamental 
                //movement for filling the boxes is diagonally up and right (↗), one step at a time. 
                //When a move would leave the square, it is wrapped around to the last row or first 
                //column, respectively.If a filled box is encountered, one moves vertically down
                //one box (↓) instead, then continuing as before.
                if (ctr == 1)
                {
                    j = (NoofRows / 2);
                    a[i, j] = ctr;
                    ctr++;
                }
                else
                {
                    i = i - 1; j = j + 1;
                    if(i==-1 && j==NoofRows)
                    {
                        i = i + 1 + 1; j = j - 1;
                    }
                    if(i<0)
                    {
                        i = NoofRows-1;
                    }
                    if(j>=NoofRows)
                    {
                        j = 0;
                    }
                    if (a[i,j]!=0)
                    {
                        i = i + 1 + 1; j = j - 1;
                        a[i, j] = ctr;
                        ctr++;
                    }
                    else
                    {
                        a[i, j] = ctr;
                        ctr++;
                    }
                }
            }

            //Print the resulting magic square
            Console.WriteLine("The Magic square for {0} x {1} is: \n", NoofRows.ToString(), NoofRows.ToString());
            for(int x=0; x<NoofRows;x++)
            {
                StringBuilder strRow = new StringBuilder();

                for(int y=0; y<NoofRows; y++)
                {
                    strRow.Append( a[x, y].ToString ());
                    strRow.Append(" ");
                }
                Console.WriteLine(strRow.ToString());
                Console.WriteLine("\n");
            }
            Console.WriteLine("\nPress any key to continue....");
            Console.ReadKey();
        }
    }
}

