using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCTest
{
    public class Match
    {
        public int Id { get; set; }

        public int DivisionId { get; set; }

        // F/PL/SF ...
        public string Round { get; set; }

        public MatchType MatchType { get; set; }

        public bool IsConsolation { get; set; }

        public int Winner1Id { get; set; }

        public int? Winner2Id { get; set; }

        public int Loser1Id { get; set; }

        public int? Loser2Id { get; set; }

        public int WinnerSet1 { get; set; }

        public int LoserSet1 { get; set; }

        public int? Set1TieBreak { get; set; }

        public int WinnerSet2 { get; set; }

        public int LoserSet2 { get; set; }

        public int? Set2TieBreak { get; set; }

        public int WinnerSet3 { get; set; }

        public int LoserSet3 { get; set; }

        public int? Set3TieBreak { get; set; }

        public int WinnerSet4 { get; set; }

        public int LoserSet4 { get; set; }

        public int? Set4TieBreak { get; set; }

        public int WinnerSet5 { get; set; }

        public int LoserSet5 { get; set; }

        public int? Set5TieBreak { get; set; }
    }
}
