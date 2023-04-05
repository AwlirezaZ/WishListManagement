using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WishListManagement.Models.ViewModels.WishListItem;
using WishListManagement.Services;

namespace WishListManagement.Controllers
{
    [Authorize]
    public class WishListItemController : Controller
    {
        private readonly WishListItemService _service;

        public WishListItemController()
        {
            _service = new WishListItemService();
        }

        public ActionResult Create(long wishListId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateWishListItemViewModel viewModel)
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
            var wishListId = _service.DeleteWishListItem(id);
            return RedirectToAction("GetWishListItemsList", new { wishListId});
        }

        public ActionResult GetWishListItemsList(long wishListId)
        {
            var wishListItems = _service.GetWishListItemsByUserId(wishListId);
            return View(wishListItems);
        }
    }
}