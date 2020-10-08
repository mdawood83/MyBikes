using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryBikesBusLayer
{
    public interface IMovable
    {
        double GetMaxSpeed();
        void SpeedUp(double newSpeed);
    }
}
