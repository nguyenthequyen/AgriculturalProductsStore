using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Repository
{
    public class UserInforRepository : BaseRepository<UserInfor>, IUserInforRepository
    {
        private readonly ApplicationIdentityDbContext _dbContext;
        public UserInforRepository(ApplicationIdentityDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUserInfor(UserInfor userInfor)
        {
            Add(userInfor);
        }

        public void DeleteUserInfor(UserInfor userInfor)
        {
            Delete(userInfor);
        }

        public async Task<UserInfor> FindUserInforById(string id)
        {
            return  _dbContext.UserInfors.FirstOrDefault(x => x.Id == id);
        }

        public async Task<UserInfor> FindUserInforByUserId(string id)
        {
            return _dbContext.UserInfors.FirstOrDefault(x => x.IdentityUserId == id);
        }

        public void UpdateUserInfor(UserInfor userInfor)
        {
            Update(userInfor);
        }
    }
}
