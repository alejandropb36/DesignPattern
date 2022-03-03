using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Linq;
using System.IO;

namespace Tools.Generator
{
    public class Generator
    {
        public List<string> Content { get; set; }
        public string Path { get; set; }
        public TypeFormart Formart { get; set; }
        public TypeCharacter Character { get; set; }

        public void Save()
        {
            string result = "";
            result = Formart == TypeFormart.Json ? GetJson() : GetPipe();
            
            if (Character == TypeCharacter.Uppercase) result = result.ToUpper();
            if (Character == TypeCharacter.Lowercase) result = result.ToLower();
            
            File.WriteAllText(Path, result);
        }

        private string GetJson() => JsonSerializer.Serialize(Content);

        private string GetPipe() => Content.Aggregate((accum, current) => accum + "|" + current);
    }
}
