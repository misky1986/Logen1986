using FluentAssertions;
using Logen1986.API.Controllers;
using Logen1986.API.Models;
using Logen1986.API.Service;
using Logen1986.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Logen1986.Tests
{
    public class MemberControllerUnitTests
    {
        [Fact]
        public async Task Test_Get_All_Members()
        {
            // Arrange
            var controller = new MembersController(new MemberService());

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var members = okResult.Value.Should().BeAssignableTo<IEnumerable<Member>>().Subject;

            members.Count().Should().Be(50);
        }

        [Fact]
        public async Task Test_Get_Specific_Member()
        {
            // Arrange
            var controller = new MembersController(new MemberService());

            // Act
            var result = await controller.Get(3);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var members = okResult.Value.Should().BeAssignableTo<Member>().Subject;

            members.Id.Should().Be(3);
        }

        // The above two unit test does not isolate the code to test, meaning that the service is not mocked out.
        // The below test uses a mock to get in control of the MemberService

        [Fact]
        public async Task Persons_Get_From_Moq()
        {
            // Arrange
            var serviceMock = new Mock<IMemberService>();
            serviceMock.Setup(x => x.GetAll()).Returns(() => new List<Member>()
            {
                new Member{Id=1, FirstName="Foo1", LastName="Bar1", Age=31},
                new Member{Id=2, FirstName="Foo2", LastName="Bar2", Age=32},
                new Member{Id=3, FirstName="Foo3", LastName="Bar3", Age=33},
                new Member{Id=4, FirstName="Foo4", LastName="Bar4", Age=34},
            });
            

            var controller = new MembersController(serviceMock.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var persons = okResult.Value.Should().BeAssignableTo<IEnumerable<Member>>().Subject;

            persons.Count().Should().Be(4);
        }
    }
}
