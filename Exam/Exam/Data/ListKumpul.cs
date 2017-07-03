using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exam.Models;

namespace Exam.Data
{
    public class ListKumpul
    {
        public List<Kumpuls> GetTeam()
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

        public void AddEntry(Kumpuls kumpul)
        {
            // Get the next available entry ID.

            ListRepository.Kumpul.Add(kumpul);
        }

        public void UpdateEntry(Kumpuls kumpul)
        {
            // Find the index of the entry that we need to update.
            int entryIndex = ListRepository.Team.FindIndex(e => e.Nilai == kumpul.Nilai);

            ListRepository.Kumpul[0] = kumpul;
        }
    }
}