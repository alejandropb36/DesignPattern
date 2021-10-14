using System;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = Singleton.Log.Instance;
            log.Save("a");
            log.Save("b");
        }
    }
}
