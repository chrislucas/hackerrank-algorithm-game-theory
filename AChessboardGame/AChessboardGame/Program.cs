using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 *  https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays
 */

namespace AChessboardGame
{

    public class Position
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"({x}),({y})";
        }
    }

    public class Program
    {
        static Func<int> ReadInt = () => int.Parse(Console.ReadLine());
        static Func<char, int[]> ReadInts = (char del) => ReadLineSplit(del).Select(x => int.Parse(x)).ToArray();
        static Func<char, string[]> ReadLineSplit = (char del) => Console.ReadLine().Split(del);
        public delegate void Println(string format, params object[] args);
        public static Println println = (string format, object[] args) => Console.WriteLine(format, args);

        static Position[] mov = {
             new Position(-2,1)
            ,new Position(-2,-1)
            ,new Position(1,-2)
            ,new Position(-1,-2)
        };


        static int[,] matrix = new int[15, 15];

        static Position GetPosition(int idx, int currentX, int currentY)
        {
            Position future = mov[idx];
            int x = currentX + future.x;
            int y = currentY + future.y;
            if (x > 14 || x < 0 || y > 14 || y < 0)
                return null;
            return new Position(x, y);
        }


        static void run(int x, int y, int player)
        {
            if (matrix[x, y] > 0)
                return;
            for (int i=0; i<4; i++)
            {
                Position p = GetPosition(i, x, y);
                if (p != null)
                {
                    run(p.x, p.y, player == 1 ? 2 : 1);
                }   
            }
            matrix[x, y] = player;
            //println("{0}", player == 1 ? "First" : "Second");
            return;
        }

        static void showMatrix()
        {
            println("");
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                println("");
            }
        }

        static void Main(string[] args)
        {
            int cases = ReadInt();
            while(cases-->0)
            {
                int [] values = ReadInts(' ');
                run(values[0], values[1], 1);
                showMatrix();
            }
        }
    }
}
