using SportsBet.Data.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBet.Data.Model
{
    public class Event : DataModel
    {
        public Event(int eventID,
                     string name,
                     double oddsForFirstTeam,
                     double oddsForDraw,
                     double oddsForSecondTeam,
                     DateTime startDate)
        {
            this.EventID = eventID;
            this.Name = name;
            this.OddsForFirstTeam = oddsForFirstTeam;
            this.OddsForDraw = oddsForDraw;
            this.OddsForSecondTeam = oddsForSecondTeam;
            this.StartDate = startDate;
        }
        public int EventID { get; set; }

        public string Name { get; set; }

        public double OddsForFirstTeam { get; set; }

        public double OddsForDraw { get; set; }

        public double OddsForSecondTeam { get; set; }

        public DateTime StartDate { get; set; }
    }
}
