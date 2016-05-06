using UnityEngine;
using System;
using System.IO;

namespace CompleteProject
{
    public class WriteFile : MonoBehaviour
    {
        public String fileN = "Output.txt";

        //void Start()
        //{
        //    File.AppendAllText(fileN, "New Game" + Environment.NewLine);
        //}

        public void WriteToFile(String code)
        {
            String output = (ToUnixTime()).ToString();
            output += "," + code + Environment.NewLine;

            File.AppendAllText(fileN, output);

            if (code.Equals("Player Died"))
            {
                File.AppendAllText(fileN, "Game End" + Environment.NewLine);
                File.AppendAllText(fileN, Environment.NewLine);
            }
        }

        // convert datetime to unix epoch seconds
        private static long ToUnixTime()
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((DateTime.Now.ToUniversalTime() - epoch).TotalSeconds);
        }

    }
}