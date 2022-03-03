using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Generator
{
    public enum TypeFormart
    {
        Json,
        Pipes
    }

    public enum TypeCharacter
    {
        Normal,
        Uppercase,
        Lowercase
    }

    public interface IBuilderGenerator
    {
        public void Reset();
        public void SetContent(List<string> content);
        public void SetPath(string path);
        public void SetFormat(TypeFormart format);
        public void SetCharacter(TypeCharacter character = TypeCharacter.Normal);
    }
}
