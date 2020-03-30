using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace TriviaClient.JSON_Classes
{
    [MessagePackObject]
    public class Question
    {
        [Key("question")]
        public string QuestionString { get; set; }
        [Key("answers")]
        public string[] PossibleAnswers { get; set; }
    }
}
