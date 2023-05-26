using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace SkillOverbot.Services
{
    public class Parser
    {
        public static string LenMode( string input )
        { 
            return $"В вашем сообщении {input.Length} символов";
        }
        public static string SumMode(string input)
        {
            Single total = 0;
            string[] words = input.Split(' ');
            foreach (string word in words)
            {
                Single number;
                if(Single.TryParse(word, out number) )
                    total += number;
            }
            return $"Сумма чисел {total}";
        }
    }
}
