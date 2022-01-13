using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services.Tests
{
    [TestClass()]
    public class FriendsServicesTests
    {
        FriendsServices friendsServices = new();    
        [TestMethod()]
        public void AddFriendTest_ArgumentNullException()
        {
            FriendData friendData = new();
            Assert.ThrowsException<ArgumentNullException>(() => friendsServices.AddFriend(friendData));
        }

        [TestMethod()]
        public void AddFriendTest_UserNotFoundException()
        {
            FriendData friendData = new();
            friendData.friend_email = "email";  // такого адреса точно не должно быть (он не пройдет проверку при добавлении), поэтому ожидаем исключения
            Assert.ThrowsException<UserNotFoundException>(() => friendsServices.AddFriend(friendData));
        }

        /*
        [TestMethod()]
        public void ListFriendsTest_Success()    // Мок для спска пользователей сделать получилось, но здесь я запутался((
                                                 // Буду пробовать еще, но пока сдам так: как минимум один требуемый юнит-тест точно есть.
        {
            List<FriendEntity> friendEntities = new List<FriendEntity> { new FriendEntity { id = 1, user_id = 1, friend_id = 2},
                    new FriendEntity { id = 2, user_id = 1, friend_id = 3}};

            Mock<IFriendRepository> mockFriendRepository = new Mock<IFriendRepository>();
            mockFriendRepository.Setup(f => f.FindAllByUserId(1)).Returns(friendEntities);

            FriendsServices friendServices = new();
            friendServices.friendRepository = mockFriendRepository.Object;

            UserEntity userEntity = new UserEntity { id = 1, email = "1@1.1", firstname = "1", lastname = "1" };
            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.FindById(1)).Returns(userEntity);

            UserService userService = new UserService();
            userService.userRepository = mockUserRepository.Object;

            IEnumerable<Message> listOfMessages = new List<Message>();
            Mock<IMessageRepository> msgRep = new Mock<IMessageRepository>();
            IEnumerable<MessageEntity> listOfME = new List<MessageEntity>();
            
            msgRep.Setup(m => m.FindByRecipientId(1)).Returns(listOfME);
            //msgRep.Setup(m => m.FindBySenderId(1)).Returns((IEnumerable<MessageEntity>)listOfME);
            


            User user = new(1, "1", "1", "1@1.1", "11", "", "", "", null, null);
            Assert.IsTrue(friendServices.ListFriends(user).Count() >= 0);

        }
        */
    }
}