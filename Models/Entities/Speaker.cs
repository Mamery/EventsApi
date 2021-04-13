using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApi.Models.Entities
{
    public class Speaker
    {
        public int Id { get; set; }

        public string FirstName  { get; set; }

        public string LastName { get; set; }
        public string Company { get; set; }
        public string CompanyUrl { get; set; }
        public string BlogUrl { get; set; }
        public string Github { get; set; }
        //varje speaker can ha många lectures
        public int LectureId { get; set; }
        public ICollection<Lecture> Lecture { get; set; }



    }
}
