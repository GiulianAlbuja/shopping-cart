using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingCartData;
using ShoppingCartEntity;

namespace ShoppingCartBusiness
{
    public class BusinessUsers
    {
        private UsersData objectData = new UsersData();

        public List<User> ListUsers()
        {
            return objectData.ListUsers();
        }

        public int RegisterUser(User objectUser, out String Message)
        {
            Message = String.Empty;

            if (String.IsNullOrEmpty(objectUser.UserNames) || String.IsNullOrWhiteSpace(objectUser.UserNames))
            {
                Message = "Username cannot be empty";
            }
            else if (String.IsNullOrEmpty(objectUser.UserLastNames) || String.IsNullOrWhiteSpace(objectUser.UserLastNames))
            {
                Message = "The user's last name cannot be empty";
            }
            else if (String.IsNullOrEmpty(objectUser.Email) || String.IsNullOrWhiteSpace(objectUser.Email))
            {
                Message = "The user's email cannot be empty";
            }
                
            if (String.IsNullOrEmpty(Message))
            {
                String password = "test123";
                objectUser.UserPassword = BusinessResources.ConvertSha256(password);

                return objectData.RegisterUser(objectUser, out Message);
            }
            else
            {
                return 0;
            }
        }


        public bool EditUser(User objectUser, out String Message)
        {

            Message = String.Empty;

            if (String.IsNullOrEmpty(objectUser.UserNames) || String.IsNullOrWhiteSpace(objectUser.UserNames))
            {
                Message = "Username cannot be empty";
            }
            else if (String.IsNullOrEmpty(objectUser.UserLastNames) || String.IsNullOrWhiteSpace(objectUser.UserLastNames))
            {
                Message = "The user's last name cannot be empty";
            }
            else if (String.IsNullOrEmpty(objectUser.Email) || String.IsNullOrWhiteSpace(objectUser.Email))
            {
                Message = "The user's email cannot be empty";
            }

            if (String.IsNullOrEmpty(Message))
            {
                return objectData.EditUser(objectUser, out Message);
            }
            else
            {
                return false;
            }
        }

        public bool DeleteUser(int id, out String Message)
        {
            return objectData.DeleteUser(id, out Message);
        }
    }
}
