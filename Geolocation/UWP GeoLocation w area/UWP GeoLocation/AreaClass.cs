using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace UWP_GeoLocation
{ 
    /// <summary>
    /// class to store the points in a rectangle or a triangle
    /// will calculate the area, but not very well for small spaces
    /// due to the accuracy of GPS
    /// works well for larger areas like car parks and fields
    /// the formulae used are standard for GPS calculations if you 
    /// do a little research
    /// </summary>
    class AreaClass
    {
        // need 4 points for each corner (only does square/rectangles)
        private List<Geoposition> listPositions;

        public int numPoints()
        {
            return listPositions.Count();
        }

        public AreaClass()
        {
            listPositions = new List<Geoposition>();
        } 

        public void addPointToArray(Geoposition pos)
        {
            listPositions.Add(pos);
        }

        public double distanceBetweenPoints(int p1, int p2)
        {
            // sqrt( (x2-x1)sq  + (y2 - y1)sq)
            // do the x-x and y-y maths
            double x2x1, y2y1;

            x2x1 = listPositions[p2].Coordinate.Point.Position.Latitude -
                    listPositions[p1].Coordinate.Point.Position.Latitude;
            y2y1 = listPositions[p2].Coordinate.Point.Position.Longitude -
                    listPositions[p1].Coordinate.Point.Position.Longitude;

            return (Math.Sqrt((x2x1 * x2x1) + (y2y1 * y2y1)));
        }
        /// <summary>
        /// Yet another formula for calculating distance between two points.
        /// 
        /// </summary>
        /// <param name="p1">subscript into array for first point</param>
        /// <param name="p2">subscript into array for second point</param>
        /// <returns></returns>
        public double distanceAB(int p1, int p2)
        {
            double dist;
            double lon1, lon2, lat1, lat2;
            lon1 = listPositions[p1].Coordinate.Point.Position.Longitude;
            lon2 = listPositions[p2].Coordinate.Point.Position.Longitude;
            lat1 = listPositions[p1].Coordinate.Point.Position.Latitude;
            lat2 = listPositions[p2].Coordinate.Point.Position.Latitude;

            // convert to radians
            lon1 = deg2rad(lon1);
            lon2 = deg2rad(lon2);
            lat1 = deg2rad(lat1);
            lat2 = deg2rad(lat2);

            double R = 6273;    // radius of earth in km
            //distance(A, B) = R * arccos(sin(latA) * sin(latB) + cos(latA) * cos(latB) * cos(lonA - lonB))

            double sinePart = Math.Sin(lat1) * Math.Sin(lat2);
            double cosPart = Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lon1 - lon2);
            dist = R * Math.Acos(sinePart + cosPart);

            // convert to metres
            dist *= 1000;
            return dist;
        }

        public double distanceTheta(int p1, int p2)
        {
            double dist;
            double l1, l2, lat1, lat2;
            l1 = listPositions[p1].Coordinate.Point.Position.Longitude;
            l2 = listPositions[p2].Coordinate.Point.Position.Longitude;
            lat1 = listPositions[p1].Coordinate.Point.Position.Latitude;
            lat2 = listPositions[p2].Coordinate.Point.Position.Latitude;

            double theta = l1 - l2;

            dist = Math.Sin(deg2rad(lat1)) *
                    Math.Sin(deg2rad(lat2)) +
                    Math.Sin(deg2rad(l1)) *
                    Math.Sin(deg2rad(l2)) * Math.Cos(deg2rad(theta));

            dist = Math.Acos(dist);

            dist = rad2deg(dist);

            dist = dist * 1.1515 * 60;  // distance in miles

            dist = dist * 1.609344; // km

            dist *= 1000; // metres

            return dist;
        }
        
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.00);
        }

        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.00);
        }

        public double areaOfShape(string shapeType)
        {
            double area = 0;

            switch (shapeType)
            {
                case "triangle": // not implemented yet
                    break;
                case "rectangle":
                    //double d1 = distanceBetweenPoints(0,1);
                    //double d2 = distanceBetweenPoints(1, 2);
                    //or
                    //double d1 = distanceTheta(0, 1);
                    //double d2 = distanceTheta(1, 2);                    
                    //or
                    double d1 = distanceAB(0, 1);
                    double d2 = distanceAB(1, 2);
                    area = d1 * d2;

                    break;
                default:
                    break;
            }
            return area;
        }
    }
}
