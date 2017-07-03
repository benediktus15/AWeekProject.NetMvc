using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Data
{
    public class ListRevo
    {
        public List<Teams> GetTeam()
        {
            return ListRepository.Team;
        }

        public List<Kumpuls> GetTeam1()
        {
            return ListRepository.Kumpul;
        }


        public Teams GetTeam(int id)
        {
            Teams team = ListRepository.Team
                .Where(e => e.Nilai == id)
                .SingleOrDefault();

            return team;
        }

        public void AddEntry(Teams team)
        {
            // Get the next available entry ID.

            ListRepository.Team.Add(team);
        }

        public void UpdateEntry(Teams team)
        {
            // Find the index of the entry that we need to update.
            int entryIndex = ListRepository.Team.FindIndex(e => e.Nilai == team.Nilai);

            ListRepository.Team[0] = team;
        }
    }
}