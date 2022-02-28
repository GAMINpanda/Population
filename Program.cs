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
            double birth = 1 + (0.001 / difficulty); 
            double deathmod = 1; //modifier applied to population to work out how far the population decreases ==> the closer to 1 the better

            double innovation = 1; //base variable for progress
            double invrate = 1 + (0.001 / difficulty); //how fast that progress advances

            double food = 1; //determines food supply

            int count = 0; //counts years in case of early collapse

            for (int i = 0; i <= duration; i++)
            {
                population = population * birth * deathmod; //self explanatory
                innovation = innovation * invrate; //same

                if (population > (innovation * 10000)) //innovation can only support so much population (10,000 for every point of innovation
                {
                    population = population * 0.98; //gradual decay if limit is reached
                }

                birth = birth + (innovation / 1000) + (food - 1); //birth reliant on current technology and food supply
                deathmod = (deathmod / food) + (innovation / 1000); //death reliant on food supply and innovation

                food = (food + ((innovation * 10000) / population)) / 2; //food reliant on proportion of innovation to population and current food supply
                invrate = 1 + (innovation * 1000) / population; //invrate never goes negative

                if (population < 100) //Consider 100 a number irrecoverable for the population 
                {
                    break;
                }

                if (deathmod > 1) //the death modifer would never exceed 1
                {
                    deathmod = 0.99; //some people have to die
                }

                if (birth < 1) //the birth modifier would never fall below 1
                {
                    birth = 1.01; //people always born
                }
                count++;
            }

            return new List<double>() { population, innovation, count};
        }
        static void Main(string[] args)
        {
            /*
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
            */

            List<double> output = Run(5000,1, 1000);
            Console.WriteLine("Final=Population:={0}=Final=Innovation:={1}=Years:={2}",output[0], output[1], output[2]);
        }
    }
}
