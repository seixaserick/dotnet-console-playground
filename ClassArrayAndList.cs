using System.Collections.Generic;
using System.Diagnostics;
namespace Playground;

public static class ClassArrayAndList
{

    public static void ExecuteFunctions()
    {


        //FindOnethatAppearAnOddNumbersOfTimes
        int[] intArray = { 1, 2, 1, 4, 2, 3, 5, 6, 1, 4, 1, 5 };
        int result = FindOnethatAppearAnOddNumbersOfTimes(intArray);
        Console.WriteLine($"FindOnethatAppearAnOddNumbersOfTimes({intArray}) is:  {result}");



        //game result validator
        RunIsCompletedGameHand();




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


    private static void RunIsCompletedGameHand()
    {
        string[] inputText = new string[8];

        inputText[0] = "99";// => true (only 1 pair is ok)
        inputText[1] = "11222";//=> true (1 pair + 1 triple = ok)
        inputText[2] = "1122"; //=> false (2 pairs not allowed)
        inputText[3] = "111";// => false (none pair)
        inputText[4] = "11122233444"; //=> true (3 triple + 1 pair ok)
        inputText[5] = "42121213344"; //=> true ==> (3 triple + 1 pair ok, even out of order)
        inputText[6] = "9";// => false (none pair)
        inputText[7] = "";//=> false (none pair)

        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine(@$"IsCompletedGameHand(""{inputText[i]}"") is: {IsCompletedGameHand(inputText[i])}");
        }

    }
    public static bool IsCompletedGameHand(string inputText)
    //returns true if:  1 pair, no more than 1 pair, contains 0 up to N triple combined in the hand
    //examples:
    //inputText="99" => true (only 1 pair is ok)
    //inputText="11222" => true (1 pair + 1 triple = ok)
    //inputText="1122" => false (2 pairs not allowed)
    //inputText="111" => false (none pair)
    //inputText="11122233444" => true (3 triple + 1 pair ok)
    //inputText="42121213344" => true ==> (3 triple + 1 pair ok, even out of order)
    //inputText="9" => false (none pair)
    //inputText="" => false (none pair)
    {

        //verify if length is at least a pair
        if (inputText.Length < 2) { return false; }

        //convert input string to array chars
        var inputChars = inputText.ToCharArray();

        //verify if it is a pair
        if (inputText.Length == 2) { return inputChars[0] == inputChars[1]; }

        //exit early by sequence length. must be: 2, 2+3, 2+6, 2+9, 2+(n * 2)....
        if ((inputChars.Length - 2) % 3 != 0) { return false; }


        Array.Sort(inputChars); //BigO(~ n log n)



        string lastSequence = inputChars[0].ToString();
        bool hasPair = false;




        for (int i = 1; i < inputChars.Length; i++)
        {
            if (inputChars[i] != inputChars[i - 1])
            {
                if (hasPair && lastSequence.Length == 2) { return false; } //previous pair already exists
                if (!hasPair && lastSequence.Length == 2) { hasPair = true; } //first pair was found
                if (lastSequence.Length < 2 && lastSequence.Length != 0) { return false; } //non-pair neither a triple found. 
                if (lastSequence.Length == 3) { lastSequence = ""; } //clean lastSequence
                lastSequence += inputChars[i].ToString();

            }
            else
            {
                lastSequence += inputChars[i].ToString();
                if (lastSequence.Length == 3) { lastSequence = ""; }
            }
        }

        if (!hasPair && lastSequence.Length == 2) { hasPair = true; } //first pair was found

        return hasPair;
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


