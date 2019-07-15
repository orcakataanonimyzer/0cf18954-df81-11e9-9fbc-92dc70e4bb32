using NUnit.Framework;
using Pencil_Durability;

namespace Tests
{
    public class PencilDurabilityTests
    {
        [SetUp]
        public void Setup()
        {
        }
        #region Write
        [Test]
        public void WhenThePencilIsPassedTextThenThePaperReflectsTheText()
        {
            var text = "test text";
            var pencil = new Pencil(100, 3);
            pencil.Write(text);

            Assert.AreEqual(text, pencil.Paper);
        }

        [Test]
        public void WhenThePaperHasTextAndThePencilIsPassedMoreTextThenTheNewTextIsAppended()
        {
            var originalText = "She sells sea shells";
            var newText = " down by the sea shore";
            var pencil = new Pencil(100, 3);
            pencil.Paper = originalText;
            pencil.Write(newText);

            Assert.AreEqual(originalText + newText, pencil.Paper);
        }
        #endregion

        #region Point Durability
        [Test]
        public void WhenThePencilIsCreatedWithAPointDurabilityThenItHasThatPointDurability()
        {
            var pencil = new Pencil(10, 3);
            Assert.AreEqual(10, pencil.PointDurability);
        }

        [Test]
        public void WhenThePencilWritesLowercaseLetterThenThePointDurabilityDegradesByOne()
        {
            var pencil = new Pencil(4, 3);
            pencil.Write("a");

            Assert.AreEqual(3, pencil.PointDurability);
        }

        [Test]
        public void WhenThePencilWritesUppercaseLetterThenThePointDurabilityDegradesByTwo()
        {
            var pencil = new Pencil(4, 3);
            pencil.Write("A");

            Assert.AreEqual(2, pencil.PointDurability);
        }

        [Test]
        public void WhenthePencilWritestextThenThePointDurabilityDegradesByFour()
        {
            var pencil = new Pencil(4, 3);
            pencil.Write("text");

            Assert.AreEqual(0, pencil.PointDurability);
        }

        [Test]
        public void WhenthePencilWritesTextThenThePointDurabilityDegradesByFourAndPaperOnlyHasTex()
        {
            var pencil = new Pencil(4, 3);
            pencil.Write("Text");

            Assert.AreEqual(0, pencil.PointDurability);
            Assert.AreEqual("Tex", pencil.Paper);
        }

        [Test]
        public void WhenThePencilWritesASpaceThenThePointDurabilityRemainsTheSame()
        {
            var pencil = new Pencil(3, 3);
            pencil.Write(" ");

            Assert.AreEqual(3, pencil.PointDurability);
        }

        [Test]
        public void WhenThePencilWritesANewLineThenThePointDurabilityRemainsTheSame()
        {
            var pencil = new Pencil(3, 3);
            pencil.Write("\n");

            Assert.AreEqual(3, pencil.PointDurability);
        }
        #endregion

        #region Sharpen
        [Test]
        public void WhenThePencilIsCreatedItHasAnInitialPointDurability()
        {
            var pencil = new Pencil(25, 3);
            Assert.AreEqual(25, pencil.InitialPointDurability);
        }

        [Test]
        public void WhenThePencilIsSharpenedItRegainsItsInitialPointDurability()
        {
            var pencil = new Pencil(25, 3);
            pencil.Write("la de da dee daa");

            pencil.Sharpen();
            Assert.AreEqual(25, pencil.PointDurability);
        }

        [Test]
        public void WhenThePencilIsCreatedItHasAnInitialLengthValue()
        {
            var pencil = new Pencil(25, 3);
            Assert.AreEqual(3, pencil.Length);
        }

        [Test]
        public void WhenThePencilIsSharpenedTheLengthDecreasesByOne()
        {
            var pencil = new Pencil(25, 3);
            pencil.Sharpen();

            Assert.AreEqual(2, pencil.Length);
        }

        #endregion
    }
}