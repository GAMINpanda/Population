using System;
using System.Collections;
using System.Collections.Generic;

namespace Simulator
{
    class Program
    { //Want to create some sort of program to model a population based on changes from the outside world, sort of joke based stuff
      //Based on historical variation and stuff once done a paragraph will explain the history the population
        static List<double> Run(double population, double difficulty, int duration) //function to run the program
        {
            double percent = (0.001 / difficulty);
            double birth = 1 + percent; 
            double death = 1 - percent;

            double innovation = 1;
            double invrate = 1 + percent;

            double food = 0.98;

            for (int i = 0; i <= duration; i++) //runs iterations
            {
                population = ((population + (population * 1.05)) * birth) - ((population * 0.95) * death);
                innovation = innovation * invrate + (innovation * (1 - food));

                if (population > (innovation * 1000000)) //innovation can only support so much population
                {
                    population = population * 0.98;
                }

                birth = (food * birth) + (innovation / 1000);
                death = (death / food) - (innovation / 1000);

                if (population < 100)
                {
                    break;
                }
            }

            return new List<double>() { population, innovation};
        }
        static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("===========WELCOME=TO=WORLD=SIM============");
            Console.WriteLine("===========================================");

            Console.WriteLine("Give=starting=population=(1000-100,000)==== ");
            double population = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Give=Difficulty=(0-1)====================== ");
            double difficulty = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Give=Duration=(100-5,000)================== ");
            int duration = Convert.ToInt32(Console.ReadLine());

            List<double> output = Run(population,difficulty,duration);
            Console.WriteLine("Final=Population:={0}=Final=Innovation:={1}",output[0], output[1]);
        }
    }
}
