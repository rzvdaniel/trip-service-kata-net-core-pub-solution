using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.User
{
    public class User
    {
        private List<Trip.Trip> trips = new List<Trip.Trip>();
        private List<User> friends = new List<User>();

        public List<User> GetFriends()
        {
            return friends;
        } 

        public void AddFriend(User user)
        {
            friends.Add(user);
        }

        public void AddTrip(Trip.Trip trip)
        {
            trips.Add(trip);
        }

        public List<Trip.Trip> Trips()
        {
            return trips;
        }

        public bool IsFriend(User user)
        {
            var isFriend = user.GetFriends().Any(x => x.Equals(this));

            return isFriend;
        }
    }
}
