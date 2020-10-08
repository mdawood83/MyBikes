using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryBikesBusLayer
{
    [Serializable]
    public class MountainBike : Bike
    {
        private EnumSuspension suspension;
        private double height;

        public EnumSuspension Suspension { get => suspension; set => suspension = value; }
        public double Height { get => height; set => height = value; }

        public EnumBikesType Type { get => type; set => type = value; }
        public string Make { get => make; set => make = value; }
        public double Speed { get => speed; set => speed = value; }
        public EnumColor Color { get => color; set => color = value; }
        public DateTime Date { get => date; set => date = value; }
        public double Price { get => price; set => price = value; }


        public MountainBike() : base() { }

        public MountainBike(long serialNumber, EnumBikesType type, string make, double speed,
                EnumColor color, DateTime date, double price, EnumSuspension suspension, double height)
                            : base(serialNumber, type, make, speed, color, date, price)
        {
            this.suspension = suspension;
            this.height = height;
        }

        public override string ToString() => base.ToString() + " -- " + this.suspension + " -- " + this.height + " cm"
                                        + " -- " + GetMaxSpeed();

        public override void SpeedUp(double newSpeed)
        {
            if (this.speed + newSpeed < GetMaxSpeed())
                this.speed += newSpeed;
            else
                this.speed = GetMaxSpeed();
        }
    }
}
