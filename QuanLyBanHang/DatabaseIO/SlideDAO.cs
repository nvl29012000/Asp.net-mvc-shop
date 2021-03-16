using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DatabaseIO
{
    public class SlideDAO
    {
        private QLBH QLBHDBContext = null;
        public SlideDAO()
        {
            QLBHDBContext = new QLBH();
        }

        public IEnumerable<Slide> topSlide()
        {
            return QLBHDBContext.Slides.OrderBy(x => x.DisplayOrder).Take(4).ToList();
        }
    }
}
