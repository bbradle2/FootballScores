using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballScores.Data
{

    public class Rank
    {
        public int rank { get; set; }
        public string school { get; set; }
        public string conference { get; set; }
        public int? firstPlaceVotes { get; set; }
        public int? points { get; set; }
    }

    public class Poll
    {
        public string poll { get; set; }
        public List<Rank> ranks { get; set; }
    }

    public class Ranking
    {
        public int season { get; set; }
        public string seasonType { get; set; }
        public int week { get; set; }
        public List<Poll> polls { get; set; }
    }




}

