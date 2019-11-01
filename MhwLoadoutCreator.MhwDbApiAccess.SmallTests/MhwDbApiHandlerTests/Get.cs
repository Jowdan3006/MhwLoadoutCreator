using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MhwLoadoutCreator.MhwDbApiAccess.SmallTests.MhwDbApiHandlerTests
{
    public class Get : TestBase
    {
        [Test]
        public async Task Get_WithNoParams_ReturnsValidMonstersApi()
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = await sut.Get();

            //assert
            result.MonsterList.Should().BeEquivalentTo(MonstersApi);
        }
    }
}
