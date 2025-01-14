using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkTest.Data
{
    [Table("ActiveUser")]
    public class ActiveUser
    {
        public int AutoId { get; set; }
        public int Id { get; set; }
        public bool Active { get; set; } = false;

        //references
        public User User { get; set; } = null!;
    }
}