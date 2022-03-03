using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Generator
{
    public class GeneratoConcretBuilder : IBuilderGenerator
    {
        private Generator _generator;

        public GeneratoConcretBuilder()
        {
            Reset();
        }

        public void Reset() => _generator = new Generator();

        public void SetCharacter(TypeCharacter character = TypeCharacter.Normal) => _generator.Character = character;

        public void SetContent(List<string> content) => _generator.Content = content;

        public void SetFormat(TypeFormart format) => _generator.Formart = format;

        public void SetPath(string path) => _generator.Path = path;

        public Generator GetGenerator() => _generator;
    }
}
