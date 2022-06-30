using PrjFresh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrjFresh.Controllers
{
    public class HomeController : Controller
    {
        FreshDBContex db = new FreshDBContex();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Header()
        {
            return PartialView();
        }
        public ActionResult Menu()
        {
            var model = db.tblMenus.Where(x => x.Status == "1").OrderBy(x=>x.ID).ToList();
            return PartialView(model);
        }
        public ActionResult SliderMenu()
        {
            var model = db.tblSliderMenus.Where(x => x.Status == 1).OrderBy(x => x.ID).ToList();
            return PartialView(model);
        }
        public ActionResult Product()
        {
            var model = (from a in db.tblProducts
                         join b in db.tblProductImages
                         on a.ID equals b.ProductID
                         join c in db.tblProductPrices
                         on a.ID equals c.ProductID
                         select new
                         {
                             ID = a.ID,
                             Name = a.Name,
                             ImageUrl = b.ImageUrl,
                             Price = c.Price,
                             Manufacture = a.Manufacture
                         }).ToList();
            List<ProductView> _IsProduct = new List<ProductView>();
            if (model != null && model.Count > 0)
            {
                foreach(var item in model)
                {
                    ProductView _productView = new ProductView();
                    _productView._Product = new tblProduct();
                    _productView._ProductImage = new tblProductImage();
                    _productView._ProductPrice = new tblProductPrice();
                    _productView._Product.ID = item.ID;
                    _productView._Product.Manufacture = item.Manufacture;
                    _productView._Product.Name = item.Name;
                    _productView._ProductImage.ImageUrl = item.ImageUrl;
                    _productView._ProductPrice.Price = item.Price;
                    _IsProduct.Add(_productView);
                //Lấy Producr ra View đanng làm
                }
            }
            return PartialView(_IsProduct);
        }
        public ActionResult AddCart(int ID, string ImageUrl, string Price, string Name)
        {
            decimal Total = 0;
            var lstItem = new List<CartItem>();
            Session["TotalProduct"] = 0;
            //kiem tra gio hang co null k?
            if (Session["Cart"] == null)
            {
                //them moi
                var item = new CartItem();
                item.ID = ID;
                item.ImageUrl = ImageUrl;
                item.Price = Convert.ToDecimal(Price);
                item.Name = Name;
                lstItem.Add(item);
                Session["Cart"] = lstItem;
                item.Quantity = 1;
                Session["TotalMoney"] = item.Price * item.Quantity;
                Session["TotalProduct"] = 1;
                Total = 1;
            }
            else
            {
                //kiem tra sp
                //so luong
                //them moi
                bool bCheck = false;
                lstItem = (List<CartItem>)Session["Cart"];
                foreach (var item in lstItem)
                {
                    if (item.ID == ID)
                    {
                        item.Quantity = item.Quantity + 1;
                        bCheck = true;
                        break;
                    }
                }
                if (bCheck == false)
                {
                    var item = new CartItem();
                    item.ID = ID;
                    item.ImageUrl = ImageUrl;
                    item.Price = Convert.ToDecimal(Price);
                    item.Name = Name;
                    lstItem.Add(item);
                    Session["Cart"] = lstItem;
                    item.Quantity = 1;
                }
                Session["Cart"] = lstItem;

                foreach (var item in lstItem)
                {
                    Total = Total + item.Quantity * item.Price;
                }
                Session["TotalProduct"] = lstItem.Count;
                Session["TotalMoney"] = Total;
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult RemoveCart(int ID)
        {
            decimal Total = 0;
            var lstItem = (List<CartItem>)Session["Cart"];
            foreach (var item in lstItem)
            {
                if (item.ID == ID)
                {
                    lstItem.Remove(item);
                    item.Quantity = item.Quantity - 1;
                    break;
                }
            }
            Session["Cart"] = lstItem;
            foreach (var item in lstItem)
            {
                Total = Total + item.Quantity * item.Price;
            }
            Session["TotalProduct"] = lstItem.Count;
            Session["TotalMoney"] = Total;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
    }
}
