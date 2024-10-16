using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub_User_Activity.Data
{
    public class Activities
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public Actor? actor { get; set; }
        public Repo? repo { get; set; }
        public Payload? payload { get; set; }
        public bool @public { get; set; }
        public DateTime? created_at { get; set; }
    }
}
