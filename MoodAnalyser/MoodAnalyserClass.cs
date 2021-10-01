using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyserClass
    {
        private readonly string message;
        public MoodAnalyserClass()
        {
            
        }
        public MoodAnalyserClass(string msg)
        {
            this.message = msg;
        }

        public string AnalyseMood()
        {
            try
            {
                //Is empty or not
                if (this.message.Equals(string.Empty))
                {
                    throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.Entered_Empty_String, "String is empty");
                }
                //Check for mood
                if(this.message.Contains("Sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.Entered_null, "Nothing is entered");
            }
            
        }

        public static object CreateMoodAnalyse(String className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
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
                    throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.No_Such_Class, "Class Not Found");
                }
            }
            else
            {
                throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.No_Such_Method, "Constructor is Not Found");
            }
        }
    }
}
