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
     * Complete the 'countingValleys' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER steps
     *  2. STRING path
     */
	 
	 //Time complexity: O(n)
	 //Space complexity: O(n) (path size)

    public static int countingValleys(int steps, string path)
    {
        if(path.Length < 2)
            return 0;
        
        int totalValleys = 0;
        int currentPosition = ConvertStepToNumber(path[0]);
        
        for(int i = 1; i < steps; i++){
            currentPosition += ConvertStepToNumber(path[i]);
            
            if(currentPosition == 0 && path[i] == 'U') 
                totalValleys++;
        }
        
        return totalValleys;
    }
    
    private static int ConvertStepToNumber(char step){
        return step == 'D' ? -1 : 1;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int steps = Convert.ToInt32(Console.ReadLine().Trim());

        string path = Console.ReadLine();

        int result = Result.countingValleys(steps, path);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
