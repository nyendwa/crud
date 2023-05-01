using System.ComponentModel.DataAnnotations;

namespace CustomerCRUD
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}