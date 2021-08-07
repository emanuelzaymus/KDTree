using GeodeticPDA.Model;

namespace GeodeticPDA.Presenter
{
    public class ElementInputData
    {
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Value { get; set; }

        public Element OriginalElement { get; set; }

        public ElementInputData()
        {
        }

        public ElementInputData(string key1, string key2, string value)
        {
            Key1 = key1;
            Key2 = key2;
            Value = value;
        }
    }
}
