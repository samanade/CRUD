using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class Workout
    {
        public int ID { get; set; }
        public string workoutTitle { get; set; }
        public DateTime workoutDate { get; set; }
        public string workoutThumbnail { get; set; }
        public virtual Client Client { get;  set; }
      
    }


}