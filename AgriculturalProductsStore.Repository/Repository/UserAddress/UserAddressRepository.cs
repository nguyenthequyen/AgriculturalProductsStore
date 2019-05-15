using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Repository
{
    public class UserAddressRepository : BaseRepository<UserAddress>, IUserAddressRepository
    {
        private readonly ApplicationIdentityDbContext _dbContext;
        public UserAddressRepository(ApplicationIdentityDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUserAddress(UserAddress userAddress)
        {
            Insert(userAddress);
        }

        public void DeleteUserAddress(UserAddress userAddress)
        {
            Delete(userAddress);
        }

        public async Task<UserAddress> FindUserAddressById(string id)
        {
            return _dbContext.UserAddresses.FirstOrDefault(x => x.Id == id);
        }

        public List<UserAddress> FindUserAddressByUserId(string id)
        {
            return _dbContext.UserAddresses.Where(x => x.IdentityUserId == id).ToList();
        }

        public void UpdateNotDefaultAddress(bool isDefault, string userId)
        {
            var userAddress = _dbContext.UserAddresses.Where(x => x.IdentityUserId == userId).ToList();
            if (userAddress.Count != 0)
            {
                _dbContext.UserAddresses.Where(x => x.IdentityUserId == userId && x.IsDefault == true).ToList().ForEach(x => x.IsDefault = isDefault);
            }
        }

        public void UpdateUserAddress(UserAddress userAddress)
        {
            Update(userAddress);
        }
    }
}
