using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class Blog : BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Guid AuthorID {  get; set; }
        public User user { get; set; }
        public DateTime PublishedDate { get; set; }
        public string? Status { get; set; }
    }
}
