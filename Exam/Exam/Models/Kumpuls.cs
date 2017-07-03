using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Models
{
    public class Kumpuls
    {
        public int Nilai { get; set; }
        public string Name { get; set; }

        public Kumpuls()
        {

        }

        public Kumpuls(int nilai, string name)
        {
            Nilai = nilai;
            Name = name;
        }
    }
}