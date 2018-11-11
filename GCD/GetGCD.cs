using System;
using System.Diagnostics;

namespace GCD
{
    public static class GetGCD
    {
        /// <summary>
        /// This method calculate GDC value from 2 arguments
        /// </summary>
        /// <param name="a">first argument</param>
        /// <param name="b">second argument</param>
        /// <returns>GCD value</returns>
        /// <exception cref="ArgumentException">If values less or greater 1 throw Argument Exception </exception>
        public static int GCDEuklid(int a, int b)
        {
            return Euklid(a, b);
        }

        /// <summary>
        /// This method calculate GCD value by Euklid algorithm from 3 arguments
        /// </summary>
        /// <param name="a">first argument</param>
        /// <param name="b">second argument</param>
        /// <param name="c">third argument</param>
        /// <returns>GCD value</returns>
        /// <exception cref="ArgumentException">If values less or greater 1 throw Argument Exception </exception>
        public static int GCDEuklid(int a, int b, int c) => FindGCD(Euklid, a, b, c);

        private static int FindGCD(Func<int, int, int> gcd, int a, int b, int c)
        {
            int result = gcd(a, b);
            result = gcd(result, c);
            return result;
        }

        /// <summary>
        /// This method calculate GCD value by Euklid algorithm from 3 arguments
        /// </summary>
        /// <param name="args">args is array 4 and more arguments</param>
        /// <returns>GCD value</returns>
        /// <exception cref="ArgumentException">If values less or greater 1 throw Argument Exception </exception>
        public static int GCDEuklid(params int[] args) => FindGCD(Euklid, args);

