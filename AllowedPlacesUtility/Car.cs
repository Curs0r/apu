using System.Drawing;

namespace APU
{
    class Car
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public string Path { get; set; }
        public Image Image { get; set; }
        public bool Auction { get; set; }
        public bool Junkyard { get; set; }
        public bool Salon { get; set; }
        public bool Shed { get; set; }
        public decimal UniqueMod { get; set; }
    }
}
