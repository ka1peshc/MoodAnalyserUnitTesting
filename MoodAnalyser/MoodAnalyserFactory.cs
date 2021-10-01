using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyse(string className, string construtorName)
        {
            string pattern = @"."+construtorName+"$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.No_Such_Class, "Class not found");
                }
            }
            else
            {
                throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.No_Such_Method, "Constructor is not found");
            }

        }
    }
}
