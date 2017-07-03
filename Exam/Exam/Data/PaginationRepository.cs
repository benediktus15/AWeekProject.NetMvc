using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exam.Models;

namespace Exam.Data
{
    public class PaginationRepository
    {
        private static Models.Pagination[] _page = new Models.Pagination[]
        {
            new Models.Pagination()
            {
                no = 1,
                soal = "1+1 = ",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih{a = "2", b = "3", c = "4", d = "5"}
                },
                jawab = "A",
            },

            new Models.Pagination()
            {
                no = 2,
                soal = "1+3 = ",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih(){a = "2", b = "3", c = "4", d = "5"}
                },
                jawab = "C",
            },

            new Models.Pagination()
            {
                no = 3,
                soal = "2+3 = ",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih(){a = "2", b = "3", c = "4", d = "5"}
                },
                jawab = "D",
            },

            new Models.Pagination()
            {
                no = 4,
                soal = "8/2 = ",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih(){a = "2", b = "3", c = "4", d = "5"}
                },
                jawab = "C",
            },

            new Models.Pagination()
            {
                no = 5,
                soal = "100/10 = ",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih(){a = "2", b = "3", c = "4", d = "10"}
                },
                jawab = "D",
            }
        };

        public Models.Pagination getPage(int id)
        {
            Models.Pagination pageClick = new Models.Pagination();
            /*foreach(var page in _page)
            {
                if(page.no == id)
                {
                    pageClick = page;
                    break;
                }
            }*/

            return _page[id - 1];
        }

        public Models.Pagination getDel(int id)
        {
            Models.Pagination pageClick = new Models.Pagination();
            foreach (var page in _page)
            {
                if (page.no == id)
                {
                    pageClick = page;
                    break;
                }
            }

            return pageClick;
        }

        public Models.Pagination[] getAll()
        {
            return _page;
        }



        public void UpdateEntry1(Models.Pagination page)
        {

            int entryIndex = Array.FindIndex(_page, e => e.no == page.no);

            if (entryIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find an entry with an ID of {0}", page.no));
            }

            PaginationRepository._page[entryIndex] = page;
        }

        public void DeleteEntry(Models.Pagination page)
        {
            // Find the index of the entry that we need to delete.
            int entryIndex = Array.FindIndex(_page, e => e.no == page.no);

            if (entryIndex == -1)
            {
                throw new Exception(
                    string.Format("Unable to find an entry with an ID of {0}", page.no));
            }

            _page = _page.Where((val, idx) => idx != entryIndex).ToArray();
        }

        public void AddEntry1(Models.Pagination page)
        {
            // Get the next available entry ID.
            int nextAvailableEntryId;
            try
            {
                nextAvailableEntryId = PaginationRepository._page
               .Max(e => e.no) + 1;
            }
            catch
            {
                nextAvailableEntryId = 1;
            }

            page.no = nextAvailableEntryId;

            List<Models.Pagination> lst = _page.OfType<Models.Pagination>().ToList();

            lst.Add(page);

            _page = lst.ToArray();
        }
    }
}