using System.Collections.Generic;

namespace App.Entities
{
    public class Company
    {
        public ICollection<EndPoint> EndPoints { get; set; }
        public Company()
            => EndPoints = new List<EndPoint>();
    }
}