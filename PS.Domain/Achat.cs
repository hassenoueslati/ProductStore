using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
    public class Achat
    {
        public DateTime DateAchat { get; set; }
        public int Quantite { get; set; }
        public virtual Product Product { get; set; }
        public virtual Client Client { get; set; }
        [ForeignKey("Product")]
        public int ProductFK { get; set; }
        [ForeignKey("Client")]
        public int ClientFK { get; set; }
    }
}
