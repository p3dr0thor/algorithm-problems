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
     * Complete the 'minimumAbsoluteDifference' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */
	 
	 //Time complexity: O(n log(n) + n)
	 //Space complexity: O(n + n)
	 
	 //Solution: Sort and update min value. If 0, return.
	
    public static int minimumAbsoluteDifference(List<int> arr)
    {
        int minDifference = int.MaxValue;
        arr.Sort();
        int value = 0;
        
        for(int i=1; i < arr.Count; i++){
            value = Math.Abs(arr[i]-arr[i-1]);
            if(value < minDifference)
                minDifference = value;
			
			if(minDifference == 0)
                return minDifference;
        }
        
        return minDifference;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.minimumAbsoluteDifference(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
