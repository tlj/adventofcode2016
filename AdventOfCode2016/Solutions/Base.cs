using System;

namespace AdventOfCode2016.Solutions
{
    public class Base 
    {
        private bool hasRun = false;
        protected string input;
        protected string[] inputs;
        protected string firstResult = "";
        protected string secondResult = "";

        public virtual void Run()
        {
            hasRun = true;
        }

        public void Init(string inputString)
        {
            input = inputString.Replace("\r", "");
            inputs = input.Split('\n');
        }

        public virtual void Output()
        {
            if (!hasRun) {
                Run();
            }

            Console.WriteLine("Day " + this.GetType().Name + ": First result: " + GetFirstResult());
            Console.WriteLine("Day " + this.GetType().Name + ": Second result: " + GetSecondResult());
            Console.WriteLine("");
        }


        public virtual string GetFirstResult()
        {
            return firstResult;
        }

        public virtual string GetSecondResult()
        {
            return secondResult;
        }
    }
}