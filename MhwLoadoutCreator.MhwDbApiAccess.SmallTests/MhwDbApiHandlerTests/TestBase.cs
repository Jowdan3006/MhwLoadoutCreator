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
        protected MyHttpMessageHandler HttpMessageHandler;
        protected IMhwDbApiMapper MhwDbApiMapper;

        protected MonstersApi MonstersApi;
        protected MonsterApi MonsterApi;
        protected Monsters Monsters;

        protected long MonsterId;
        public static string MonstersApiJson;

        [SetUp]
        public void SetUp()
        {
            HttpMessageHandler = new MyHttpMessageHandler();
            HttpClient = new HttpClient(HttpMessageHandler)
            {
                BaseAddress = Fixture.Create<Uri>()
            };
            MhwDbApiMapper = Substitute.For<IMhwDbApiMapper>();

            MonsterId = Fixture.Create<long>();
            MonsterApi = Fixture.Build<MonsterApi>()
                        .With(x => x.Id, MonsterId)
                        .Create();
            MonstersApi = Fixture.Build<MonstersApi>()
                .With(x => x.MonsterList, new List<MonsterApi>()
                {
                    Fixture.Create<MonsterApi>(),
                    Fixture.Create<MonsterApi>(),
                    MonsterApi
                })
                .Create();

            Monsters = Fixture.Create<Monsters>();
            MonstersApiJson = Serialize.ToJson(MonstersApi.MonsterList.ToArray());
            MhwDbApiMapper.Map(MonstersApi).Returns(Monsters);
        }


        public MhwDbApiHandler CreateSut() => new MhwDbApiHandler(HttpClient, MhwDbApiMapper);
    }

    public class MyHttpMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var reponse = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(TestBase.MonstersApiJson)
            };

            return Task.FromResult(reponse);
        }
    }

}
