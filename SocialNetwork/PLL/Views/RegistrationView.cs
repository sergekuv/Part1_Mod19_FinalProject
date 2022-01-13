using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class RegistrationView
    {
        UserService userService;
        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

            Console.Write("Для создания нового профиля введите \nВаше имя:");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("Ваша фамилия:");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("Пароль:");
            userRegistrationData.Password = Console.ReadLine();

            Console.Write("Почтовый адрес:");
            userRegistrationData.Email = Console.ReadLine();

            try
            {
                this.userService.Register(userRegistrationData);

                SuccessMessage.Show("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.\n");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение.\n");
            }
            catch (DuplicateUserException)
            {
                AlertMessage.Show("Пользователь с таким email уже существует.\n");
            }
            catch (Exception ex)
            {
                AlertMessage.Show($"Произошла ошибка при регистрации: {ex.Message}\n");
            }
        }
    }
}