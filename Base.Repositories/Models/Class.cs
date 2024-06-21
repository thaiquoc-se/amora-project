using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Repositories.Models
{
    public partial class Class
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassID { get; set; }

        public string? ClassCode { get; set; }

        public Guid LecturerID { get; set; }
        public Account? Account { get; set; }

        public Guid StudentID { get; set; }

        public IEnumerable<Account> Accounts { get; set; } = new List<Account>();

    }
}
