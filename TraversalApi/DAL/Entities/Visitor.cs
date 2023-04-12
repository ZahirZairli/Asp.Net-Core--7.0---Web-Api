using System.ComponentModel.DataAnnotations;

namespace TraversalApi.DAL.Entities
{
    public class Visitor
    {
        [Key]
        public int VisitorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
