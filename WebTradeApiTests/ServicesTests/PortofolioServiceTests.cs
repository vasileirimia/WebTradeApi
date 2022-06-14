using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
    public class PortofolioServiceTests
    {
        private readonly IPortofolioService _tradeService;

        private readonly Mock<IMapper> _mapperMock;

        private readonly Mock<IPortofolioRepository> _portofolioRepositoryMock;

        private IList<PortofolioDb> dataDb;

        private IList<Portofolio> data;

        public PortofolioServiceTests()
        {
            dataDb = SetupDataDb();
            data = SetupData();

            _mapperMock = new Mock<IMapper>();
            _mapperMock.Setup(m => m.Map<IList<Portofolio>>(It.IsAny<IList<PortofolioDb>>())).Returns(data);

            _portofolioRepositoryMock = new Mock<IPortofolioRepository>();
            _portofolioRepositoryMock.Setup(m => m.GetPortofoliosAsync(CancellationToken.None)).ReturnsAsync(value: dataDb);
            _tradeService = new PortofolioService(_portofolioRepositoryMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public async Task Trade_GetPortofolios_ReturnsOk()
        {
            // Arrange & Act
            IList<Portofolio> response = await _tradeService.GetPortofoliosAsync(CancellationToken.None);

            //Assert
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(IList<Portofolio>));
            Assert.AreEqual(data.Count, response.Count);
            Assert.AreEqual(data[0], response[0]);
        }

        private IList<PortofolioDb> SetupDataDb()
        {
            var portofolios = new List<PortofolioDb>
            {
                new PortofolioDb
                {
                    PortofolioId = 1,
                    HolderName="John",
                },
                new PortofolioDb
                {
                    PortofolioId = 2,
                    HolderName="Alice",
                }
            };

            return portofolios;
        }

        private IList<Portofolio> SetupData()
        {
            var portofolios = new List<Portofolio>
            {
                new Portofolio
                {
                    PortofolioId = 1,
                    HolderName="John",
                },
                new Portofolio
                {
                    PortofolioId = 2,
                    HolderName="Alice",
                }
            };

            return portofolios;
        }
    }
}
