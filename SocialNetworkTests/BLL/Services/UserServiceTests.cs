using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
    public class UserServiceTests
    {
        [TestMethod()]
        public void FindAllTest()
        {
            List<UserEntity> userEntities = new List<UserEntity>{new UserEntity { id = 1, email = "1@1.1", firstname = "1", lastname = "1" },
                new UserEntity { id = 2, email = "2@2.2", firstname = "2", lastname = "2" } };

            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.FindAll()).Returns(userEntities);

            UserService userService = new UserService();
            userService.userRepository = mockUserRepository.Object;

            Assert.IsTrue(userService.FindAll().Count() == 2);
        }

        [TestMethod()]
        public void FindByIdTest_Success()
        {
            UserEntity userEntity = new UserEntity { id = 1, email = "1@1.1", firstname = "1", lastname = "1" };
            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(u => u.FindById(1)).Returns(userEntity);

            UserService userService = new UserService();
            userService.userRepository = mockUserRepository.Object;

            Assert.IsTrue(userService.FindById(1).Email == "1@1.1");
        }
    }
}