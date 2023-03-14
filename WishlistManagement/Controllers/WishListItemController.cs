using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WishListManagement.Models.ViewModels.WishListItem;
using WishListManagement.Services;

namespace WishListManagement.Controllers
{
    public class WishListItemController : Controller
    {
        private readonly WishListItemService _service;

        public WishListItemController()
        {
            _service = new WishListItemService();
        }

        public ActionResult CreateWishList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWishList(CreateWishListItemViewModel viewModel)
        {
            var id = _service.CreateWishListItem(viewModel);
            return RedirectToAction("GetWishListInfo", new { id });
        }

        public ActionResult GetWishListInfo(long id)
        {
            var viewModel = _service.GetWishListItemById(id);
            return View(viewModel);
        }
        public ActionResult EditWishListItem(long id)
        {
            var wishListItem = _service.GetWishListItemById(id);
            return View(wishListItem);
        }
        [HttpPost]
        public ActionResult EditWishListItem(ModifyWishListItemViewModel viewModel)
        {
            _service.ModifyWishListItem(viewModel);
            return RedirectToAction("GetWishListInfo", new { id = viewModel.Id });
        }
        public ActionResult DeleteWishListItem(long id)
        {
            var userId = _service.DeleteWishListItem(id);
            return RedirectToAction("GetWishListItemsList", new { userId });
        }

        public ActionResult GetWishListItemsList(long userId)
        {
            var wishListItems = _service.GetWishListItemsByUserId(userId);
            return View(wishListItems);
        }
    }
}