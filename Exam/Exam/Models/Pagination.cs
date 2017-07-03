using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam.Models
{
    public class Pagination
    {
        public int no { get; set; }
        public string soal { get; set; }
        public Pilih[] pilih { get; set; }
        public string jawab { get; set; }

        public Pagination()
        {

        }

        public Pagination(int No, string Soal, string Jawab, Pilih[] Pilih)
        {
            no = No;
            soal = Soal;
            jawab = Jawab;
            pilih = Pilih;
        }
    }
}