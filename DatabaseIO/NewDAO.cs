using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DatabaseIO
{
    public class NewDAO
    {
        private QLBH QLBHDBContext = null;
        public NewDAO()
        {
            QLBHDBContext = new QLBH();
        }
        #region new
        public IEnumerable<New> listnew()
        {
            return QLBHDBContext.News.ToList();
        }
        public bool CreateNew(string session, New entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = session;
                QLBHDBContext.News.Add(entity);
                QLBHDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public New FindNew(int ID)
        {
            return QLBHDBContext.News.Where(x => x.ID == ID).SingleOrDefault();
        }
        public bool EditNew(string session, New entity)
        {
            New edit = QLBHDBContext.News.Where(x => x.ID == entity.ID).SingleOrDefault();
            try
            {
                edit.Name = entity.Name;
                edit.Title = entity.Title;
                edit.Description = entity.Description;
                edit.Image = entity.Image;
                edit.DetailImage = entity.DetailImage;
                edit.CategoryID = entity.CategoryID;
                edit.NewDetail = entity.NewDetail;
                edit.ModifiedDate = DateTime.Now;
                edit.ModifiedBy = session;
                edit.MetaKeyword = entity.MetaKeyword;
                edit.MetaDescription = entity.MetaDescription;
                edit.Tag = entity.Tag;
                edit.Status = entity.Status;
                QLBHDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteNew(int ID)
        {
            try
            {
                New delete = QLBHDBContext.News.Where(x => x.ID == ID).SingleOrDefault();
                QLBHDBContext.News.Remove(delete);
                QLBHDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region new category
        public IEnumerable<NewCategory> listcategory()
        {
            return QLBHDBContext.NewCategories.ToList();
        }
        public bool Create(string session, NewCategory entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = session;
                QLBHDBContext.NewCategories.Add(entity);
                QLBHDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(string session, NewCategory entity)
        {
            NewCategory edit = QLBHDBContext.NewCategories.Where(x => x.ID == entity.ID).SingleOrDefault();
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
                NewCategory delete = QLBHDBContext.NewCategories.Where(x => x.ID == ID).SingleOrDefault();
                QLBHDBContext.NewCategories.Remove(delete);
                QLBHDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public NewCategory FindCtgrByID(int ID)
        {
            return QLBHDBContext.NewCategories.Where(x => x.ID == ID).SingleOrDefault();
        }
        public string Category(long? CategoryID)
        {
            var res = QLBHDBContext.NewCategories.Where(x => x.ID == CategoryID).SingleOrDefault();
            if (res == null)
                return "";
            return res.Name;
        }
        #endregion
    }
}
