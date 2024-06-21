using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Repositories.Models
{
    public partial class Account
    {
        [Key]
        public Guid AccountID { get; set; }

        public string? UserName { get; set; }
        public string? Password { get; set; }

        public int ClassID { get; set; }
        public Class? Class { get; set; }

    }
}
