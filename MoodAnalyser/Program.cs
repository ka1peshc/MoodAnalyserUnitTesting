using System;

namespace MoodAnalyser
{
    public enum errorList
    {
        GivenMessageIsEmpty,
        GivenMessageIsNull
    }
    [Serializable]
    public class EmptyMessage : Exception
    {
        public EmptyMessage() : base(errorList.GivenMessageIsEmpty.ToString())
        {

        }
    }
    [Serializable]
    public class NullMessage : Exception
    {
        public NullMessage() : base(errorList.GivenMessageIsNull.ToString())
        {

        }
    }
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
            try
            {
                ValidateMesssage(this.message);
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
            catch (EmptyMessage em)
            {
                Console.WriteLine(em.Message);
                //return "Happy";
                return em.Message;
            }
            catch (NullMessage nm)
            {
                Console.WriteLine(nm.Message);
                //return "Happy";
                return nm.Message;
            }
            //}catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    return;
            //}
            
        }
        private static void ValidateMesssage(string msg)
        {
            if(msg == null)
            {
                throw new NullMessage();
            }if( msg == "")
            {
                throw new EmptyMessage();
            }
        }

        static void Main()
        {
            Console.WriteLine("Hello World!");
            Program Moodanalyser = new Program("");
            string result = Moodanalyser.moodAnalyser();
            Console.WriteLine(result);
        }
    }
}
