using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SZGYA13C_Oscar
{
    internal class Oscar
    {
        public string Azonosito { get; set; }
        public string Cim { get; set; }
        public int Ev { get; set; }
        public int Dij { get; set; }
        public int Jelolt { get; set; }

        public Oscar(string azonosito, string cim, int ev, int dij, int jelolt) 
        { 
            Azonosito = azonosito;
            Cim = cim;
            Ev = ev;
            Dij = dij;
            Jelolt = jelolt;
        }

        public static List<Oscar> FromFile(string path)
        {
            List<Oscar> oscar = new List<Oscar>();

            string[] line = File.ReadAllLines(path);

            foreach (var l in line.Skip(1))
            {
                string[] s = l.Split("\t");

                string Azonosito = s[0];
                string Cim = s[1];
                int Ev = int.Parse(s[2]);
                int Dij = int.Parse(s[3]);
                int Jelolt = int.Parse(s[4]);

                Oscar oscars = new(Azonosito, Cim, Ev, Dij, Jelolt);

                oscar.Add(oscars);
            }

            return oscar;
        }

        public override string ToString()
        {
            return $"{Azonosito}    {Cim}   {Ev}    {Dij}   {Jelolt}";
        }
    }
}
