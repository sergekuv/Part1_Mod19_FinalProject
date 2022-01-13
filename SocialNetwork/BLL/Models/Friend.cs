using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int id { get; }
        public int user_id { get; }
        public int friend_id { get; }

        public Friend (int id, int user_id, int friend_id)
        {
            this.id = id;
            this.user_id = user_id;
            this.friend_id = friend_id;
        }
    }
}
