using GeodeticPDA.DataGeneration;
using GeodeticPDA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticPDA.Presenter
{
    class GeodeticPdaPresenter
    {
        private readonly GeodeticPdaSystem _pdaSystem;

        public GeodeticPdaPresenter(bool initializeWithRandomData = true)
        {
            if (initializeWithRandomData)
            {
                var randomProperties = RandomDataGenerator.GenerateProperties(1000);
                var randomParcels = RandomDataGenerator.GenerateParcels(1000);
                _pdaSystem = new GeodeticPdaSystem(randomProperties, randomParcels);
            }
            else
            {
                _pdaSystem = new GeodeticPdaSystem();
            }
        }

    }
}
