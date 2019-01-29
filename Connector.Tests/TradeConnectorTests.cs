using Connector.Abstractions;
using Connector.Connectors;
using Connector.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Connector.Tests
{
    [TestClass]
    public class TradeConnectorTests : BaseAutoMockedTest<TradeConnector>
    {
        [TestMethod]
        public async Task GetRestEntitiesAsync_Should_Return_All_Trades()
        {
            string query = "v2/trades/tBTCUSD/hist";
            //Creating courses and coursedtos
            var trades = Enumerable.Repeat(new Trade() { }, 5).ToList();

            //Mocking
            GetMock<IConnector<Trade>>().Setup(x => x.GetRestEntitiesAsync(query).Result).Returns(trades);

            //Testing
            var result = await TestController.GetRestEntitiesAsync(query);
            result.Should().Equal(trades);
        }
    }
}
