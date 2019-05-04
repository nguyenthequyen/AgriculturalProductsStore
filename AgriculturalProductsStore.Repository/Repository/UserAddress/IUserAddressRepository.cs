using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Repository
{
    public interface IUserAddressRepository : IBaseRepository<UserAddress>
    {
        void AddUserAddress(UserAddress userAddress);
        void UpdateUserAddress(UserAddress userAddress);
        void DeleteUserAddress(UserAddress userAddress);
        void UpdateNotDefaultAddress(bool isDefault, string userId);
        Task<UserAddress> FindUserAddressById(string id);
        List<UserAddress> FindUserAddressByUserId(string id);
    }
}
