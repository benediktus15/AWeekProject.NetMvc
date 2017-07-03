using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamAppLogin.Models;

namespace ExamAppLogin.Data
{
    public class PaginationRepository
    {
        private static Models.Pagination[] _page = new Models.Pagination[]
        {
            new Models.Pagination()
            {
                no = 1,
                soal = "By default, ASP.NET store SessionIDs in _________________ ",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih{a = "Cookies", b = "Cache", c = "Database", d = "Global variable"}
                },
                jawab = "A",
            },

            new Models.Pagination()
            {
                no = 2,
                soal = "Which of the following languages can be used to write server side scripting in ASP.NET?",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih(){a = "C-sharp", b = "VB", c = "C++", d = "a and b"}
                },
                jawab = "C",
            },

            new Models.Pagination()
            {
                no = 3,
                soal = "Choose the form in which Postback occur?",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih(){a = "HTMLForms", b = "Webforms", c = "Winforms"}
                },
                jawab = "D",
            },

            new Models.Pagination()
            {
                no = 4,
                soal = "What is the purpose of code behind ?",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih(){a = "To separate different sections of a page in to different files", b = "To merge HTML layout and code in to One file", c = "To separate HTML Layout and code to different file", d = "To ignore HTML usage"}
                },
                jawab = "C",
            },

            new Models.Pagination()
            {
                no = 5,
                soal = "Which one of the following is the last stage of the Web forms lifecycle?",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih(){a = "Page_Load", b = "Event Handling", c = "Page_Init", d = "Page_Unload"}
                },
                jawab = "D",
            },

            new Models.Pagination()
            {
                no = 6,
                soal = "When an .aspx page is requested from the web server, the out put will be rendered to browser in following format.",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih(){a = "HTML", b = "XML", c = "WML", d = "JSP"}
                },
                jawab = "D",
            },

            new Models.Pagination()
            {
                no = 7,
                soal = "Which of the following object is not an ASP component?",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih(){a = "LinkCounter", b = "Counter", c = "AdRotator", d = "File Access"}
                },
                jawab = "D",
            },

            new Models.Pagination()
            {
                no = 8,
                soal = "Which objects is used to create foreign key between tables?",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih(){a = "DataRelationship", b = "DataRelation", c = "DataConstraint", d = "Datakey"}
                },
                jawab = "D",
            },

            new Models.Pagination()
            {
                no = 9,
                soal = "Which of the following base class do all Web Forms inherit from?",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih(){a = "Window class", b = "Web class", c = "Page class", d = "Form class"}
                },
                jawab = "D",
            },

            new Models.Pagination()
            {
                no = 10,
                soal = "The Asp.net server control, which provides an alternative way of displaying text on web page, is",
                pilih = new Models.Pilih[]
                {
                    new Models.Pilih(){a = "< asp:label >", b = "< asp:listitem >", c = "< asp:button >"}
                },
                jawab = "C",
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

            List<Models.Pagination> lst = _page.OfType < Models.Pagination>().ToList();

            lst.Add(page);
            _page = lst.ToArray();
        }
    }
}