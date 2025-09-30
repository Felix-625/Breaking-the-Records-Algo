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
     * Complete the 'breakingRecords' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY scores as parameter.
     */

    public static List<int> breakingRecords(List<int> scores)
    {
     if (scores == null || scores.Count == 0)
            return new List<int> { 0, 0 };

        int minScore = scores[0];
        int maxScore = scores[0];
        int breakMinCount = 0;
        int breakMaxCount = 0;

        for (int i = 1; i < scores.Count; i++)
        {
            int currentScore = scores[i];
            
            // Check for breaking maximum record
            if (currentScore > maxScore)
            {
                maxScore = currentScore;
                breakMaxCount++;
            }
            // Check for breaking minimum record
            else if (currentScore < minScore)
            {
                minScore = currentScore;
                breakMinCount++;
            }
        }

        return new List<int> { breakMaxCount, breakMinCount };
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> scores = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(scoresTemp => Convert.ToInt32(scoresTemp)).ToList();

        List<int> result = Result.breakingRecords(scores);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
