using System;
using System.Linq;
using TestApp.DataAccess;
using TestApp.DataAccess.Entities;
using TestApp.DataAccess.Enums;
using TestApp.Models.Phones;
using TestApp.Operations.Abstraction;

namespace TestApp.Operations.Implementation
{
    public class PhonesOperations : IPhonesOperations
    {
        private readonly IUnitOfWork _unitOfWork;

        public PhonesOperations(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository<PhoneEntity>().DeleteById(id);
            _unitOfWork.SaveChanges();
        }

        public void Edit(PhoneEditModel model)
        {
            var phone = _unitOfWork.Repository<PhoneEntity>().GetById(model.Id);
            if (phone != null)
            {
                phone.Description = model.Description;
                phone.Company = model.Company;
                phone.Category = model.Category;
                phone.Model = model.Model;
                phone.LastChange = DateTimeOffset.Now;
                phone.Price = model.Price;
                _unitOfWork.SaveChanges();
            }
        }

        public PhoneGetModel Get(int id)
        {
            var phone = _unitOfWork.Repository<PhoneEntity>().GetById(id);
            return new PhoneGetModel
            {
                Category = phone.Category,
                Company = phone.Company,
                Description = phone.Description,
                Id = phone.Id,
                LastChange = phone.LastChange,
                Model = phone.Model,
                Price = phone.Price
            };
        }

        public PhonesListModel GetAll(int? sort)
        {
            var phones = new PhonesListModel
            {
                Phones = _unitOfWork.Repository<PhoneEntity>().Set.Select(phone => new PhoneGetModel
                {
                    Category = phone.Category,
                    Company = phone.Company,
                    Description = phone.Description,
                    Id = phone.Id,
                    LastChange = phone.LastChange,
                    Model = phone.Model,
                    Price = phone.Price
                }).ToList()
            };
            if (sort == null || sort == (int)SortEnum.Date)
            {
                phones.Phones = phones.Phones.OrderByDescending(x => x.LastChange).ToList();
            }
            else if (sort == (int)SortEnum.Category)
            {
                phones.Phones = phones.Phones.OrderByDescending(x => x.Category).ToList();
            }
            else if (sort == (int)SortEnum.Price)
            {
                phones.Phones = phones.Phones.OrderByDescending(x => x.Price).ToList();
            }
            return phones;
        }

        public void Post(PhonePostModel model)
        {
            _unitOfWork.Repository<PhoneEntity>().Insert(new PhoneEntity
            {
                Description = model.Description,
                Company = model.Company,
                Category = model.Category,
                Model = model.Model,
                LastChange = DateTimeOffset.Now,
                Price = model.Price
            });
            _unitOfWork.SaveChanges();
        }
    }
}
