using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace TriviaClient.JSON_Classes
{
    [MessagePackObject]
    public class PlayerResults
    {
        [Key("username")]
        public string Username { get; set; }
        [Key("correctanswers")]
        public uint CorrectAnswers { get; set; }
        [Key("wronganswers")]
        public uint WrongAnswers { get; set; }
        [Key("avgtime")]
        public uint AverageTime { get; set; }
    }
}
