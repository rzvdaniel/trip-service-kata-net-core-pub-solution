using Engine.User;
using System.ComponentModel;
using Xunit;

namespace Tests
{
    public class UserServiceTests
    {
        [Fact]
        [Description("Should pass if the user does not have friends")]
        public void UserIsNotFriend()
        {
            var friend = new User();
            var userWithFriends = new User();

            var hasFriends = userWithFriends.IsFriend(friend);

            Assert.False(hasFriends);
        }

        [Fact]
        [Description("Should pass if the user has friends")]
        public void UserIsFriend()
        {
            var friend = new User();
            var userWithFriends = new User();
            userWithFriends.AddFriend(friend);

            var hasFriends = userWithFriends.IsFriend(friend);

            Assert.False(hasFriends);
        }
    }
}
