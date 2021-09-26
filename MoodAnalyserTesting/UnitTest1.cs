using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
namespace MoodAnalyserTesting
{
    [TestClass]
    public class UnitTest1
    {
        private MoodAnalyser.Program program;

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
    }
}
