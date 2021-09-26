using System;

namespace MoodAnalyser
{
    class Program
    {
        public string moodAnalyser(string msg)
        {
            
            var tempArr = msg.ToLower().Split(" ");
            string result="";
            for(int i = 0; i < tempArr.Length; i++)
            {
                if (tempArr[i].Equals("sad"))
                {
                    result = "SAD";
                }
                else if (tempArr[i].Equals("happy") || tempArr[i].Equals("any"))
                {
                    result = "HAPPY";
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program Moodanalyser = new Program();
            string result = Moodanalyser.moodAnalyser("I am Happy");
            Console.WriteLine(result);
        }
    }
}
