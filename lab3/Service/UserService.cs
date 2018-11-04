using System.Collections.Generic;
using System.Linq;
using web_api.model;

namespace web_api.Service
{
    public class UserService
    {
        private static readonly Dictionary<int, User> UserDictionary = new Dictionary<int, User>();

        private static int _idCounter;

        public User find(int id)
        {
            return UserDictionary.ContainsKey(id) ? UserDictionary[id] : null;
        }

        public List<User> findAll()
        {
            return UserDictionary.Values.ToList();
        }

        public User save(User user)
        {
            var id = _idCounter++;
            user.Id = id;
            UserDictionary.Add(id, user);
            return user;
        }

        public User unpdate(int id, User user)
        {
            var persistentUser = UserDictionary.ContainsKey(id) ? UserDictionary[id] : null;
            if (persistentUser == null)
            {
                return null;
            }

            persistentUser.Name = user.Name;
            persistentUser.LastName = user.LastName;
            return persistentUser;
        }


        public User delete(int id)
        {
            var user = UserDictionary.ContainsKey(id) ? UserDictionary[id] : null;

            if (user == null)
            {
                return null;
            }

            UserDictionary.Remove(user.Id);
            return user;
        }
    }
}