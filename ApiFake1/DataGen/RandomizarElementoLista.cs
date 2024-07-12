using System.Linq;
using System;

namespace ApiFake1.DataGen
{
    public class RandomizarElementoLista
    {
        private Random _random = new Random();
      
        public G Proximo<T,G>(T lista) where T : IList<G> where G : class
        {
            var randomElementIdx = _random.Next(0,lista.Count-1);
            var randomElement = lista[randomElementIdx];
            return randomElement;
        }
    }
}