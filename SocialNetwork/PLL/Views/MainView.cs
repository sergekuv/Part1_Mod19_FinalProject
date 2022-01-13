using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("Войти в профиль (введите 1)");
            Console.WriteLine("Зарегистрироваться (введите 2)");
            Console.WriteLine("Завершить работу (введите что-то другое)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.authenticationView.Show();
                        break;
                    }

                case "2":
                    {
                        Program.registrationView.Show();
                        break;
                    }
                default:
                    {
                        Environment.Exit(0);
                        break;
                    }

            }
        }
    }
}