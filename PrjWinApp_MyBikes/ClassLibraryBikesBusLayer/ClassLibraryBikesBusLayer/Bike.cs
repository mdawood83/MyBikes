using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryBikesBusLayer
{
    [System.Xml.Serialization.XmlInclude(typeof(MountainBike))]
    [System.Xml.Serialization.XmlInclude(typeof(RoadBike))]
    [Serializable]
    public abstract class Bike : IMovable
    {
        private long serialNumber;
        protected EnumBikesType type;
        protected string make;
        protected double speed;
        protected EnumColor color;
        protected DateTime date;
        protected double price;

        public long SerialNumber { get => this.serialNumber; set => this.serialNumber = value; }

        public Bike() { }

        public Bike(long serialNumber, EnumBikesType type, string make, double speed,
           EnumColor color, DateTime date, double price)
        {
            this.type = type;
            this.serialNumber = serialNumber;
            this.make = make;
            this.speed = speed;
            this.color = color;
            this.date = date;
            this.price = price;
        }

        public override string ToString()
        {
            return this.serialNumber + " -- " + this.type + " -- " + this.make + " -- " + this.speed + "/km -- "
                + this.color + " -- " + this.date + " -- " + this.price;
        }

        public abstract void SpeedUp(double newSpeed);

        public virtual double GetMaxSpeed()
        {
            this.speed = 20;
            return this.speed;
        }
    }
}
