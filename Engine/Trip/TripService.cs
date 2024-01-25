using System;
using System.Collections.Generic;
using Engine.Exception;
using Engine.User;

namespace Engine.Trip
{
    /*
        BUSINESS RULES: Social network for travellers
        - You need to be logged in to be able to see content
        - You need to be a friend to see someone else's trips

        CODE RULES
        - You can't change code if it is not covered by tests (you can do IDE-suggested automated refactors)
    */

    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            List<Trip> tripList = new List<Trip>();
            User.User loggedUser = UserSession.GetInstance().GetLoggedUser();
            bool isFriend = false;
            if (loggedUser != null)
            {
                foreach(User.User friend in user.GetFriends())
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }
                if (isFriend)
                {
                    tripList = TripDAO.FindTripsByUser(user);
                }
                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }
    }
}
