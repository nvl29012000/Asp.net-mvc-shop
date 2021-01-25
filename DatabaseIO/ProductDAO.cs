using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DatabaseIO
{
    public class ProductDAO
    {
        private QLBH QLBHDBContext = null;
        public ProductDAO()
        {
            QLBHDBContext = new QLBH();
        }
        #region Product
        public IEnumerable<Product> ListProduct()
        {
            return QLBHDBContext.Products.ToList();
        }
        public IEnumerable<Product> listsubproduct(int ID)
        {
            if (ID == 0)
                return QLBHDBContext.Products.ToList();
            else
                return QLBHDBContext.Products.Where(x => x.CategoryID == ID).ToList();
        }
        public bool CreateProduct(string session, Product entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = session;
                QLBHDBContext.Products.Add(entity);
                QLBHDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Product FindProduct(int ID)
        {
            return QLBHDBContext.Products.Where(x => x.ID == ID).SingleOrDefault();
        }
        public bool EditProduct(string session, Product entity)
        {
            Product edit = QLBHDBContext.Products.Where(x => x.ID == entity.ID).SingleOrDefault();
            try
            {
                edit.Name = entity.Name;
                edit.ProductCode = entity.ProductCode;
                edit.Title = entity.Title;
                edit.Description = entity.Description;
                edit.Image = entity.Image;
                edit.DetailImage = entity.DetailImage;
                edit.Price = entity.Price;
                edit.SalePrice = entity.SalePrice;
                edit.Quantity = entity.Quantity;
                edit.CategoryID = entity.CategoryID;
                edit.ProductDetail = entity.ProductDetail;
                edit.SaleDate = entity.SaleDate;
                edit.ModifiedDate = DateTime.Now;
                edit.ModifiedBy = session;
                edit.MetaKeyword = entity.MetaKeyword;
                edit.MetaDescription = entity.MetaDescription;
                edit.Status = entity.Status;
                QLBHDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteProduct(int ID)
        {
            try
            {
                Product delete = QLBHDBContext.Products.Where(x => x.ID == ID).SingleOrDefault();
                QLBHDBContext.Products.Remove(delete);
                QLBHDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region Product-Category
        public IEnumerable<ProductCategory> listall()
        {
            return QLBHDBContext.ProductCategories.ToList();
        }
        public IEnumerable<ProductCategory> listsubcate(int ID)
        {
            if(ID == 0)
                return QLBHDBContext.ProductCategories.Where(x => x.ShowOnHome == true).ToList();
            else
                return QLBHDBContext.ProductCategories.Where(x => x.ParentID == ID).ToList();
        }
        public IEnumerable<ProductCategory> listshowonhome()
        {
            return QLBHDBContext.ProductCategories.Where(x => x.ShowOnHome == true).ToList();
        }
        public ProductCategory FindCtgrByID(int ID)
        {
            return QLBHDBContext.ProductCategories.Where(x => x.ID == ID).SingleOrDefault();
        }
        public bool Create(string session, ProductCategory entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = session;
                QLBHDBContext.ProductCategories.Add(entity);
                QLBHDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(string session, ProductCategory entity)
        {
            ProductCategory edit = QLBHDBContext.ProductCategories.Where(x => x.ID == entity.ID).SingleOrDefault();
            try
            {
                edit.Name = entity.Name;
                edit.Title = entity.Title;
                edit.ParentID = entity.ParentID;
                edit.DisplayOrder = entity.DisplayOrder;
                edit.SeoTitle = entity.SeoTitle;
                edit.ModifiedDate = DateTime.Now;
                edit.ModifiedBy = session;
                edit.ShowOnHome = entity.ShowOnHome;
                edit.Status = entity.Status;
                QLBHDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int ID)
        {
            try
            {
                ProductCategory delete = QLBHDBContext.ProductCategories.Where(x => x.ID == ID).SingleOrDefault();
                QLBHDBContext.ProductCategories.Remove(delete);
                QLBHDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string Category(long? CategoryID)
        {
            var res = QLBHDBContext.ProductCategories.Where(x => x.ID == CategoryID).SingleOrDefault();
            if (res == null)
                return "";
            return res.Name;
        }
        #endregion
    }
}
