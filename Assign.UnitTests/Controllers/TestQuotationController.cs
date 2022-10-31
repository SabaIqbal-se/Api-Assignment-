using Assign.Api.Models;
using Assign.Api.Service;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Assign.UnitTests.System.Controllers
{
    public class TestQuotationController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange
            var mockQuotationService = new Mock<IQuotationService>();
            var _mapper = new Mock<IMapper>();
            mockQuotationService
                .Setup(service => service.GetExtrasbyCityId(1))
                .ReturnsAsync(new List<Extras>()
                {
                    new()
                    {
                        ExtrasId = 1,
                        ExtrasName = "Windows"
                    }

                });
            var sut = new Api.Controllers.QuotationController(mockQuotationService.Object, _mapper.Object);
            //Act
            var result = await sut.GetById(1);

            //Assert

            result.Should().BeOfType<OkObjectResult>();
            var objResult = (OkObjectResult)result;
            objResult.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task Get_OnSuccess_InvokeCityPriceServiceExactlyOnce()
        {
            //Arrange
            var mockQuotationService = new Mock<IQuotationService>();
            var _mapper = new Mock<IMapper>();

            var sut = new Api.Controllers.QuotationController(mockQuotationService.Object, _mapper.Object );
            mockQuotationService
                .Setup(service => service.GetExtrasbyCityId(1))
                .ReturnsAsync(new List<Extras>());
            //Act
            var result = await sut.GetById(1);

            //Assert
            mockQuotationService.Verify(
                service => service.GetExtrasbyCityId(1),
                Times.Once()
                );

        }
        [Fact]
        public async Task Get_OnNoUserFound_Returns404()
        {
            //Arrange
            var mockQuotationService = new Mock<IQuotationService>();
            var _mapper = new Mock<IMapper>();

            mockQuotationService
                .Setup(service => service.GetExtrasbyCityId(1))
                .ReturnsAsync(new List<Extras>());
            var sut = new Api.Controllers.QuotationController(mockQuotationService.Object, _mapper.Object);

            //Act
            var result = await sut.GetById(1);

            //Assert
            result.Should().BeOfType<NotFoundResult>();
            var objResult = (NotFoundResult)result;
            objResult.StatusCode.Should().Be(404);

        }

    }
}