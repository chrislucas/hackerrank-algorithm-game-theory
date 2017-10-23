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
    public static class IO
    {
        public static Func<int> ReadInt = () => int.Parse(Console.ReadLine());
        public static Func<char, int[]> ReadInts = (char del) => ReadLineSplit(del).Select(x => int.Parse(x)).ToArray();
        public static Func<char, string[]> ReadLineSplit = (char del) => Console.ReadLine().Split(del);
        public delegate void Printfln(string format, params object[] args);
        public delegate void Printf(string format, params object[] args);
        public delegate void Println(params object[] args);
        public static Printfln printfln = (string format, object[] args) => Console.WriteLine(format, args);
        public static Println println = (object[] args) => Console.WriteLine(args);
        public static Printf printf = (string format, object[] args) => Console.Write(format, args);
    }

    public class Position
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString() => $"({x}),({y})";
    }

    public class Program
    {
        static Position[] mov = {
             new Position(-2,1)
            ,new Position(-2,-1)
            ,new Position(1,-2)
            ,new Position(-1,-2)
        };

        const int dim = 16;
        static int[,] matrix;

        static Position GetPosition(int idx, int currentX, int currentY)
        {
            Position future = mov[idx];
            int x = currentX + future.x;
            int y = currentY + future.y;
            if (x >= dim || x < 1 || y >= dim || y < 1)
                return null;
            return new Position(x, y);
        }


        static int run(int x, int y)
        {
            if (matrix[x, y] != 0)
                return matrix[x, y];
            int player = 2;
            for (int i=0; i<4; i++)
            {
                Position p = GetPosition(i, x, y);
                if (p != null && run(p.x, p.y) == 2)
                {
                    player = 1;
                }   
            }
            matrix[x, y] = player;
            return player;
        }

        static bool run2(int x, int y)
        {
            bool s = false;
            for (int i = 0; i < 4; i++)
            {
                Position p = GetPosition(i, x, y);
                if (p != null && ! run2(p.x, p.y))
                    s = true;
            }
            return s;
        }

        static void runDP(int x, int y)
        {
            bool f = false;
            for (int i = 0; i < 4; i++)
            {
                if(GetPosition(i, x, y) != null && matrix[x, y] == 0)
                {
                    f = true;
                    break;
                }
            }
        }

        static void showMatrix()
        {
            IO.printfln("{0}","");
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    IO.printf("{0}", matrix[i, j]);
                }
                IO.printfln("{0}", "");
            }
        }

        static void Main(string[] args)
        {
            int cases = IO.ReadInt();
            while(cases-->0)
            {
                matrix = new int[dim, dim];
                int [] values = IO.ReadInts(' ');
                //printf("{0}", run2(values[0], values[1]) ? "First" : "Second");
                IO.printf("{0}\n", run(values[0], values[1]) == 1 ? "First" : "Second");
                //showMatrix();
            }
        }
    }
}
