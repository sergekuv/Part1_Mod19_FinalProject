using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class AddingFriendsView
    {
        UserService userService;
        FriendsServices friendsService;

        public AddingFriendsView(FriendsServices friensdServices, UserService userService)
        {
            this.friendsService = friensdServices;
            this.userService = userService;
        }

        public void Show(User user)
        {
            FriendData friendData = new();

            Console.Write("Введите email пользователя, которого нужно добавить в друзья: ");
            friendData.friend_email = Console.ReadLine();
            friendData.user_id = user.Id;

            try
            {
                friendsService.AddFriend(friendData);
                SuccessMessage.Show("Пользователь добавлен в друзья");
                user = userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при отправке сообщения!");
            }

        }
    }
}

