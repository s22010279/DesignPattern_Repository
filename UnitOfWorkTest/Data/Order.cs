using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkTest.Data
{
    [Table("order")]
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public float OrderTotal { get; set; }
    }
}