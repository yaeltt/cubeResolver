using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static project.Enums;

namespace project
{
    public class CubeMatrixes
    {
        public const int N = 3;
        public eColors[,] Front { get; set; }
        public eColors[,] Back { get; set; }
        public eColors[,] Up { get; set; }
        public eColors[,] Down { get; set; }
        public eColors[,] Right { get; set; }
        public eColors[,] Left { get; set; }
        public eColors [][][,] bigMat { get; set; }
        public CubeMatrixes()
        {
            Front = new eColors[N,N];
            Back = new eColors[N,N];
            Up = new eColors[N,N];
            Down = new eColors[N,N];
            Right = new eColors[N,N];
            Left = new eColors[N,N];
            bigMat = new eColors[N][][,];

            Front[0,0] = eColors.blue;
            Front[0,1] = eColors.white;
            Front[0,2] = eColors.green;
            Front[1,0] = eColors.red;
            Front[1,1] = eColors.yellow;
            Front[1,2] = eColors.peach;
            Front[2,0] = eColors.perper;
            Front[2,1] = eColors.black;
            Front[2,2] = eColors.orange;

            Back[0, 0] = eColors.blue;
            Back[0, 1] = eColors.white;
            Back[0, 2] = eColors.green;
            Back[1, 0] = eColors.red;
            Back[1, 1] = eColors.yellow;
            Back[1, 2] = eColors.peach;
            Back[2, 0] = eColors.perper;
            Back[2, 1] = eColors.black;
            Back[2, 2] = eColors.orange;

            Right[0, 0] = eColors.blue;
            Right[0, 1] = eColors.white;
            Right[0, 2] = eColors.green;
            Right[1, 0] = eColors.red;
            Right[1, 1] = eColors.yellow;
            Right[1, 2] = eColors.peach;
            Right[2, 0] = eColors.perper;
            Right[2, 1] = eColors.black;
            Right[2, 2] = eColors.orange;

            Left[0, 0] = eColors.blue;
            Left[0, 1] = eColors.white;
            Left[0, 2] = eColors.green;
            Left[1, 0] = eColors.red;
            Left[1, 1] = eColors.yellow;
            Left[1, 2] = eColors.peach;
            Left[2, 0] = eColors.perper;
            Left[2, 1] = eColors.black;
            Left[2, 2] = eColors.orange;

            Up[0, 0] = eColors.blue;
            Up[0, 1] = eColors.white;
            Up[0, 2] = eColors.green;
            Up[1, 0] = eColors.red;
            Up[1, 1] = eColors.yellow;
            Up[1, 2] = eColors.peach;
            Up[2, 0] = eColors.perper;
            Up[2, 1] = eColors.black;
            Up[2, 2] = eColors.orange;

            Down[0, 0] = eColors.blue;
            Down[0, 1] = eColors.white;
            Down[0, 2] = eColors.green;
            Down[1, 0] = eColors.red;
            Down[1, 1] = eColors.yellow;
            Down[1, 2] = eColors.peach;
            Down[2, 0] = eColors.perper;
            Down[2, 1] = eColors.black;
            Down[2, 2] = eColors.orange;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(Front[i, j].ToString() + " ");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
                bigMat[i] = new eColors[4][,];
            for (int j = 0; j < 4; j++)
                       
                bigMat[0][j] = Up;
           
            bigMat[1][0] = Left;
            bigMat[1][1] = Front;
            bigMat[1][2] = Right;
            bigMat[1][3] = Back;
            for (int j = 0; j < 4; j++)

                bigMat[2][j] = Down;
            
        }


        //סיבוב מטריצה - מקבלת כיוון ומטריצה ומחזירה את המטריצה לאחר סיבוב לכיוון

        //פונקציה שמקבלת צד התחלה וכיוון
        //ומבצעת העברה של 4 שורות ממטריצה למטריצה
        //לפי ההתחלה והכיוון יקבע אילו מטריצות משתתפות

        public void TurnmatLeft(eColors[,] mat)
        {

            eColors[,] temp = new eColors[N,N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    temp[i,j]= mat[j, N - i - 1];
                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(temp[i, j].ToString() + " ");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void TurnLeft(int startMat, int line)
        {
            eColors[] temp = new eColors[N];
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
          
            if (line == 0)
                TurnmatLeft(Up);
            if (line == N - 1)
                TurnmatLeft(Down);
        
        }


       
    }

}
