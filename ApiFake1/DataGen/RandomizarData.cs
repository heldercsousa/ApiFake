using System.Linq;
using System;

namespace ApiFake1.DataGen
{
    public static class RandomizarData
    {
        private static Random _random = new Random();
      
        public static DateTime? Proximo(DateTime dataInicio, DateTime dataFim, bool canBeNull = false)
        {
            if (dataFim <= dataInicio)
            {
                throw new Exception("dataFim deve ser maior que dataInicio");
            }

            if (canBeNull)
            {
                var retornaNull = _random.Next(1, 5);
                if (retornaNull == 1)
                    return null;
            }

            var randonTick = _random.NextInt64(dataInicio.Ticks, dataFim.Ticks);

            return new DateTime(randonTick, DateTimeKind.Local);
        }
    }
}