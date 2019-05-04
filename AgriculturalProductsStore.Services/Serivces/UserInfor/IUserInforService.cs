using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Services
{
    public interface IUserInforService : IBaseService<UserInfor>
    {
        void AddUserInfor(UserInfor userInfor);
        void UpdateUserInfor(UserInfor userInfor);
        void DeleteUserInfor(UserInfor userInfor);
        Task<UserInfor> FindUserInforById(string id);
        Task<UserInfor> FindUserInforByUserId(string id);
    }
}
