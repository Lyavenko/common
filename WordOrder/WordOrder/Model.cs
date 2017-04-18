using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordOrder
{

    static class Model
    {

        private static List<string> Sentences = new List<string>() { "I am master Joda", "регулируемЗеркала пристегиваемся ставимНейтраль заводимся" };

        public class Task
        {
            public string CorrectSentence;
            public List<string> ShuffledSentence;

            public Task(string CorrectSentence)
            {
                ShuffledSentence = CorrectSentence.Split(' ').ToList();
                ShuffledSentence.Shuffle();
            }
        }

        public static Task MakeTask()
        {
            return new Task(Sentences[0]);
        }
    }

    static class Helper
    {
        private static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
