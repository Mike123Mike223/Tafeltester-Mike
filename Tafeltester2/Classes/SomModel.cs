using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tafeltester2
{
    public class SomModel
    {
        private string _som;
        private double _antwoord;
        public SomModel(string som, double antwoord)
        {
            _som = som;
            _antwoord = antwoord;
        }
        public string GetSom()
        {
            return _som;
        }
        public double GetAntwoord()
        {
            return _antwoord;
        }
    }
}
