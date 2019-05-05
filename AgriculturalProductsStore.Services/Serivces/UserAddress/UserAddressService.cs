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
    public class UserAddressService : BaseService<UserAddress>, IUserAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserAddressRepository _repository;
        public UserAddressService(IUnitOfWork unitOfWork, IUserAddressRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _repository = reponsitory;
        }

        public void AddUserAddress(UserAddress userAddress)
        {
            Add(userAddress);
            _unitOfWork.Commit();
        }

        public void DeleteUserAddress(UserAddress userAddress)
        {
            Delete(userAddress);
            _unitOfWork.Commit();
        }

        public async Task<UserAddress> FindUserAddressById(string id)
        {
            return await _repository.FindUserAddressById(id);
        }

        public List<UserAddress> FindUserAddressByUserId(string id)
        {
            return _repository.FindUserAddressByUserId(id);
        }

        public void UpdateNotDefaultAddress(bool isDefault, string userId)
        {
            _repository.UpdateNotDefaultAddress(isDefault, userId);
            _unitOfWork.Commit();
        }

        public void UpdateUserAddress(UserAddress userAddress)
        {
            Update(userAddress);
            _unitOfWork.Commit();
        }
    }
}
