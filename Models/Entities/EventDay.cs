using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApi.Models.Entities
{
    public class EventDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }

        public int Length { get; set; }

        //foreign key
        public int LocationId { get; set; }
        //navigation property till en location
        //varje event har en location
        public Location Location { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}
