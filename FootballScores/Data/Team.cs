using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballScores.Data
{
    public class Team
    {
        public int? id { get; set; }
        public string school { get; set; }
        public string mascot { get; set; }
        public string abbreviation { get; set; }
        public string alt_name_1 { get; set; }
        public string alt_name_2 { get; set; }
        public string alt_name_3 { get; set; }
        public string conference { get; set; }
        public string division { get; set; }
        public string color { get; set; }
        public string alt_color { get; set; }
        public List<string> logos { get; set; }
    }
}
