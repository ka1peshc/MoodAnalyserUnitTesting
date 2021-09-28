using System;
using System.Collections.Generic;
using System.Text;


namespace MoodAnalyser
{
    public class MoodAnalyserClass
    {
        private string message;
        public MoodAnalyserClass(string msg)
        {
            this.message = msg;
        }

        public string AnalyseMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new CustomMoodAnalyser(CustomMoodAnalyser.ExceptionType.Entered_Empty_String, "String is empty");
                }
                
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
    }
}
