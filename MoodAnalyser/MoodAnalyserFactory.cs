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
        /// <summary>
        /// CreateMoodAnalyse method to create object of MoodAnalyserClass
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyserClass);
            if(type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.No_Such_Method, "Constructor is not found");
                }
            }
            else
            {
                throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.No_Such_Class, "Class not found");
            }
        }
    }
}
