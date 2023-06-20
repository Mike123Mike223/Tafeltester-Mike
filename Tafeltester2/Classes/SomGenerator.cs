using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Tafeltester2
{
    public class SomGenerator
    {
        private const int Plus = 0;
        private const int Min = 1;
        private const int Delen = 2;
        private const int Vermedigvuldigen = 3;
        private char[] _operators = { '+', '-', '/', '*' };
        private Random _random;

        public SomGenerator()
        {
            _random = new Random();
        }

        public SomModel MaakEasyRekensom()
        {
            double getal1 = GetEasyRandomGetal();
            double getal2 = GetEasyRandomGetal();
            int operatorIndex = GetEasyRandomOperatorIndex(); 
            char OperatorsChar = _operators[operatorIndex];
            string som = $"{getal1} {OperatorsChar} {getal2}";
            double antwoord = BerekenAntwoord(getal1, operatorIndex, getal2);
            return new SomModel(som, antwoord);
        }

        public SomModel MaakNormalRekensom()
        {
            int getal1 = GetNormalRandomGetal();
            int getal2 = GetNormalRandomGetal();
            int operatorIndex = GetNormalOperatorIndex();
            char operatorChar = _operators[operatorIndex];
            string som = $"{getal1} {operatorChar} {getal2}";
            int antwoord = (int) BerekenAntwoord(getal1, operatorIndex, getal2);
            if (operatorIndex == 2)
            {
                 som = $"{antwoord} {operatorChar} {getal2}";
                return new SomModel(som, getal1);
            }
            return new SomModel(som, antwoord);
        }

        public SomModel MaakHardRekensom()
        {
            double getal1 = GetHardRandomGetal();
            double getal2 = GetHardRandomGetal();
            int operatorIndex = GetHardRandomOperatorIndex();
            char operatorChar = _operators[operatorIndex];
            string som = $"{getal1} {operatorChar} {getal2}";
            double antwoord = BerekenAntwoord(getal1, operatorIndex, getal2);
            return new SomModel(som, antwoord);
        }

        private double GetEasyRandomGetal()
        {
            double randomGetal = _random.NextDouble();
            randomGetal = randomGetal * 100;
            double afgerondGetal = Math.Round(randomGetal, 0);
            return Math.Max(1, afgerondGetal);
        }

        private int GetNormalRandomGetal()
        { 
            int randomGetal = _random.Next(1,99);
            return randomGetal;
        }

        private double GetHardRandomGetal()
        {
            double randomGetal = _random.NextDouble();
            randomGetal = randomGetal * 100;
            double afgerondGetal = Math.Round(randomGetal, 0);
            return Math.Max(1, afgerondGetal);
        }

        private double BerekenAntwoord(double getal1, int operatorIndex, double getal2)
        {
            // dit is net zoals javascripts if else maar ander geschreven
            switch (operatorIndex)
            {
                case Plus:
                    return getal1 + getal2;
                case Min:
                    return getal1 - getal2;
                case Delen:
                    // delen door 2 getallen, kan een breuk als uitkomst hebben
                    // 2 decimale achter de comma is goed.
                    return Math.Round(getal1 / getal2, 2);
                case Vermedigvuldigen:
                    return getal1 * getal2;
                default:
                    return 0;
            }
        }
        // deze method is 'private', dit is omdat ik deze method niet van buiten de class wil kunnen aanroepen.
        //hard alles
        private int GetHardRandomOperatorIndex()
        {
            return _random.Next(0, 4);
        }
        //easy alleen plus min
        private int GetEasyRandomOperatorIndex()
        {
            return _random.Next(0, 2);
        }
        //bij normaal wil ik alleen (x /) keer en delen
        private int GetNormalOperatorIndex()
        {
            return _random.Next(2, 4);
        }
    }
}