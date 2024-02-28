using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFremwork_homework2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }


        public override string ToString()
        {
            return $"Id :{Id} - Name: {Name} - Price: {Price} - Date: {Date} - BrandId: {BrandId}";
        }
    }
}
