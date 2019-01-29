using Connector.Abstractions;
using Connector.Connectors;
using Connector.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Tests
{
    [TestClass]
    public class CandleConnectorTests : BaseAutoMockedTest<CandleConnector>
    {
        [TestMethod]
        public async Task GetRestEntitiesAsync_Should_Return_All_Candles()
        {
            //Creating courses and coursedtos
            var candles = Enumerable.Repeat(new Candle() { }, 5).ToList();

            //Mocking
            GetMock<IConnector<Candle>>().Setup(x => x.GetRestEntitiesAsync("").Result).Returns(candles);

            //Testing
            var result = await TestController.GetRestEntitiesAsync("");
            result.Should().Equal(candles);
        }
    }
}
