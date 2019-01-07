using MarketOtomasyon.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.Entities
{
    [Table("Packages")]
    public class Package : BaseEntity<Guid>
    {
        public Package()
        {
            this.Id = Guid.NewGuid();
        }
        public int KoliAdedi { get; set; }
        public int Barkod { get; set; }


    //     [ForeignKey("ProductId")]
    //    public virtual Product Product { get; set; }
    }

}
