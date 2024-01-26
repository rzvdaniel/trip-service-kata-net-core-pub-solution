using Engine.Exception;
using Engine.Trip;
using Engine.User;
using System.ComponentModel;
using System.Linq;
using Tests.Mock;
using Xunit;

namespace Tests
{
    public class TripServiceTests
    {
        [Fact]
        [Description("Should pass if the user is not logged in")]
        public void UserIsNotLoggedIn()
        {
            var tripServiceTest = new TestTripService(null);

            Assert.Throws<UserNotLoggedInException>(() => tripServiceTest.GetTripsByUser(new User()));
        }

        [Fact]
        [Description("Should pass if the user can see other user's trips")]
        public void UserHasTrips()
        {
            var loggedInUser = new User();

            var tripServiceTest = new TestTripService(loggedInUser);

            var userWithFriends = new User();
            userWithFriends.AddFriend(loggedInUser);
            userWithFriends.AddTrip(new Trip());

            var trips = tripServiceTest.GetTripsByUser(userWithFriends);

            var canSeeTrips = trips.Any();

            Assert.True(canSeeTrips);
        }

        [Fact]
        [Description("Should pass if the user can NOT see other user's trips")]
        public void UserCanNotSeeTrips()
        {
            var loggedInUser = new User();

            var tripServiceTest = new TestTripService(loggedInUser);

            var userWithFriends = new User();
            userWithFriends.AddFriend(loggedInUser);

            var trips = tripServiceTest.GetTripsByUser(userWithFriends);

            var canSeeTrips = trips.Any();

            Assert.False(canSeeTrips);
        }
    }
}
