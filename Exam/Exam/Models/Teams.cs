using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Models
{
    public class Teams
    {
        public int Nilai { get; set; }
        public string Name { get; set; }

        public Teams()
        {

        }

        public Teams(int nilai, string name)
        {
            Nilai = nilai;
            Name = name;
        }
    }
}