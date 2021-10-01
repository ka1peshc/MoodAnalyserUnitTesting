using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
using System;

namespace MoodAnalyserTesting
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            
        }
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            string msg = "I am in Sad Mood";
            MoodAnalyserClass mac = new MoodAnalyserClass(msg);
            //Action
            string result = mac.AnalyseMood();
            //Assert
            Assert.AreEqual("SAD", result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            string msg = "I am in Happy Mood";
            MoodAnalyserClass mac = new MoodAnalyserClass(msg);
            //Action
            string result = mac.AnalyseMood();
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
                //Arrange
                string message = "I am in happy mood";
                MoodAnalyserClass mac = new MoodAnalyserClass(message);
                //Action
                string result = mac.AnalyseMood();
                //Act
                Assert.AreEqual("HAPPY", result);
            }
            catch (CustomMoodAnalyser cma)
            {
                //Act
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
        /// <summary>
        /// Test case 4.1 Given mood analyser class name should return mood analyser object
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyserClassName_ShouldReturnMoodAnalyserObject()
        {
            string message = null;
            object expected = new MoodAnalyserClass(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClass");
            expected.Equals(obj);
        }

        [TestMethod]
        public void GivenMoodAnalyserClassWrongName_GetException()
        {
            string msg = "Class not found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClassFake", "MoodAnalyserClassFake");
            }
            catch(CustomMoodAnalyser cma)
            {
                Assert.AreEqual(msg, cma.Message);
            }
        }

        [TestMethod]
        public void GivenMoodAnalyserClassConstructorWrongName_GetException()
        {
            string msg = "Constructor is not found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyser.MoodAnalyserClass", "MoodAnalyserClassFake");
            }
            catch (CustomMoodAnalyser cma)
            {
                Assert.AreEqual(msg, cma.Message);
            }
        }
    }
}
