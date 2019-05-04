using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository.BaseRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Repository
{
    public interface IUserInforRepository : IBaseRepository<UserInfor>
    {
        void AddUserInfor(UserInfor userInfor);
        void UpdateUserInfor(UserInfor userInfor);
        void DeleteUserInfor(UserInfor userInfor);
        Task<UserInfor> FindUserInforById(string id);
        Task<UserInfor> FindUserInforByUserId(string id);
    }
}
