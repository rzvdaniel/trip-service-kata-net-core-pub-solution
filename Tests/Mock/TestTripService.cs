using Engine.Trip;
using Engine.User;
using System.Collections.Generic;

namespace Tests.Mock
{
    internal class TestTripService : TripService
    {
        public TestTripService(User loggedInUser)
        {
            this.loggedInUser = loggedInUser;
        }
        public User loggedInUser;

        protected override User GetLoggedUser()
        {
            return loggedInUser ?? null;
        }

        protected override List<Trip> FindTripsByUser(User user)
        {
            return user.Trips();
        }
    }
}
