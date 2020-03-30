using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace TriviaClient.JSON_Classes
{
    [MessagePackObject]
    class LoginRequest
    {
        [Key("username")]
        public string Username { get; set; }
        [Key("password")]
        public string Password { get; set; }
    }
    [MessagePackObject]
    class SignupRequest
    {
        [Key("username")]
        public string Username { get; set; }
        [Key("password")]
        public string Password { get; set; }
        [Key("email")]
        public string Email { get; set; }
    }
    [MessagePackObject]
    class JoinRoomRequest
    {
        [Key("id")]
        public uint Id { get; set; }
    }
    [MessagePackObject]
    class CreateRoomRequest
    {
        [Key("roomname")]
        public string Name { get; set; }
        [Key("maxusers")]
        public uint MaxUsers { get; set; }
        [Key("questioncount")]
        public uint QuestionCount { get; set; }
        [Key("answertimeout")]
        public uint TimePerQuestion { get; set; }
    }
    [MessagePackObject]
    class SubmitAnswerRequest
    {
        [Key("answer")]
        public string Answer { get; set; }
        [Key("elapsed")]
        public uint TimeUntilResponse { get; set; }
    };
}