        private static int FindGCD(Func<int, int, int> gcd, params int[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            if (args.Length == 0)
            {
                throw new ArgumentNullException(nameof(args));
            }

            int result = args[0];
            for (int i = 0; i < args.Length; i++)
            {
                result = gcd(result, args[i]);
            }

            return result;
        }

        /// <summary>
        /// This method calculate GCD value by Euklid algorithm from 2 arguments
        /// with calculate elapsed execution time  
        /// </summary>
        /// <param name="a">first argument</param>
        /// <param name="b">second argument</param>
        /// <param name="timeWatchTick">is out elapsed time by ticks</param>
        /// <returns>GCD value</returns>
        /// <exception cref="ArgumentException">If values less or greater 1 throw Argument Exception </exception>
        public static int GCDEuklid(out long timeWatchTick, int a, int b)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = Euklid(a, b);
            stopwatch.Stop();
            timeWatchTick = stopwatch.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// This method calculate GCD value by Euklid algorithm from 3 arguments
        /// with calculate elapsed execution time  
        /// </summary>
        /// <param name="a">first argument</param>
        /// <param name="b">second argument</param>
        /// <param name="c">third argument</param>
        /// <param name="timeWatchTick">is out elapsed time by ticks</param>
        /// <returns>GCD value</returns>
        /// <exception cref="ArgumentException">If values less or greater 1 throw Argument Exception </exception>        
        public static int FindGCD(out long timeWatchTick, int a, int b, int c) =>
            FindGCD(out timeWatchTick, Euklid, a, b, c);

        private static int FindGCD(out long timeWatchTick, Func<int, int, int> gcd, int a, int b, int c)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = gcd(gcd(a, b), c);
            stopwatch.Stop();
            timeWatchTick = stopwatch.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// This method calculate GCD value by Euklid algorithm from 4 and more arguments
        /// with calculate elapsed execution time  
        /// </summary>
        /// <param name="args">args is array 4 and more arguments</param>
        /// <returns>GCD value</returns>
        /// <exception cref="ArgumentException">if values less or greater 1 throw ArgumentException </exception>
        /// <exception cref="ArgumentException">if incomming value array is null reference
        /// throw ArgumentNullException</exception>
        public static int GCDEuklid(out long timeWatchTick, params int[] args) =>
        FindGCD(out timeWatchTick, Euklid, args);
        private static int FindGCD(out long timeWatchTick, Func<int, int, int> gcd, params int[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = args[0];
            for (int i = 0; i < args.Length; i++)
            {
                result = gcd(result, args[i]);
            }
            stopwatch.Stop();
            timeWatchTick = stopwatch.ElapsedTicks;
            return result;
        }

        private static int Euklid(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return Math.Abs(a);
        }

        /// <summary>
        /// This method calculate GCD value from 2 arguments
        /// </summary>
        /// <param name="a">first argument</param>
        /// <param name="b">second argument</param>
        /// <returns>GCD value</returns>
        /// <exception cref="ArgumentException">If values less or greater 1 throw Argument Exception </exception>
        public static int GCDStein(int a, int b)
        {
            if ((a <= 1) || (b <= 1))
            {
                throw new ArgumentException("Value should be greater than 1");
            }

            return Stein(a, b);
        }
        /// <summary>
        /// This method calculate GCD value by Stein algorithm from 3 arguments
        /// </summary>
        /// <param name="a">first argument</param>
        /// <param name="b">second argument</param>
        /// <param name="c">third argument</param>
        /// <returns>GCD value</returns>
        /// <exception cref="ArgumentException">If values less or greater 1 throw Argument Exception </exception>
        public static int GCDStein(int a, int b, int c) => FindGCD(Stein, a, b, c);

        /// <summary>
        /// This method calculate GCD value by Stein algorithm from 3 arguments
        /// </summary>
        /// <param name="args">args is array arguments</param>
        /// <returns>GCD value</returns>
        /// <exception cref="ArgumentException">If values less or greater 1 throw Argument Exception </exception>
        public static int GCDStein(params int[] args) => FindGCD(Euklid, args);

        /// <summary>
        /// This method calculate GCD value by Stein algorithm from 2 arguments
        /// with calculate elapsed execution time  
        /// </summary>
        /// <param name="a">first argument</param>
        /// <param name="b">second argument</param>
        /// <param name="timeWatchTick">is out elapsed time by ticks</param>
        /// <returns>GCD value</returns>
        /// <exception cref="ArgumentException">If values less or greater 1 throw Argument Exception </exception>
        public static int GCDStein(out long timeWatchTick, int a, int b) =>
            FindGCD(out timeWatchTick, Stein, a, b);

        /// <summary>
        /// This method calculate GCD value by Stein algorithm from 3 arguments
        /// with calculate elapsed execution time  
        /// </summary>
        /// <param name="a">first argument</param>
        /// <param name="b">second argument</param>
        /// <param name="c">third argument</param>
        /// <param name="timeWatchTick">is out elapsed time by ticks</param>
        /// <returns>GCD value</returns>
        /// <exception cref="ArgumentException">If values less or greater 1 throw Argument Exception </exception>
        public static int GCDStein(out long timeWatchTick, int a, int b, int c) =>
            FindGCD(out timeWatchTick, Stein, a, b, c);

        /// <summary>
        /// This method calculate GCD value by Stein algorithm from 4 and more arguments
        /// with calculate elapsed execution time  
        /// </summary>
        /// <param name="args">args is array arguments</param>
        /// <returns>GCD value</returns>
        /// <exception cref="ArgumentException">if values less or greater 1 throw ArgumentException </exception>
        /// <exception cref="ArgumentException">if incomming value array is null reference
        /// throw ArgumentNullException</exception>
        private static int GCDStein(out long timeWatchTick, params int[] args) =>
            FindGCD(out timeWatchTick, Stein, args);

        private static int Stein(int a, int b)
        {
            int t = 1;
            while ((a != 0) && (b != 0))
            {
                while ((a % 2 == 0) && (b % 2 == 0))
                {
                    a /= 2;
                    b /= 2;
                    t *= 2;
                }

                while (a % 2 == 0)
                {
                    a /= 2;
                }

                while (b % 2 == 0)
                {
                    b /= 2;
                }

                if (a >= b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return b * t;
        }
    }
}
