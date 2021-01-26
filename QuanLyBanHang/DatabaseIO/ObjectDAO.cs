using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIO
{
    public class ObjectDAO
    {
        private QLBH QLBHDBContext = null;
        public ObjectDAO()
        {
            QLBHDBContext = new QLBH();
        }

        public void AddObject<ObjectType>(ObjectType obj)
        {
            QLBHDBContext.Set(obj.GetType()).Add(obj);
            QLBHDBContext.SaveChanges();
        }    
    }
}
