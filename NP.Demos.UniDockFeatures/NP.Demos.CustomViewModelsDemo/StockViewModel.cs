using NP.Utilities;
using System.Xml.Serialization;

namespace NP.Demos.CustomViewModelsDemo
{
    public class StockViewModel : VMBase
    {
        [XmlAttribute]
        public string? Symbol { get; set; }

        [XmlAttribute]
        public string? Description { get; set; }

        [XmlAttribute]
        public decimal Ask { get; set; }

        [XmlAttribute]
        public decimal Bid { get; set; }

        public override string ToString()
        {
            return $"StockViewModel: Symbol={Symbol}, Ask={Ask}";
        }
    }
}
