using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    class AllUsersView      // откроем пока такой функционал, чтобы проще было тестировать
    {
        public void Show()
        {
            UserService userService = new();
            Console.WriteLine("Список всех пользователей сети");

            try
            {
                var users = userService.FindAll();
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id}: {user.Email} ({user.Password}) {user.FirstName} {user.LastName}");
                }
            }
            catch (Exception ex)
            {
                AlertMessage.Show("Ошибка при получении списка пользователей: {0}" + ex.Message);
            }

            Console.WriteLine();
        }
    }
}
