using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TCTest.Test
{
    [TestClass]
    public class RawTournamentTests
    {
        [TestMethod]
        public void TestDate()
        {
            string rawText = "Start Date: 9/7/2018&nbsp;&nbsp;End Date: 9/9/2018";

            RawTournament tournament = new RawTournament();
            tournament.Date = rawText;

            Assert.IsNotNull(tournament.StartDate);
            Assert.IsNotNull(tournament.EndDate);
        }
    }
}
