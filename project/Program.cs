using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Program
    {
        const int N = 3;

        public static void TurnMatLeft(int[,] mat)
        {
            int[,] temp = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    temp[j, N - i - 1] = mat[i, j];
                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    mat[i, j] =temp[i,j];
                }
            }

        }
        public static void TurnMatRight(int[,] mat)
        {
            int[,] temp = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    temp[i, j] = mat[j, N - i - 1];
                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    mat[i, j] = temp[i, j];
                }
            }

        }
        public static void TurnLeftInt(int startMat, int line, int[][][,] bigMat)
        {
            //הפונקציה מקבלת מטריצה התחלתית שורה במטריצה לסיבוב ואת המטריצה הגדולה שמכילה את כל מטריצות הקוביה
            // הפונקציה תסובב את השורה 
            int[] temp = new int[N];
            for (int j = 0; j < N; j++)
                temp[j] = bigMat[1][startMat][line, j];
            int k = startMat, after;
            for (int x = 0; x < 3; x++)
            {
                after = k + 1;
                if (after == 4)
                    after = 0;
                for (int j = 0; j < N; j++)
                    bigMat[1][k][line, j] = bigMat[1][after][line, j];

                k++;
                if (k == 4)
                    k = 0;
            }
            int before = startMat - 1;
            if (before == -1)
                before = 3;
            for (int j = 0; j < N; j++)
                bigMat[1][before][line, j] = temp[j];

         TurnMatLeft(bigMat[0][startMat]);

        }

        public static void TurnRightInt(int startMat, int line, int[][][,] bigMat)
        {
            //הפונקציה מקבלת מטריצה התחלתית שורה במטריצה לסיבוב ואת המטריצה הגדולה שמכילה את כל מטריצות הקוביה
            // הפונקציה תסובב את השורה 
            int[] temp = new int[N];
            for (int j = 0; j < N; j++)
                temp[j] = bigMat[1][startMat][line, j];
            int k = startMat, before;
            for (int x = 0; x < 3; x++)
            {
               
                before = k - 1;
                if (before == -1)
                    before = 3;
                for (int j = 0; j < N; j++)
                    bigMat[1][k][line, j] = bigMat[1][before][line, j];
                k--;
                if (k == -1)
                    k = 3;
            }
            int after = startMat +1;
            if (after == -1)
                after = 3;
            for (int j = 0; j < N; j++)
                bigMat[1][after][line, j] = temp[j];

            TurnMatRight(bigMat[0][startMat]);

        }
        public static void Main(string[] args)
        {
            CubeMatrixes myCube = new CubeMatrixes();
            int[,] up = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] left = { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 } };
            int[,] front = { { 3, 6, 9 }, { 12, 15, 18 }, { 21, 24, 27 } };
            int[,] right = { { 4, 8, 12 }, { 16, 20, 24 }, { 28, 32, 36 } };
            int[,] back = { { 5, 10, 15 }, { 20, 25, 30 }, { 35, 40, 45 } };
            int[,] down = { { 6, 12, 18 }, { 24, 30, 36 }, { 42, 48, 54 } };
            int[][][,] bigMat= new int[3][][,];
            for (int i = 0; i < 3; i++)
                bigMat[i] = new int[4][,];
            for (int j = 0; j < 4; j++)

                bigMat[0][j] = up;

            bigMat[1][0] = left;
            bigMat[1][1] = front;
            bigMat[1][2] = right;
            bigMat[1][3] =back;
            for (int j = 0; j < 4; j++)
                bigMat[2][j] = down;

            #region print before
            Console.WriteLine("up");
            for (int x = 0; x < N; x++)
            {  
                for (int j = 0; j < N; j++)
                {
                    Console.Write(bigMat[0][1][x, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("left");
            for (int i = 0; i < N; i++)
            {   
                Console.Write(bigMat[1][0][0, i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("front");
          
            for (int i = 0; i < N; i++)
            {
                Console.Write(bigMat[1][1][0, i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("right");
            
            for (int i = 0; i < N; i++)
            {  
                Console.Write(bigMat[1][2][0, i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("back");
            for (int i = 0; i < N; i++)
            {
                Console.Write(bigMat[1][3][0, i]+" ");
            }
            Console.WriteLine();
            #endregion
            TurnRightInt(1,0, bigMat);
            #region print after
            Console.WriteLine("up");
            for (int x = 0; x < N; x++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(bigMat[0][1][x, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("left");
            for (int i = 0; i < N; i++)
            {
                Console.Write(bigMat[1][0][0, i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("front");

            for (int i = 0; i < N; i++)
            {
                Console.Write(bigMat[1][1][0, i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("right");

            for (int i = 0; i < N; i++)
            {
                Console.Write(bigMat[1][2][0, i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("back");
            for (int i = 0; i < N; i++)
            {
                Console.Write(bigMat[1][3][0, i] + " ");
            }
            Console.WriteLine();
            #endregion
            Console.ReadLine();
        }

    }
    
}
