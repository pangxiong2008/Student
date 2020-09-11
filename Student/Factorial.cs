using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student
{
    public class Factorial
    {
        public int FactorialRun(int n)
        {
            if (0 == n)
            {
                return 1;

            }
            else
            {
                return n * FactorialRun(n - 1);
            }
        }

    }
}