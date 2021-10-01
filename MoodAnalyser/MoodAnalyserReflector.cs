using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyserReflector
    {
        /// <summary>
        /// CreateMoodAnalyse method to create object of MoodAnalyserClass
        /// </summary>
        /// <param name="className"></param>
        /// <param name="construtorName"></param>
        /// <returns></returns>
        public static object CreateMoodAnalyse(string className, string construtorName)
        {
            string pattern = @"." + construtorName + "$";
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
            if (type.Name.Equals(className) || type.FullName.Equals(className))
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
        /// <summary>
        /// Invoke method using reflection 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static string InvokeAnalyseMethod(string msg, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyser.MoodAnalyserClass");
                object moodAnalyserObject = MoodAnalyserReflector.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyser.MoodAnalyserClass",
                    "MoodAnalyserClass",msg);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyserObject,null);
                return mood.ToString();

            }
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.No_Such_Method, "No such method exists");
            }
        }
        /// <summary>
        /// Use Reflection to change mood dynamically
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string setField(string message, string fieldName)
        {
            try
            {
                MoodAnalyserClass mac = new MoodAnalyserClass();
                Type type = typeof(MoodAnalyserClass);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if(message == null)
                {
                    throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.No_Such_Field, "Message should not be null");
                }
                field.SetValue(mac, message);
                return mac.message;
            }
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.No_Such_Field, "field is not found");
            }
        }
    }
}
