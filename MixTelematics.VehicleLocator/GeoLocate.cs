using System;
namespace MixTelematics.VehicleLocator
{
	public class GeoLocate
	{
        public static double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            if (lat1 < -90 || lat1 > 90)
                throw new ArgumentOutOfRangeException($"{nameof(lat1)} outside of allowable bounds");

            if (lon1 < -180 || lon1 > 180)
                throw new ArgumentOutOfRangeException($"{nameof(lon1)} outside of allowable bounds");

            if (lat2 < -90 || lat2 > 90)
                throw new ArgumentOutOfRangeException($"{nameof(lat2)} outside of allowable bounds");

            if (lon2 < -180 || lon2 > 180)
                throw new ArgumentOutOfRangeException($"{nameof(lon2)} outside of allowable bounds");

            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }
    }
}

