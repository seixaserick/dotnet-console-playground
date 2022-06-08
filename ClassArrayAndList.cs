using System.Collections.Generic;
using System.Diagnostics;
namespace Playground;

public static class ClassArrayAndList
{

    public static void ExecuteFunctions()
    {
        int[] intArray = { 1, 2, 1, 4, 2, 3, 5, 6, 1, 4, 1, 5 };
        int result = FindOnethatAppearAnOddNumbersOfTimes(intArray);

        Console.WriteLine($"FindOnethatAppearAnOddNumbersOfTimes({intArray}) is:  {result}");
    }

    public static int FindOnethatAppearAnOddNumbersOfTimes(int[] seq)
    //Given an array of integers, find the one that appears an odd number of times.
    {

        if (seq.Length == 0) { return -1; }
        if (seq.Length == 1) { return seq[0]; }
        Console.WriteLine($" seq[] unsorted is {string.Join(",", seq)}");

        Array.Sort(seq);
        Console.WriteLine($" seq[] sorted is {string.Join(",", seq)}");
        var resultList = new List<NumberAndQty>();
        resultList.Add(new NumberAndQty(seq[0], 1));

        for (int i = 1; i < seq.Length; i++)
        {

            if (seq[i] != seq[i - 1])
            {
                resultList.Add(new NumberAndQty(seq[i], 0));
            }
            resultList[resultList.Count - 1].times++;

        }

        for (int j = 0; j < resultList.Count; j++)
        {
            Console.WriteLine($" resultList[{j}]= {resultList[j].number} repeats {resultList[j].times}");

        }


        for (int j = 0; j < resultList.Count; j++)
        {
            if (resultList[j].times % 2 != 0)
            {
                return resultList[j].number;
            }
        }

        return -1; //none found

    }


}
public class NumberAndQty
{
    public int number { get; set; }
    public int times { get; set; }

    public NumberAndQty(int num, int qty)
    {
        number = num;
        times = qty;
    }


}


