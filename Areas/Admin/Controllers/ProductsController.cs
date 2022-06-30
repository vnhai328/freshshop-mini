using PrjFresh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrjFresh.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        FreshDBContex db = new FreshDBContex();
        public ActionResult List()
        {          
            var model = (from a in db.tblProducts
                         join b in db.tblProductPrices
                         on a.ID equals b.ProductID
                         join c in db.tblProductImages
                         on a.ID equals c.ProductID
                         select new
                         {
                             objProduct = a,
                             objProductPrice = b,
                             objProductImage = c
                         }).ToList();
            List<tblProductPrImg> IsPr = new List<tblProductPrImg>();
            foreach (var item in model)
            {
                tblProductPrImg pr = new tblProductPrImg();
                pr.ID = item.objProduct.ID;
                pr.Name = item.objProduct.Name;
                pr.ProductCode = item.objProduct.ProductCode;
                pr.Description = item.objProduct.Description;
                pr.ProductType = item.objProduct.ProductType;
                pr.Manufacture = item.objProduct.Manufacture;
                pr.MadeIn = item.objProduct.MadeIn;
                pr.CreateDate = item.objProduct.CreateDate;
                pr.Status = item.objProduct.Status;
                string review = item.objProduct.Review;
                if (!String.IsNullOrEmpty(review))
                {
                    review = (review.Length <= 80) ? review : review.Substring(0, 80) + "...";
                }      
                pr.Review = review;
                pr.Price_ID = item.objProductPrice.ID;
                pr.ProductID = item.objProductPrice.ProductID;
                pr.Price = item.objProductPrice.Price;
                pr.PriceSale = item.objProductPrice.PriceSale;
                pr.DateIssued = item.objProductPrice.DateIssued;
                pr.IsDate = item.objProductPrice.IsDate;
                pr.Image_ID = item.objProductImage.ID;
                pr.Image_ProductID = item.objProductImage.ProductID;
                pr.ImageUrl = item.objProductImage.ImageUrl;
                pr.Image_Status = item.objProductImage.Status;
                pr.OderNumber = item.objProductImage.OderNumber;
                IsPr.Add(pr);
            }
            return View(IsPr);
        }
        public ActionResult Create()
        {
            var model = (from a in db.tblProducts
                         join b in db.tblProductPrices
                         on a.ID equals b.ProductID
                         join c in db.tblProductImages
                         on a.ID equals c.ProductID
                         select new
                         {
                             objProduct = a,
                             objProductPrice = b,
                             objProductImage = c
                         }).ToList();
            List<tblProductPrImg> IsPr = new List<tblProductPrImg>();
            foreach (var item in model)
            {
                tblProductPrImg pr = new tblProductPrImg();
                pr.ID = item.objProduct.ID;
                pr.Name = item.objProduct.Name;
                pr.ProductCode = item.objProduct.ProductCode;
                pr.Description = item.objProduct.Description;
                pr.ProductType = item.objProduct.ProductType;
                pr.Manufacture = item.objProduct.Manufacture;
                pr.MadeIn = item.objProduct.MadeIn;
                pr.CreateDate = item.objProduct.CreateDate;
                pr.Status = item.objProduct.Status;
                string review = item.objProduct.Review;
                if (!String.IsNullOrEmpty(review))
                {
                    review = (review.Length <= 80) ? review : review.Substring(0, 80) + "...";
                }
                pr.Review = review;
                pr.Price_ID = item.objProductPrice.ID;
                pr.ProductID = item.objProductPrice.ProductID;
                pr.Price = item.objProductPrice.Price;
                pr.PriceSale = item.objProductPrice.PriceSale;
                pr.DateIssued = item.objProductPrice.DateIssued;
                pr.IsDate = item.objProductPrice.IsDate;
                pr.Image_ID = item.objProductImage.ID;
                pr.Image_ProductID = item.objProductImage.ProductID;
                pr.ImageUrl = item.objProductImage.ImageUrl;
                pr.Image_Status = item.objProductImage.Status;
                pr.OderNumber = item.objProductImage.OderNumber;
                IsPr.Add(pr);
            }
            return View(IsPr);
        }
    }
}