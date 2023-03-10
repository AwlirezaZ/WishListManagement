using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishListManagement.Mappers;
using WishListManagement.Models.Domain.WishListItem;
using WishListManagement.Models.ViewModels.WishListItem;
using WishListManagement.Repositories;

namespace WishListManagement.Services
{
    public class WishListItemService
    {
        private readonly WishListItemRepository _repository;
        public WishListItemService()
        {
            _repository = new WishListItemRepository();
        }

        public bool CreateWishListItem(CreateWishListItemViewModel createViewModel)
        {
            var wishListItem = new WishListItem(createViewModel.WishListItemDescription, createViewModel.RoughPrice,
                createViewModel.Priority, createViewModel.UserId);
            return _repository.Create(wishListItem);
        }

        public WishListItemViewModel GetWishListItemById(long id)
        {
            var wishListItem = _repository.GetById(id);
            return WishListItemMapper.Map(wishListItem);
        }

        public bool DeleteWishListItem(long id)
        {
            return _repository.Delete(id);
        }

        public bool ModifyWishListItem(ModifyWishListItemViewModel modifyViewModel)
        {
            var wishListItem = _repository.GetById(modifyViewModel.Id);
            wishListItem.Update(modifyViewModel.WishListItemDescription, modifyViewModel.RoughPrice,
                modifyViewModel.Priority);
            return _repository.Update(wishListItem);
        }

        public List<WishListItemViewModel> GetWishListItemsByUserId(long userId)
        {
            var wishListItems = _repository.GetWishListItemsByUserId(userId);
            return WishListItemMapper.Map(wishListItems);
        }
    }
}