using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimeNumberConsoleApplication
{
    internal class Program
    {
        /// <summary>
        /// 素数求めるプログラム
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            // 2は決め打ち
            Console.WriteLine(@"2");

            // 3以上から素数を見ていくけど、偶数は全部2が約数となるので素数対象は奇数のみとなるので2でカウントアップするよ
            for (int i = 3; i <= 1000; i += 2)
            {
                bool hasOuputTarget = true;

                // 素数指定で使用する対象の割り切れる数は、対象のiの平方根以下となる。
                // これ以上の割り切れる数となると、平方根以下の約数かける平方根以上の約数の組み合わせしか無い為である。
                // 約数の最小値から検索を初めて、iの平方根までで割り切れない場合は、素数となる
                // 2でカウントアップしてるのは、偶数は見る意味が無い為である。っというかiが奇数のみの場合、偶数でのあまりの確認が必要ない為である。
                for (int j = 3; j <= Math.Sqrt(i); j += 2)
                {
                    if (i % j == 0)
                    {
                        hasOuputTarget = false;
                        break;
                    }
                }

                if (hasOuputTarget)
                    Console.WriteLine(i.ToString());
            }

            Console.ReadLine();
        }
    }
}