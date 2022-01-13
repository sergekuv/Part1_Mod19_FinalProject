using System;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.BLL.Models;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendsView
    {
        public void Show(User user)
        {
            Console.WriteLine("Друзья");

            FriendsServices friendsServices = new();
            try
            {
                var friends = friendsServices.ListFriends(user);
                if (friends.Count() == 0)
                {
                    SuccessMessage.Show("Список друзей пуст\n");
                    return;
                }
                foreach (User friend in friends)
                {
                    Console.WriteLine($"{friend.Email} {friend.FirstName} {friend.LastName}");
                }
            }
            catch (Exception ex)
            {
                AlertMessage.Show("Ошибка при обращении к списку друзей: " + ex.Message);
            }

            Console.WriteLine();
        }
    }
}
