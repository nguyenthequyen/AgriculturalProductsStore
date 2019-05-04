using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Services
{
    public interface IUserAddressService : IBaseService<UserAddress>
    {
        void AddUserAddress(UserAddress userAddress);
        void UpdateUserAddress(UserAddress userAddress);
        void DeleteUserAddress(UserAddress userAddress);
        void UpdateNotDefaultAddress(bool isDefault, string userId);
        Task<UserAddress> FindUserAddressById(string id);
        List<UserAddress> FindUserAddressByUserId(string id);
    }
}
