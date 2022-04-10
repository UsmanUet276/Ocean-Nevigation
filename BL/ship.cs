using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Nevigation.BL
{
    internal class ship
    {
        public ship(string shipNumber , int latitudeDegree , float latitudeMinute , char latitudeDirection, int longitudeDegree, float longitudeMinute, char longitudeDirection)
        {
            this.shipNumber = shipNumber;
            this.latitudeDegree = latitudeDegree;
            this.latitudeMinute = latitudeMinute;
            this.latitudeDirection = latitudeDirection;
            this.longitudeDegree = longitudeDegree;
            this.longitudeMinute = longitudeMinute;
            this.longitudeDirection = longitudeDirection;
        }
        public string shipNumber;
        public int latitudeDegree;
        public float latitudeMinute;
        public char latitudeDirection;
        public int longitudeDegree;
        public float longitudeMinute;
        public char longitudeDirection;
        public bool compare(ship otherShip)
        {
            if (this.latitudeDegree == otherShip.latitudeDegree && this.latitudeMinute == otherShip.latitudeMinute && this.latitudeDirection == otherShip.latitudeDirection && this.longitudeDegree == otherShip.longitudeDegree && this.longitudeMinute == otherShip.longitudeMinute && this.longitudeDirection == otherShip.longitudeDirection)
                return true;
            else
                return false;
        }
        public void copy(ship temp)
        {
            latitudeDegree = temp.latitudeDegree;
            latitudeMinute = temp.latitudeMinute;
            latitudeDirection = temp.latitudeDirection;
            longitudeDegree = temp.longitudeDegree;
            longitudeMinute = temp.longitudeMinute;
            longitudeDirection = temp.longitudeDirection;
        }
    }
}
