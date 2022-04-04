using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
    //sealed pour bloquer l'heritage
    public class Product
    {
  
        public int ProductId { get; set; }
        [Required(ErrorMessage ="name is required")]
        [MaxLength(25,ErrorMessage ="name max length must be less then 25")] //input length
        [StringLength(50)] //proporty length
        public string Name { get; set; }
        [Display(Name ="Production Date")]
        [DataType(DataType.Date)]
        public DateTime DateProd { get; set; }
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImageName { get; set; }
        // ? optionnelle
        //[ForeignKey("Category")]
        public int? CategoryFK { get; set; }
       
        [ForeignKey("CategoryFK")]
        public virtual Category Category { get; set; }

        public virtual List<Provider> Providers { get; set; }

        public virtual List<Achat> Achats { get; set; }

        public override string ToString()
        {
            return "Name : "+ Name + " Quantity : " + Quantity + "Price :" + Price + "DateProd : " + DateProd;
        }
        public virtual void GetMyType()
        {
            Console.Write("Je suis un produit");
        }
    }
}
