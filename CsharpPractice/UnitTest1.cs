using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsharpPractice
{
    [TestClass]
    public class UnitTest1
    {
        //How many times will this loop iterate?
        [TestMethod]
        public void LoopsQuiz1()
        {
            int x = 0;
            while (x < 1)
            {
                x++;
            }
        }
        //What will be the output that is written by Trace.WriteLine after the test finishes execution
        [TestMethod]
        public void LoopsQuiz2()
        {
            int x = 0;
            while (x < 1)
            {
                Trace.WriteLine(x);
                x++;
            }

        }

        //How many times will this loop iterate?
        [TestMethod]
        public void LoopsQuiz3()
        {
            int x = 1;
            while (x < 1)
            {
                Trace.WriteLine(x);
                x++;
            }

        }
        //How many times will this loop iterate?
        public void LoopsQuiz4()
        {
            int x = 1;
            while (true)
            {
                Trace.WriteLine(x);
                x++;
            }
        }
        //How many times will this loop iterate?
        [TestMethod]
        public void LoopsQuiz5()
        {
            int x = 1;
            while (!true)
            {
                Trace.WriteLine(x);
                x++;
            }
        }
        //Write a program in C# Sharp to display the first 10 natural numbers
        [TestMethod]
        public void LoopsQuiz6()
        {
            int x = 1;
            while (x < 11)
            {
                Trace.WriteLine(x);
                x++;
            }
        }
    }
}
