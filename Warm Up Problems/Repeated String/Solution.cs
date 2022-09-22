using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'repeatedString' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. LONG_INTEGER n
     */
	 
	//Time complexity: O(s.Length + n % s.Length)
	//Space complexity: O(s.length)
	 
	//Solution: Solve edge case and count number of 'a' in 'string s', then multiply by the number of times that 'string s' is fully repeated, then iterate over the remainder subset of 'string s' to find 'a' on this subset.

    public static long repeatedString(string s, long n)
    {
        if (s.Length == 1 && s == "a")
            return n;

        long totalA = 0, remainder = 0;
        int i = 0;

        for (i = 0; i < s.Length; i++)
        {
            if (s[i] == 'a')
                totalA++;
        }

        totalA = (n / s.Length) * totalA;

        remainder = n % s.Length;

        if (remainder == 0)
            return totalA;

        i = 0;
        while (i < remainder)
        {
            if (s[i % s.Length] == 'a')
                totalA++;

            i++;
        }

        return totalA;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
