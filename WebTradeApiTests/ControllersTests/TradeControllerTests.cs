using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Controllers;
using WebTradeApi.Models;
using WebTradeApi.Services;

namespace WebTradeApiTests.ControllersTests
{
    [TestClass]
    public class TradeControllerTests
    {
        private readonly TradeController _tradeController;

        private readonly Mock<ITradeService> _tradeServiceMock;

        private IList<Trade> data;

        public TradeControllerTests()
        {
            _tradeServiceMock = new Mock<ITradeService>();
            _tradeController = new TradeController(_tradeServiceMock.Object);
            data = SetupData();
            SetupDependencies();
        }

        [TestMethod]
        public async Task Trade_GetTrades_ReturnsOk()
        {
            //Arrange & Act
            var response = await _tradeController.GetTradesAsync(It.IsAny<string>(), CancellationToken.None);
            ObjectResult actualResult = response as ObjectResult;
            var actualResponse = actualResult?.Value as IList<Trade>;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(actualResponse, typeof(IList<Trade>));
            Assert.AreEqual((int)HttpStatusCode.OK, actualResult.StatusCode);
        }

        private void SetupDependencies()
        {
            _tradeServiceMock.Setup(m => m.GetTradesAsync(It.IsAny<string>(), CancellationToken.None)).ReturnsAsync(value: data);
        }

        private IList<Trade> SetupData()
        {
            var trades = new List<Trade>
            {
                new Trade
                {
                    SecurityCode = "MSFT",
                    TradePrice = 10,
                    TradeQuantity = 2,
                    TradeDate= new DateTime(2021, 8, 10),
                    TradeBuyer = "John"
                },
                new Trade
                {
                    SecurityCode = "MSFT",
                    TradePrice = 10,
                    TradeQuantity = 3,
                    TradeDate= new DateTime(2021, 8, 10),
                    TradeBuyer = "John"
                },
                new Trade
                {
                    SecurityCode = "AAPL",
                    TradePrice = 10,
                    TradeQuantity = 4,
                    TradeDate= new DateTime(2021, 8, 10),
                    TradeBuyer = "John"
                }
            };

            return trades;
        }
    }
}
