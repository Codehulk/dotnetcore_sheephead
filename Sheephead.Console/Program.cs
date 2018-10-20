using System;

namespace Sheephead.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game(
                new Player("Doug"),
                new Player("Betty"),
                new Player("Bruce")
            );

            //g.Deal();
        }
    }
}
