using Singleton.src.entities;
using Xunit;

namespace SingletonTest
{
    public class SingletonTest
    {
        
        [Fact]
        public void TestMultipleCallsReturnSameObjectInSameThread()
        {
            var instance1 = IvoryTower.GetInstance;
            var instance2 = IvoryTower.GetInstance;
            var instance3 = IvoryTower.GetInstance;

            Assert.Same(instance1, instance2);
            Assert.Same(instance1, instance3);
            Assert.Same(instance2, instance3);
        }
    }
}
