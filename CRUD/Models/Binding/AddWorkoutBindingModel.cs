using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models.Binding
{
    public class AddWorkoutBindingModel
    {
        public string workoutTitle { get; set; }
        public DateTime workoutDate { get; set; }
        public string workoutThumbnail { get; set; }
        public int ClientID { get; set; }
    }
}
