using GeodeticPDA.Model;
using System.Linq;

namespace GeodeticPDA.Presenter
{
    public class ParcelInputData : UserInputData
    {
        public Parcel OriginalObject { get; }

        public ParcelInputData(Parcel parcel) : base(parcel)
        {
            RelatedObjects = parcel.Properties.ToArray();
            OriginalObject = parcel;
        }

        public ParcelInputData() : base()
        {
        }

    }
}
