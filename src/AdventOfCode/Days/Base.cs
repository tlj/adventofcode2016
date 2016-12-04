using System;

namespace Days
{
    public class Base 
    {
        private bool hasRun = false;
        protected string input;
        protected string firstResult;
        protected string secondResult;

        public virtual void Run()
        {
            hasRun = true;
        }

        public void Output()
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