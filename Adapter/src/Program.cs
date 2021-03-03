using System;
using Adapter.src.entities;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var captain = new Captain(new FishingBoatAdapter());
            captain.Row();
        }
    }
}
