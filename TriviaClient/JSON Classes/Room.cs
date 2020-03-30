using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace TriviaClient.JSON_Classes
{
    [MessagePackObject]
    public class Room
    {
        [Key("metadata")]
        public RoomData Metadata { get; set; }
        [Key("players")]
        public string[] Players { get; set; }

        public override string ToString()
        {
            return Metadata.name;
        }
    }

    [MessagePackObject]
    public class RoomData
    {
        [Key("answertimeout")]
        public uint AnswerTimeout { get; set; }
        [Key("isactive")]
        public int IsActive { get; set; }
        [Key("maxplayers")]
        public uint MaxPlayers { get; set; }
        [Key("questioncount")]
        public uint QuestionCount { get; set; }
        [Key("roomid")]
        public uint id { get; set; }
        [Key("roomname")]
        public string name { get; set; }
    }
}
