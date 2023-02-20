using Microsoft.VisualStudio.TestTools.UnitTesting;
using REG_MARK_LIB;

namespace TestMark
{
    [TestClass]
    public class REG_MARK_LIB_TESTS
    {

        private Marks _marks = new Marks();

        [TestMethod]
        public void CheckMarks_CorrectMark()
        {
            string mark = "A123AA123";

            Assert.IsTrue(_marks.CheckMarks(mark));
        }

        [TestMethod]
        public void CheckMarks_WrongMark()
        {
            string mark = "A123AAA123";

            Assert.IsFalse(_marks.CheckMarks(mark));
        }

        [TestMethod]
        public void GetNextMarkAfter_NextNumberMark() // проверяет смену числа номера
        {
            Assert.IsTrue(_marks.GetNextMarkAfter("A123AA123") == "A124AA123");
        }

        [TestMethod]
        public void GetNextMarkAfter_NextSeriesMarkLastLetter() // проверяет смену последней буквы номера
        {
            Assert.IsTrue(_marks.GetNextMarkAfter("A999AX123") == "A000BA123");
        }

        [TestMethod]
        public void GetNextMarkAfter_NextSeriesMarkSecondAndLastLetter() // проверяет смену последних двух букв номера
        {
            Assert.IsTrue(_marks.GetNextMarkAfter("A999XX123") == "B000AA123");
        }

        [TestMethod]
        public void GetNextMarkAfter_NextSeriesMarkAllLetters() // проверяет смену всех букв номера
        {
            Assert.IsTrue(_marks.GetNextMarkAfter("X999XX123") == "Нет больше номеров");
        }

        [TestMethod]
        public void GetCombinationsCountInRange_CHECK() // change test method name
        {
            Assert.IsTrue(_marks.GetCombinationsCountInRange("A000AA123", "X999XX123") == 50);
        }
    }
}
