using System.Linq;
using System;

namespace ApiFake1.DataGen
{
    public static class RandomizarALFANUM
    {
        private static Random _random = new Random();
        private static List<char> _alfaNumChars = new List<char>();
        private static List<char> _numChars = new List<char>();
      
        public static string ProximoAlfaNumerico(int length)
        {
            if (_alfaNumChars.Count == 0)
            {
                _PopularChars();
            }

            var chars = Enumerable.Range(0,length).Select(x => 
            {
                var randomCharIdx = _random.Next(0,_alfaNumChars.Count-1);
                var randomChar = _alfaNumChars[randomCharIdx];
                return randomChar;
            });
            return string.Join("",chars);
        }

        public static string ProximoNumerico(int length)
        {
            if (_alfaNumChars.Count == 0)
            {
                _PopularChars();
            }

            var chars = Enumerable.Range(0,length).Select(x => 
            {
                var randomCharIdx = _random.Next(0,_numChars.Count-1);
                var randomChar = _numChars[randomCharIdx];
                return randomChar;
            });
            return string.Join("",chars);
        }

        private static void _PopularChars()
        {
            var _charsAlfaNumDecimal = Enumerable.Range(48,57-48+1)   //48 a 57 é número
            .Union(Enumerable.Range(65,90-65+1)) //65 ate 90 maiúsculo
            .Union(Enumerable.Range(97,122-97+1)) //97 a 122 minuscula
            .ToList();

            _alfaNumChars = _charsAlfaNumDecimal
            .Select(x => Convert.ToChar(x))
            .ToList();

            var _charsNumDecimal = Enumerable.Range(48,57-48+1)   //48 a 57 é número
            .ToList();

            _numChars = _charsNumDecimal
            .Select(x => Convert.ToChar(x))
            .ToList();
        }
    }
}