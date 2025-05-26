using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class MedicalSupplier
    {
        public Guid Id { get; set; }

        public string? SupplyName { get; set; }

        public string? SupplyType { get; set; }

        public string? Unit {  get; set; }

        public int Quantity {  get; set; }   

        public string? Supplier {  get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

    }
}
