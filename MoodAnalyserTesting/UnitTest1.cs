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
            program = new MoodAnalyser.Program();
        }
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            string msg = "I am in Sad Mood";
            //Action
            string result = program.moodAnalyser(msg);
            //Assert
            Assert.AreEqual("SAD", result);
        }
    }
}
