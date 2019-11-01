using AutoFixture;
using NUnit.Framework;
using System;

namespace MhwLoadoutCreator.MhwDbApiAccess.SmallTests
{
    public class AssemblyTestBase
    {
        protected Fixture Fixture;

        [SetUp]
        public void TestBaseSetUp()
        {
            Fixture = new Fixture();
        }
    }
}
