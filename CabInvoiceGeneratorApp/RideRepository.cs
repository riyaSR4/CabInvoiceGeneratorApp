using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorApp
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = new Dictionary<string, List<Ride>>();
        public void AddRides(string userId, Ride[] ride)
        {
            bool isExist = userRides.ContainsKey(userId);
            List<Ride> rides = new List<Ride>();
            if (!isExist)
            {
                rides.AddRange(ride);
                userRides.Add(userId, rides);
            }
            else
            {
                foreach(var data in userRides)
                {
                    if(data.Key.Equals(userId))
                    {
                        rides = data.Value;
                    }
                }
                foreach(var item in ride)
                {
                    rides.Add(item);
                }
            }
        }
        public Ride[] GetRides(string userId)
        {
            return userRides[userId].ToArray();
        }
    }
}
