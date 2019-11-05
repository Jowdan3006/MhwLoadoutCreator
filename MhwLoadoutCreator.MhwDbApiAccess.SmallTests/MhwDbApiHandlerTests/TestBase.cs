using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using MhwLoadoutCreator.Models;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using System.Linq;

namespace MhwLoadoutCreator.MhwDbApiAccess.SmallTests.MhwDbApiHandlerTests
{
    public class TestBase : AssemblyTestBase
    {
        protected HttpClient HttpClient;
        protected IMhwDbApiMapper MhwDbApiMapper;
        protected IMhwDbApiClient MhwDbApiClient;

        protected IEnumerable<MonsterApi> MonstersApi;
        protected MonsterApi MonsterApi;
        protected Monsters Monsters;
        protected Monster Monster;

        protected long MonsterId;
        public static string MonstersApiJson;

        [SetUp]
        public void SetUp()
        {
            MhwDbApiClient = Substitute.For<IMhwDbApiClient>();
            MhwDbApiMapper = Substitute.For<IMhwDbApiMapper>();

            MonsterId = Fixture.Create<long>();
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

            MonstersApiJson = Serialize.ToJson(MonstersApi.ToArray());
            MhwDbApiClient.Get("monsters").Returns(MonstersApiJson);
            MhwDbApiMapper.Map(Arg.Any<List<MonsterApi>>()).Returns(Monsters);
        }


        public MhwDbApiHandler CreateSut() => new MhwDbApiHandler(MhwDbApiClient, MhwDbApiMapper);
    }



}
