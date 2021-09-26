using System;

namespace MoodAnalyser
{
    public class Program
    {
        private string message;
        /// <summary>
        /// default constructor
        /// </summary>
        public Program()
        {
        }
        /// <summary>
        /// Parameter Constructor to assign message
        /// </summary>
        /// <param name="msg"></param>
        public Program(string msg)
        {
            this.message = msg;
        }
        
        public string moodAnalyser()
        {
            //if(this.message == null)
            //{
            //    throw new ArgumentNullException(nameof(message));
            //}
            try
            {
                var tempArr = message.ToLower().Split(" ");
                string result = "";
                for (int i = 0; i < tempArr.Length; i++)
                {
                    if (tempArr[i].Equals("sad"))
                    {
                        result = "SAD";
                        break;
                    }
                    else if (tempArr[i].Equals("happy") || tempArr[i].Equals("any"))
                    {
                        result = "HAPPY";
                        break;
                    }
                    else
                    {
                        result = null;
                    }
                }
                return result;
            }
            catch (NullReferenceException)
            {
                return "Happy";
            }
            catch (ArgumentNullException)
            {
                return "Happy";
            }
            //}catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    return;
            //}
            
        }
        static void Main()
        {
            Console.WriteLine("Hello World!");
            Program Moodanalyser = new Program(null);
            string result = Moodanalyser.moodAnalyser();
            Console.WriteLine(result);
        }
    }
}
