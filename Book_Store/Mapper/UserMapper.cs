using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Mapper
{
    public class UserMapper
    {
        public static Book_Store.Models.User Map(Data.Entities.User user)
        {
            return new Book_Store.Models.User()
            {
                User_Id = user.User_Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNumber = user.MobileNumber,
                Email = user.Email,
                Password = user.Password,
                Role_Id = user.Role.Role_Name
            };
        }
        public static Data.Entities.User Map(Book_Store.Models.User user)
        {
            return new Data.Entities.User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNumber = user.MobileNumber,
                Email = user.Email,
                Password = Book_Store.EncryptionDecryption.EncryptionDecryption.EncryptString(user.Password),
                Role_Id = 1,
            };
        }

        public static Data.Entities.User Map(Book_Store.Models.Register user)
        {
            return new Data.Entities.User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNumber = user.MobileNumber,
                Email = user.Email,
                Password = Book_Store.EncryptionDecryption.EncryptionDecryption.EncryptString(user.Password),
                Role_Id = 1,
            };
        }
        public static Data.Entities.User MapData(Book_Store.Models.Login login)
        {
            return new Data.Entities.User()
            {
                Email = login.Email,
                Password =Book_Store.EncryptionDecryption.EncryptionDecryption.EncryptString(login.Password),
            };
        }
    }
}