using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebTradeApi.Models;
using WebTradeApi.Persistece.Entities;
using WebTradeApi.Persistece.Repository;
using WebTradeApi.Services;

namespace WebTradeApiTests.ServicesTests
{
    [TestClass]
    public class TradeServiceTests
    {
        private readonly ITradeService _tradeService;

        private readonly Mock<IMapper> _mapperMock;

        private readonly Mock<ITradeRepository> _tradeRepositoryMock;

        private IList<TradeDb> dataDb;

        private IList<Trade> data;
        public TradeServiceTests()
        {
            dataDb = SetupDataDb();
            data = SetupData();

            _mapperMock = new Mock<IMapper>();
            _mapperMock.Setup(m => m.Map<IList<Trade>>(It.IsAny<IList<TradeDb>>())).Returns(data);

            _tradeRepositoryMock = new Mock<ITradeRepository>();
            _tradeRepositoryMock.Setup(m => m.GetTradesAsync(It.IsAny<string>(), CancellationToken.None)).ReturnsAsync(value: dataDb);
            _tradeService = new TradeService(_tradeRepositoryMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public async Task Trade_GetTrades_ReturnsOk()
        {
            //Arrange & Act
            IList<Trade> response = await _tradeService.GetTradesAsync(It.IsAny<string>(), CancellationToken.None);

            //Assert
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(IList<Trade>));
            Assert.AreEqual(data.Count, response.Count);
            Assert.AreEqual(data[0], response[0]);
        }

        [TestMethod]
        public async Task Trade_GetTradesByName_ReturnsOk()
        {
            //Arrange
            TradeDb tradeDb = dataDb[0];
            Trade trade = data[0];

            //Act
            IList<Trade> response = await _tradeService.GetTradesAsync(tradeDb.TradeBuyer, CancellationToken.None);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(trade.SecurityCode, response[0].SecurityCode);
            Assert.AreEqual(trade.TradeBuyer, response[0].TradeBuyer);
        }

        private IList<TradeDb> SetupDataDb()
        {
            var trades = new List<TradeDb>
            {
                new TradeDb
                {
                   SecurityCode = "AAPL",
                    TradePrice = 12,
                    TradeQuantity = 5,
                    TradeDate= new DateTime(2021, 8, 10),
                    TradeBuyer = "Alice"
                }
            };

            return trades;
        }

        private IList<Trade> SetupData()
        {
            var trades = new List<Trade>
            {
                new Trade
                {
                   SecurityCode = "AAPL",
                    TradePrice = 12,
                    TradeQuantity = 5,
                    TradeDate= new DateTime(2021, 8, 10),
                    TradeBuyer = "Alice"
                }
            };

            return trades;
        }
    }
}