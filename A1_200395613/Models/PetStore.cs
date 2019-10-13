using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A1_200395613.Models
{
    public class PetStore
    {
        public virtual int Id { get; set; }

        [DisplayName("Pet Store")] /*Shows "Pet Store`" as title in the form*/

        [DataType(DataType.Currency)]/*with the help of currency (data type) price appear in the form with $*/
        public virtual Decimal Price { get; set; }

        [Required]
        public virtual String Name { get; set; }

        [Required]
        public virtual String Description { get; set; }

        [Required]
        public virtual String Nutritional_Information { get; set; }

        [Required]
        public virtual String Weight { get; set; }

        [Required]
        public virtual String Type_of_animal_food_is_for { get; set; }

        [Required]
        public virtual String Animal { get; set; }

        public virtual int AName { get; set; }
        public virtual String ADescription { get; set; }


    }
}
