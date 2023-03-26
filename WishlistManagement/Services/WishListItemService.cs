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

        public long CreateWishListItem(CreateWishListItemViewModel createViewModel)
        {
            var wishListItem = new WishListItem(createViewModel.WishListItemDescription, createViewModel.RoughPrice,
                createViewModel.Priority, createViewModel.WishListId);
            return _repository.Create(wishListItem);
        }

        public WishListItemViewModel GetWishListItemById(long id)
        {
            var wishListItem = _repository.GetById(id);
            return WishListItemMapper.Map(wishListItem);
        }

        public long DeleteWishListItem(long id)
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

        public List<WishListItemViewModel> GetWishListItemsByUserId(long wishListId)
        {
            var wishListItems = _repository.GetWishListItemsByUserId(wishListId);
            return WishListItemMapper.Map(wishListItems);
        }
    }
}