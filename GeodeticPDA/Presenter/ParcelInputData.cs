using GeodeticPDA.Model;
using System.Linq;

namespace GeodeticPDA.Presenter
{
    /// <summary>
    /// Input data from user for <c>Parcel</c>.
    /// </summary>
    public class ParcelInputData : UserInputData
    {
        public Parcel OriginalObject { get; }

        public ParcelInputData(Parcel parcel) : base(parcel)
        {
            base.RelatedObjects = parcel.Properties.ToArray();
            OriginalObject = parcel;
        }

        public ParcelInputData() : base()
        {
        }

    }
}
