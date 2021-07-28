using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace PiqonUtils
{
    public static class Utils
    {
        private static Random random = new Random();
        
        public static int ChooseFromProbability(int[] probabilities)
        {
            var sum = probabilities.Sum();
            var randomNumber = random.Next(sum);

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
        
        
        public static int ChooseFromProbability2(int[] probabilities)
        {
            List<int> array = new List<int>();

            for (var i = 0; i < probabilities.Length; ++i)
            {
                for (var j = 0; j < probabilities[i]; ++j)
                {
                    array.Add(i);   
                }
            }
            
            RandomiseArray(array);

            string print = "";

            foreach (var value in array)
            {
                print += $"{value}, ";
            }
            
            Debug.Log(print);

            return array[new Random().Next(probabilities.Sum())];
        }

        public static void RandomiseArray(List<int> array)
        {
            for (var i = array.Count - 1; i > 0; --i)
            {
                var randomIndex = random.Next(0, i + 1);
 
                var temp = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = temp;
            }
        }

        public static int Clamp(int value, int minimum, int maximum)
        {
            return Math.Min(Math.Max(value, minimum), maximum);
        }
    }
    

    public class Pair<T, U>
    {
        public Pair() {
        }

        public Pair(T first, U second) {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    }
}
