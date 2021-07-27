using System;
using System.Collections;
using System.Linq;

public static class Util
{
    public static int ChooseFromProbability(int[] probabilities)
    {
        var sum = probabilities.Sum();
        var randomNumber = new Random().Next(sum);

        for (var i = 0; i < probabilities.Length; ++i)
        {
            randomNumber -= probabilities[i];

            if (randomNumber < 0)
            {
                return i;
            }
        }

        return probabilities.Length - 1;
    }

    public static int Clamp(int value, int minimum, int maximum)
    {
        return Math.Min(Math.Max(value, minimum), maximum);
    }
}
