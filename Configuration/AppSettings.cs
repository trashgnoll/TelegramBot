using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillOverbot.Configuration
{
    public class AppSettings
    {
        public AppSettings() {
            BotToken = String.Empty;    
        }
        public string BotToken { get; set; }
    }
}
