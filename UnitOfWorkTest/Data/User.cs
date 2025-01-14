using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkTest.Data
{
     [Table("Users")]
    public class User
    {
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("Name", TypeName = "varchar(500)")]
        public string Name { get; set; } = string.Empty;

        //references
        public IEnumerable<ActiveUser> ActiveUsers { get; set; } = null!;
    }
}