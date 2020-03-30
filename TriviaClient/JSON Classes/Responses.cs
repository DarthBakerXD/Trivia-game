using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace TriviaClient.JSON_Classes
{
    [MessagePackObject]
    class LoginResponse
    {
        [Key("status")]
        public int Status { get; set; }
    }

    [MessagePackObject]
    class SignupResponse
    {
        [Key("status")]
        public int Status { get; set; }
    }

    [MessagePackObject]
    class GetRoomsResponse
    {
        [Key("status")]
        public int Status { get; set; }

        [Key("rooms")]
        public Room[] Rooms { get; set; }
    }

    [MessagePackObject]
    class JoinRoomResponse
    {
        [Key("status")]
        public uint Status { get; set; }
    }

    [MessagePackObject]
    class CreateRoomResponse
    {
        [Key("status")]
        public uint Status { get; set; }
        [Key("id")]
        public uint Id { get; set; } // Room ID Of Newly Created Room
    }

    [MessagePackObject]
    class GetHighscoreResponse
    {
        [Key("status")]
        public uint Status { get; set; }
        [Key("highscores")]
        public KeyValuePair<string, uint>[] Highscores { get; set; }
    }

    [MessagePackObject]
    class GetRoomStateResponse
    {
        [Key("status")]
        public uint Status { get; set; }
        [Key("room")]
        public Room Room { get; set; }
    }

    [MessagePackObject]
    class GetQuestionResponse
    {
        [Key("status")]
        public uint Status { get; set; }
        [Key("question")]
        public Question Question { get; set; }
    }
    [MessagePackObject]
    class SubmitAnswerResponse
    {
        [Key("status")]
        public uint Status { get; set; }
        [Key("correctanswer")]
        public string CorrectAnswer { get; set; }
    }
    [MessagePackObject]
    class GetGameResultsResponse
    {
        [Key("status")]
        public uint Status { get; set; }
        [Key("results")]
        public PlayerResults[] Results { get; set; }
    };
    [MessagePackObject]
    class GetStatsResponse
    {
        [Key("status")]
        public uint Status { get; set; }
        [Key("stats")]
        public PlayerResults Stats { get; set; }
    }
}
