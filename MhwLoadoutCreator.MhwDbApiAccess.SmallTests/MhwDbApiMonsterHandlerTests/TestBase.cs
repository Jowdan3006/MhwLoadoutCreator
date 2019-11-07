using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using AutoFixture;
using MhwLoadoutCreator.Models.Monster;
using System.Linq;
using MhwLoadoutCreator.Models.Monster.Api;

namespace MhwLoadoutCreator.MhwDbApiAccess.SmallTests.MhwDbApiMonsterHandlerTests
{
    public class TestBase : AssemblyTestBase
    {
        protected IEnumerable<MonsterApi> MonstersApi;
        protected MonsterApi MonsterApi;
        protected Monsters Monsters;
        protected Monster Monster;

        protected int MonsterId;
        public static string MonstersApiJson;

        [SetUp]
        public void SetUp()
        {
            MonsterId = Fixture.Create<int>();
            MonsterApi = Fixture.Build<MonsterApi>()
                        .With(x => x.Id, MonsterId)
                        .Create();
            MonstersApi = new List<MonsterApi>()
                {
                    Fixture.Create<MonsterApi>(),
                    Fixture.Create<MonsterApi>(),
                    MonsterApi
                };

            Monster = Fixture.Build<Monster>()
                        .With(x => x.Id, MonsterId)
                        .Create();
            Monsters = Fixture.Build<Monsters>()
                .With(x => x.MonsterList, new List<Monster>()
                {
                    Fixture.Create<Monster>(),
                    Fixture.Create<Monster>(),
                    Monster
                })
                .Create();

            MonstersApiJson = Serialize.ToJson(MonstersApi.ToList());
            MhwDbApiClient.Get("monsters").Returns(MonstersApiJson);
            MhwDbApiMapper.Map(Arg.Any<List<MonsterApi>>()).Returns(Monsters);
        }


        public MhwDbApiMonsterHandler CreateSut() => new MhwDbApiMonsterHandler(MhwDbApiClient, MhwDbApiMapper);
    }



}
