using AutoFixture;
using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using NSubstitute;
using NUnit.Framework;
using System;

namespace MhwLoadoutCreator.MhwDbApiAccess.SmallTests
{
    public class AssemblyTestBase
    {
        protected IMhwDbApiMapper MhwDbApiMapper;
        protected IMhwDbApiClient MhwDbApiClient;

        protected Fixture Fixture;

        [SetUp]
        public void TestBaseSetUp()
        {
            MhwDbApiClient = Substitute.For<IMhwDbApiClient>();
            MhwDbApiMapper = Substitute.For<IMhwDbApiMapper>();

            Fixture = new Fixture();
        }
    }
}
