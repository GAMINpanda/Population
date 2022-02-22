using System;

namespace Simulator
{
    class Program
    { //Want to create some sort of program to model a population based on changes from the outside world, sort of joke based stuff
      //Based on historical variation and stuff once done a paragraph will explain the history the population

        static void NewYear(int yearnum)
        {
            //Going to be the function called every year
        }
        static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("===========WELCOME=TO=WORLD=SIM============");
            Console.WriteLine("===========================================");

            Console.WriteLine("Give=starting=population=(1000-100,000)==== ");
            int pop = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Give=Difficulty=(0-1)====================== ");
            double diff = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Give=Duration=(100-5,000)================== ");
            int dur = Convert.ToInt32(Console.ReadLine());
        }
    }
}
