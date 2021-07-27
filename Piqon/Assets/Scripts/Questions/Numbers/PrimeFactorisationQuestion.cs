using System;
using System.Collections.Generic;

public class PrimeFactorisationQuestion : Question
{
    private readonly int[] primes = {2, 3, 5, 7, 11, 13, 17, 19, 23};
    private readonly int[] probabilities = {7, 10, 10, 8, 4, 2, 1};
    private readonly int minExponents = 3; // Minimum number of exponents
    private readonly int maxExponents = 10; // Maximum number of exponents

    public PrimeFactorisationQuestion() : base(SectionId.NUMBERS, 1)
    {
        SetQuestion(CreateQuestion());
    }

    protected sealed override string CreateQuestion()
    {
        var number = GenerateNumber();
        
        return 
            $"Express {number} as a product of its prime factors, giving your answer in index notation.";
    }

    private int GenerateNumber()
    {
        var number = new ValueTuple<int, string>(0, "");
        var numberOfExponents = new Random().Next(minExponents, maxExponents);

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
                var exponent = Math.Min(Util.ChooseFromProbability(probabilities), numberOfExponents);

                if (exponent > 0)
                {
                    ExtendNumber(number, primes[currentIndex], numberOfExponents);
                    numberOfExponents -= exponent;
                }

                ++currentIndex;
            }
        }
        
        SetAnswer(new Answer(number.Item2.Substring(1)));
        return number.Item1;
    }

    private void ExtendNumber(ValueTuple<int, string> number, int prime, int exponent)
    {
        number.Item1 += (int) Math.Pow(prime, exponent);
        number.Item2 += $"x{prime}^{exponent}";
    }
}
