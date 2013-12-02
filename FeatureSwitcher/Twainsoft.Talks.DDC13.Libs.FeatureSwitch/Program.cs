using System;
using FeatureSwitcher;
using FeatureSwitcher.Configuration;

namespace Twainsoft.Talks.DDC13.Libs.FeatureSwitch
{
    static class Program
    {
        static void Main()
        {
            // Features.Are.ConfiguredBy.Custom(Features.OfType<Colorize>.Enabled);
            // Features.Are.AlwaysEnabled();
            Features.Are.ConfiguredBy.AppConfig();

            var c = new Colorize();

            //if (Feature<Colorize>.Is().Enabled)
            if (c.Is().Enabled)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            //var context = new Context();

            //if (Feature<Colorize>.Is().EnabledInContextOf(context))
            //{
            //    Console.BackgroundColor = ConsoleColor.Blue;
            //    Console.ForegroundColor = ConsoleColor.Yellow;
            //}

            Console.WriteLine("Feature Test!");
            Console.ReadLine();
        }
    }
}
