using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository;
using AgriculturalProductsStore.Repository.BaseRepository;
using AgriculturalProductsStore.Repository.UnitOfWork;
using AgriculturalProductsStore.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Services
{
    public class UserInforService : BaseService<UserInfor>, IUserInforService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInforRepository _repository;

        public UserInforService(IUnitOfWork unitOfWork, IUserInforRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _repository = reponsitory;
        }

        public void AddUserInfor(UserInfor userInfor)
        {
            Add(userInfor);
            _unitOfWork.Commit();
        }

        public void DeleteUserInfor(UserInfor userInfor)
        {
            Delete(userInfor);
            _unitOfWork.Commit();
        }

        public async Task<UserInfor> FindUserInforById(string id)
        {
            return await _repository.FindUserInforById(id);
        }

        public async Task<UserInfor> FindUserInforByUserId(string id)
        {
            return await _repository.FindUserInforByUserId(id);
        }

        public void UpdateUserInfor(UserInfor userInfor)
        {
            Update(userInfor);
            _unitOfWork.Commit();
        }
    }
}
