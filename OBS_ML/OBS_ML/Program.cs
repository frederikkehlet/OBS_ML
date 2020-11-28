using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBS.WebSocket.NET;
using Newtonsoft.Json.Linq;

namespace OBS_ML
{
    class Program
    {
        static void Main(string[] args)
        {
            var _obs = new ObsWebSocket();

            _obs.Connect("ws://127.0.0.1:4444", "");

            var settings = _obs.Api.GetSourceSettings("PictureOverlay");

            var currentDir = Directory.GetCurrentDirectory();
            var imagesDir = Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\..\Images"));
            var imageName = "check";
            var filePath = $"{imagesDir}/{imageName}.png".Replace(@"\", @"/");

            string json = "{\"file\": \"" + filePath + "\"}";

            JObject obj = JObject.Parse(json);

            _obs.Api.SetSourceSettings("PictureOverlay", new JObject(obj));

            Console.ReadLine();
        }
    }
}
