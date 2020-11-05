using GeodeticPDA.Model;
using System.Linq;

namespace GeodeticPDA.Presenter
{
    /// <summary>
    /// Input data from user for <c>Property</c>.
    /// </summary>
    public class PropertyInputData : UserInputData
    {
        public Property OriginalObject { get; }

        public PropertyInputData(Property property) : base(property)
        {
            base.RelatedObjects = property.Parcels.ToArray();
            OriginalObject = property;
        }

        public PropertyInputData() : base()
        {
        }

    }
}
