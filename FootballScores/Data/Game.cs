using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballScores.Data
{
    public class Game
    {

        private DateTime _start_date;
        public int? id { get; set; }
        public int season { get; set; }
        public int week { get; set; }
        public string season_type { get; set; }
        public DateTime start_date
        {
            get
            {
                return _start_date;
            }
            set
            {
                _start_date = value.ToLocalTime();
                year = _start_date.Year;
            }
        }
        public bool? _tbd { get; set; }
        public bool? neutral_site { get; set; }
        public bool? conference_game { get; set; }
        public int? attendance { get; set; }
        public int? venue_id { get; set; }
        public string venue { get; set; }
        public int? home_id { get; set; }
        public string home_team { get; set; }
        public string home_conference { get; set; }
        public int? home_points { get; set; }
        public List<int?> home_line_scores { get; set; }
        public string home_post_win_prob { get; set; }
        public int? away_id { get; set; }
        public string away_team { get; set; }
        public string away_conference { get; set; }
        public int? away_points { get; set; }
        public List<int?> away_line_scores { get; set; }
        public string away_post_win_prob { get; set; }
        public string excitement_index { get; set; }

        public string ast => "@";

        public int year { get; private set; }

    }
}
