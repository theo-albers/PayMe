using System.ComponentModel.DataAnnotations;

namespace PayMe.DomainModel.Customers
{
    public class Customer
    {
        [Key] 
        [Required()]
        public int Id
        {
            get;
            set;
        }

        [Required()]
        [StringLength(100)]
        public string Name
        {
            get;
            set;
        }
    }
}
