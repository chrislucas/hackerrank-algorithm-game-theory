using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * https://www.hackerrank.com/challenges/a-chessboard-game-1
 */

namespace AChessboardGame.AnotherSolution
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

    public class IntPair
    {
        public int X { get; set; }
        public int Y { get; set; }
        public IntPair(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override bool Equals(object obj) => X == ((IntPair)obj).X && Y == ((IntPair)obj).Y ;
        public override int GetHashCode() => X + Y;
        public override string ToString() => $"P({X},{Y})";
    }


   

    class DictSolution
    {

        const int dim = 16;

        static IntPair[] mov = {
                 new IntPair(-2,1)
                ,new IntPair(-2,-1)
                ,new IntPair(1,-2)
                ,new IntPair(-1,-2)
        };

        static Dictionary<IntPair, bool> dp = new Dictionary<IntPair, bool>();

        static IntPair GetPosition(int idx, int currentX, int currentY)
        {
            IntPair future = mov[idx];
            int x = currentX + future.X;
            int y = currentY + future.Y;
            if (x > dim || x < 1 || y > dim || y < 1)
                return null;
            return new IntPair(x, y);
        }

        public static bool TopDown(int x, int y)
        {
            IntPair K = new IntPair(x, y);
            if (dp.ContainsKey(K))
            {
                return dp[K];
            }

            bool F = false;
            for(int i= 0; i<mov.Length; i++)
            {
                IntPair p = GetPosition(i, x, y);
                if (p != null && !TopDown(p.X, p.Y))
                    F = true;
            }
            dp.Add(K, F);
            return F;
        }

        public static int BottomUp(int x, int y)
        {
            bool [,] states = new bool[dim, dim];

            for(int i=0; i<dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {

                }
            }

            return 0;
        }


        static void T(string[] args)
        {
            int cases = IO.ReadInt();
            while (cases-- > 0)
            {
                dp = new Dictionary<IntPair, bool>();
                int[] values = IO.ReadInts(' ');
                IO.printfln("{0}", TopDown(values[0], values[1]) ? "First" : "Second");
            }
        }
    }
}
