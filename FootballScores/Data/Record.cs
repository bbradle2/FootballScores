using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballScores.Data
{
    public class Record
    {
        public int? year { get; set; }
        public string team { get; set; }
        public string conference { get; set; }
        public string division { get; set; }
        public Total total { get; set; }
        public Total conferenceGames { get; set; }
        public Total homeGames { get; set; }
        public Total awayGames { get; set; }
    }

    public class Total
    {
        public int? games { get; set; }
        public int? wins { get; set; }
        public int? losses { get; set; }
        public int? ties { get; set; }
    }

   
}


