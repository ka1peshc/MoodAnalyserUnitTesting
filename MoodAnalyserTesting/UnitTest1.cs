using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System;

namespace MoodAnalyserTesting
{
    [TestClass]
    public class UnitTest1
    {
        private MoodAnalyser.Program program;
        //private MoodAnalyser.MoodAnalyser analyser;
        public UnitTest1()
        {
            
        }
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            string msg = "I am in Sad Mood";
            //Action
            program = new MoodAnalyser.Program(msg);
            string result = program.moodAnalyser();
            //Assert
            Assert.AreEqual("SAD", result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            string msg = "I am in Happy Mood";
            //Action
            program = new MoodAnalyser.Program(msg);
            string result = program.moodAnalyser();
            //Assert
            Assert.AreEqual("HAPPY", result);
        }

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void TestMethod3()
        //{
        //    string msg = null;
        //    program = new MoodAnalyser.Program(msg);
        //    string result = program.moodAnalyser();
            
        //    //Assert.AreEqual(null, result);
        //    //Assert.IsNotNull(result);
        //}
        
        [TestMethod]
        [DataRow("I am in Happy mood")]
        [DataRow(null)]
        public void GivenSadMoodShouldReturnSAD(string message)
        {
            //Arrange
            string expected = "HAPPY";
            //string message = "I am in Sad MOOD";
            MoodAnalyserClass mac = new MoodAnalyserClass(message);
            //Action
            string result = mac.AnalyseMood();
            //Act
            Assert.AreEqual(expected, result);

        }
        /// <summary>
        /// UC3 Custom message for Empty string
        /// </summary>
        [TestMethod]
        public void CustomExceptionForEmptyString()
        {
            try
            {
                string message = "";
                MoodAnalyserClass mac = new MoodAnalyserClass(message);
                string result = mac.AnalyseMood();
            }
            catch (CustomMoodAnalyser cma)
            {
                Assert.AreEqual("String is empty",cma.Message);
            }
        }
        /// <summary>
        /// UC3 Custom message for Empty string
        /// </summary>
        [TestMethod]
        public void CustomExceptionForNullString()
        {
            try
            {
                string message = "";
                MoodAnalyserClass mac = new MoodAnalyserClass(message);
                string result = mac.AnalyseMood();
            }
            catch (CustomMoodAnalyser cma)
            {
                Assert.AreEqual("Nothing is entered", cma.Message);
            }
        }
    }
}
