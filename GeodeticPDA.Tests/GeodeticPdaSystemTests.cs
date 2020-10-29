using GeodeticPDA.Model;
using GeodeticPDA.DataGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeodeticPDA.Tests
{
    [TestClass]
    public class GeodeticPdaSystemTests
    {
        private GeodeticPdaSystem GetPdaSystem()
        {
            return new GeodeticPdaSystem();
        }

        private GeodeticPdaSystem GetRandomPdaSystem()
        {
            var randomProperties = RandomDataGenerator.GenerateProperties(1000);
            var randomParcels = RandomDataGenerator.GenerateParcels(1000);
            return new GeodeticPdaSystem(randomProperties, randomParcels);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var s = GetRandomPdaSystem();
        }

    }
}
