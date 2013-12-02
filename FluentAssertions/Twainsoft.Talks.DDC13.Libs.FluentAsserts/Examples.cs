using System;
using FluentAssertions;
using NUnit.Framework;

namespace Twainsoft.Talks.DDC13.Libs.FluentAsserts
{
    [TestFixture]
    public class Examples
    {
        [Test]
        public void StringTests()
        {
            "Hallo Welt"
                .Should()
                .Be("Hallo Welt")
                .And.EndWith("t");
        }

        [Test]
        public void CollectionTests()
        {
            new[] { 1, 2, 3, 4 }
                .Should()
                .Contain(item => item > 3, "the collection should be larger than 3", 1);
            new[] {1, 2, 3, 4}.Should().HaveCount(4);
        }

        [Test]
        public void NumericTests()
        {
            123.Should().BeLessThan(124);
        }

        [Test]
        public void DateTimeTests()
        {
            DateTime.Now.Should().BeAfter(2.December(2013).At(11, 00));
        }

        [Test]
        public void ExceptionTests()
        {
            Action act = ArgumentException;

            act.ShouldNotThrow<ArgumentException>();
        }

        private void ArgumentException()
        {
            throw new ArgumentException();
        }
    }
}
