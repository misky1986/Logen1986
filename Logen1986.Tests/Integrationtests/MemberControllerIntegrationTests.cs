using FluentAssertions;
using Logen1986.API;
using Logen1986.API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Logen1986.Tests
{
    public class MemberControllerIntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public MemberControllerIntegrationTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Test_Get_All_Members()
        {
            // Act
            var response = await _client.GetAsync("/api/Members");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Hello World;!!\n"+responseString+"\n");
            // Assert
            var members = JsonConvert.DeserializeObject<IEnumerable<Member>>(responseString);
            members.Count().Should().Be(50);
        }

        [Fact]
        public async Task Test_Get_Specific_Member()
        {
            // Act
            var response = await _client.GetAsync("/api/Members/8");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            var members = JsonConvert.DeserializeObject<Member>(responseString);
            members.Id.Should().Be(8);
        }
    }
}
