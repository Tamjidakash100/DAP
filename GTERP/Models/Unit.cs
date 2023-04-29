using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GTERP.Models
{
    public class Unit
    {

        public int UnitId { get; set; }

        [Required]
        [Display(Name = "Unit Name")]
        [StringLength(50)]
        public string UnitName { get; set; }

        [Display(Name = "Unit Name")]
        [StringLength(50)]
        public string UnitNameBangla { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Unit Short Name")]
        public string UnitShortName { get; set; }


        public virtual ICollection<Product> vProductUnit { get; set; }



    }
}