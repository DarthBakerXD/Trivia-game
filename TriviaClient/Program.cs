using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TriviaClient
{
    public static class ClientSocket // Effectively A Global Variable
    {
        public static Socket client = new Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.Tcp);
        public static IPEndPoint serverEndPoint;
    }
    public class GlobalHelpers
    {
        public static byte[] CreateMessage<T>(string codeString, T jsonClass)
        {
            byte[] code = new ASCIIEncoding().GetBytes(codeString);
            byte[] serializedJson = MessagePack.MessagePackSerializer.Serialize<T>(jsonClass);
            byte[] message = new byte[code.Length + serializedJson.Length];
            Array.Copy(code, message, code.Length);
            Array.Copy(serializedJson, 0, message, code.Length, serializedJson.Length);
            return message;
        }
        public static string GetCode(byte[] response)
        {
            return Encoding.ASCII.GetString(response).Substring(0, 3);
        }
        public static byte[] GetMsgpack(byte[] response)
        {
            int newLength = response.Length - 3;
            byte[] subset = new byte[newLength];
            Array.Copy(response, 3, subset, 0, newLength);
            return subset;
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}
