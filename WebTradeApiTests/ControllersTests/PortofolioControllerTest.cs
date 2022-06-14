using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
    public class PortofolioControllerTest
    {
        private readonly PortofolioController _portofolioController;

        private readonly Mock<IPortofolioService> _portofolioServiceMock;

        private List<Portofolio> data;

        public PortofolioControllerTest()
        {
            _portofolioServiceMock = new Mock<IPortofolioService>();
            _portofolioController = new PortofolioController(_portofolioServiceMock.Object);
            data = SetupData();
            SetupDependencies();
        }

        [TestMethod]
        public async Task Portofolio_GetPortofolios_ReturnsOk()
        {
            //Arrange & Act
            var response = await _portofolioController.GetPortofoliosAsync(CancellationToken.None);
            ObjectResult actualResult = response as ObjectResult;
            var actualResponse = actualResult?.Value as IList<Portofolio>;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(actualResponse, typeof(IList<Portofolio>));
            Assert.AreEqual((int)HttpStatusCode.OK, actualResult.StatusCode);
        }

        private List<Portofolio> SetupData()
        {
            var portofolios = new List<Portofolio>
            {
                new Portofolio
                {
                     HolderName = "John" ,PortofolioId = 1
                },
                new Portofolio
                {
                     HolderName = "Alice" ,PortofolioId = 2
                }
            };

            return portofolios;
        }

        private void SetupDependencies()
        {
            _portofolioServiceMock.Setup(m => m.GetPortofoliosAsync(CancellationToken.None)).ReturnsAsync(value: data);
        }
    }
}
