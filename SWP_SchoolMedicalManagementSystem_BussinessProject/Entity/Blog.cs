using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class Blog
    {
        public int BlogID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int AuthorID {  get; set; }

        public DateTime PublishedDate { get; set; }

        public string Status { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
