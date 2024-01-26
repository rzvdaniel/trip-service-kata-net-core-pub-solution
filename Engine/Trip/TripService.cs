using Engine.Exception;
using Engine.User;
using System.Collections.Generic;

namespace Engine.Trip
{
    /*
        BUSINESS RULES: Social network for travellers
        - You need to be logged in to be able to see content
        - You need to be a friend to see someone else's trips

        CODE RULES
        - You can't change code if it is not covered by tests (you can do IDE-suggested automated refactors)
        - You cannot change the public interface of TripService
        - You cannot introduce state in TripService
    */

    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            var loggedInUser = GetLoggedUser() ?? 
                throw new UserNotLoggedInException();

            var isFriend = loggedInUser.IsFriend(user);

            var tripList = isFriend ? 
                FindTripsByUser(user) :
                new List<Trip>();

            return tripList;
        }

        protected virtual User.User GetLoggedUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }

        protected virtual List<Trip> FindTripsByUser(User.User user)
        {
            return TripDAO.FindTripsByUser(user);
        }
    }
}
