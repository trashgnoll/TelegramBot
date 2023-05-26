using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillOverbot.Models
{
    public class Session
    {
        public Session()
        {
            MessageType = String.Empty;
        }
        public string MessageType{ get; set; }
    }
}
