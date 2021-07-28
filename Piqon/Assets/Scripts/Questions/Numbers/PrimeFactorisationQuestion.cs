using System;
using PiqonUtils;
using UnityEngine;
using Random = System.Random;

public class PrimeFactorisationQuestion : Question
{
    public static readonly string TOPIC = "Prime Factorisation";
    
    private readonly int[] primes = {2, 3, 5, 7, 11, 13, 17, 19};
    private readonly int[] probabilities = {16, 36, 30, 20, 12, 4, 1};
    private const int MIN_EXPONENTS = 3; // Minimum number of exponents
    private const int MAX_EXPONENTS = 10; // Maximum number of exponents
    private const long MAX_VALUE = 1000000;

    public PrimeFactorisationQuestion() : base(SectionId.NUMBERS, 1)
    {
        CreateNewQuestion();
    }

    public sealed override void CreateNewQuestion()
    {
        long number;
        do
        {
            number = GenerateNumber();
        } while (number > MAX_VALUE);

        SetQuestion(
            $"Express {number} as a product of its prime factors, giving your answer in index notation."
        );
    }

    private long GenerateNumber()
    {
        var number = new Pair<long, string>(1, "");
        var numberOfExponents = new Random().Next(MIN_EXPONENTS, MAX_EXPONENTS);

        var currentIndex = 0;
        while (numberOfExponents > 0)
        {
            if (currentIndex == primes.Length - 1)
            {
                ExtendNumber(number, primes[currentIndex], numberOfExponents);
                numberOfExponents = 0;
            }
            else
            {
                var exponent = Math.Min(Utils.ChooseFromProbability(probabilities), numberOfExponents);

                if (exponent > 0)
                {
                    ExtendNumber(number, primes[currentIndex], exponent);
                    numberOfExponents -= exponent;
                }

                ++currentIndex;
            }
        }
        
        Debug.Log($"{number.First} {number.Second}");
        
        SetAnswer(new Answer(number.Second.Substring(1)));
        return number.First;
    }

    private void ExtendNumber(Pair<long, string> number, int prime, int exponent)
    {
        number.First *= (int) Math.Pow(prime, exponent);
        number.Second += $"x{prime}^{exponent}";
    }
}
