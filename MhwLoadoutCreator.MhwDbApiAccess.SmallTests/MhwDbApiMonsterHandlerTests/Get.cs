using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MhwLoadoutCreator.MhwDbApiAccess.SmallTests.MhwDbApiMonsterHandlerTests
{
    public class Get : TestBase
    {
        [Test]
        public async Task Get_WithNoParams_ReturnsValidMonsters()
        {
            //arrange
            var sut = CreateSut();

            //act
            var result = await sut.Get();

            //assert
            result.Should().BeEquivalentTo(Monsters);
        }

        [Test]
        public async Task Get_WithId_ReturnsValidMonster()
        {
            //arrange
            var sut = CreateSut();


            //act
            var result = await sut.Get(MonsterId);

            //assert
            result.Should().BeEquivalentTo(Monster);
        }
    }
}
