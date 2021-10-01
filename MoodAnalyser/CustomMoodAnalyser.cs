using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class CustomMoodAnalyser:Exception
    {
        
        public enum ExceptionType
        {
            Entered_null,
            Entered_Empty_String,
            No_Such_Class,
            No_Such_Method
        }

        ExceptionType enumtype;
        //
        public CustomMoodAnalyser(ExceptionType type, string msg) : base(msg)
        {
            this.enumtype = type;
        }
        
    }
}
