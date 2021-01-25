using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIO
{
    public class AdminUserDAO
    {
        private QLBH QLBHDBContext = null;
        public AdminUserDAO()
        {
            QLBHDBContext = new QLBH();
        }

        public bool Login(string username, string password)
        {
            var result = QLBHDBContext.AdminUsers.Where(tk => tk.Username == username && tk.Password == password).SingleOrDefault();
            if (result != null)
                return true;
            else
                return false;
        }
        public IEnumerable<AdminUser> listall()
        {
            return QLBHDBContext.AdminUsers.ToList();
        }

        public bool AddUser(AdminUser entity)
        {
            if(QLBHDBContext.AdminUsers.Where(x=>x.Username==entity.Username).SingleOrDefault()!=null)
            {
                return false;
            }
            else
            {
                QLBHDBContext.AdminUsers.Add(entity);
                QLBHDBContext.SaveChanges();
                return true;
            }
        }
        public AdminUser ChangeStatus(int ID)
        {
            AdminUser change = QLBHDBContext.AdminUsers.Where(x => x.ID == ID).SingleOrDefault();
            change.Status = !change.Status;
            QLBHDBContext.SaveChanges();
            return change;
        }
        public AdminUser FindUser(AdminUser entity)
        {
            return QLBHDBContext.AdminUsers.Where(x => x.Username == entity.Username && x.Password == entity.Password).SingleOrDefault();
        }
        public AdminUser FindUserByID(int ID)
        {
            return QLBHDBContext.AdminUsers.Where(x => x.ID == ID).SingleOrDefault();
        }
    }
}
