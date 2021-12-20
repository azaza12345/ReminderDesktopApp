using System;
using System.Text;

namespace DatabaseFiller
{
    public class StringRandomizer
    {
        private static readonly Random Random = new Random((int)DateTime.Now.Ticks);
        
        public string GetRandomString(int size)
        {
            var stringBuilder = new StringBuilder();
            
            for (int i = 0; i < size; i++)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Random.NextDouble()) + 65));
                stringBuilder.Append(ch);
            }

            return stringBuilder.ToString();
        }
    }
}