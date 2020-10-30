using GeodeticPDA.Model;
using System.Linq;

namespace GeodeticPDA.Presenter
{
    public class PropertyInputData : UserInputData
    {
        public Property OriginalObject { get; }

        public PropertyInputData(Property property) : base(property)
        {
            RelatedObjects = property.Parcels.ToArray();
            OriginalObject = property;
        }

        public PropertyInputData() : base()
        {
        }

    }
}
