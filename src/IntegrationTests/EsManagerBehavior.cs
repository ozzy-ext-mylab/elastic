﻿using System;
using System.Threading.Tasks;
using IntegrationTests.Stuff;
using MyLab.Elastic;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests
{
    public class EsManagerBehavior : IClassFixture<ClientFixture>
    {
        private readonly IEsManager _mgr;

        public EsManagerBehavior(ClientFixture clFx, ITestOutputHelper output)
        {
            _mgr = new EsManager(new SingleEsClientProvider(clFx.EsClient), new ElasticsearchOptions());
        }

        [Fact]
        public async Task ShouldPing()
        {
            //Arrange
            

            //Act
            var hasPing = await _mgr.PingAsync();

            //Assert
            Assert.True(hasPing);
        }

        [Fact]
        public async Task ShouldNotDetectAbsentIndex()
        {
            //Arrange


            //Act
            var exists = await _mgr.IsIndexExistsAsync("blabla");

            //Assert
            Assert.False(exists);
        }

        [Fact]
        public async Task ShouldDetectExistentIndex()
        {
            //Arrange
            var indexName = "test-index-" + Guid.NewGuid().ToString("N");
            bool exists;

            await using (await _mgr.CreateIndexAsync(indexName))
            {
                //Act
                exists = await _mgr.IsIndexExistsAsync(indexName);
            }

            //Assert
            Assert.True(exists);
        }
    }
}
