using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportClub.Models
{
    [Table("Admins")]
    public class Admin : User
    {
    }
}
