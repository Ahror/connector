using Autofac.Extras.Moq;
using Moq;
using System;

namespace Connector.Tests
{
    /// <summary>
    /// Base class for tests
    /// </summary>
    public class BaseAutoMockedTest<T> : IDisposable where T : class
    {
        protected T TestController => Mocker.Create<T>();

        protected AutoMock Mocker { get; }

        public BaseAutoMockedTest()
        {
            Mocker = AutoMock.GetLoose();
        }

        protected Mock<TDepend> GetMock<TDepend>() where TDepend : class
        {
            return Mocker.Mock<TDepend>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
