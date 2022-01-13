using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.BLL.Services
{
    public class FriendsServices
    {
        public IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendsServices()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public void AddFriend(FriendData friendData)
        {
            if (String.IsNullOrEmpty(friendData.friend_email))        //На корректность email проверять нет смысла в данном случае:
                throw new ArgumentNullException();  // некорректрый адрес просто не будет найден, т.к. мы проверяем корректность при добавлении пользователей
                                                    // не вижу причин, мешающие добавить в друзья самого себя. Если они есть, нужно реализовать проверку.. 

            UserEntity findUserEntity = this.userRepository.FindByEmail(friendData.friend_email);
            if (findUserEntity is null) throw new UserNotFoundException();

            FriendEntity friendEntity = new()
            {
                user_id = friendData.user_id,
                friend_id = findUserEntity.id
            };

            if (friendRepository.FindAllByUserId(friendData.user_id).
                Where(item => item.friend_id == friendEntity.friend_id).Count() == 0) // такого друга еще нет, пробуем добавить
                if (this.friendRepository.Create(friendEntity) == 0)
                    throw new Exception();
            // Если друг уже есть, никаких действий не предпринимаем - в итоге пользователь просто получит сообщение, что друг добавлен
        }

        public IEnumerable<User> ListFriends(User user)   
        {
            UserService userService = new();

            if (user is null)               
                throw new ArgumentNullException();

            List<User> friends = new ();

            foreach (FriendEntity friend in friendRepository.FindAllByUserId(user.Id))
            {
                friends.Add(userService.ConstructUserModel(this.userRepository.FindById(friend.friend_id))); 
            }
            return friends;
        }
    }
}
