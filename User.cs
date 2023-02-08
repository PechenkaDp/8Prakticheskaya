using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Prakticheskaya
{
    internal class user
    {
        public string Name;
        public double SpeedInMin;
        public double SpeedInSec;
        public user(string name, double speedmin, double speedsec)
        {
            Name = name;
            SpeedInSec = speedsec;
            SpeedInMin = speedmin;
        }
    }
}
