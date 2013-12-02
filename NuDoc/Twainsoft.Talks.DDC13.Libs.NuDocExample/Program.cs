using System;
using System.Reflection;
using ClariusLabs.NuDoc;

namespace Twainsoft.Talks.DDC13.Libs.NuDocExample
{
    static class Program
    {
        static void Main()
        {
            //var docReader = DocReader.Read("ClariusLabs.NuDoc.xml");
            var docReader = DocReader.Read(Assembly.LoadFrom("ClariusLabs.NuDoc.dll"));

            //docReader.Accept(new MarkdownVisitor("ausgabe-ohne-reflection.md"));
            docReader.Accept(new MarkdownVisitor("ausgabe-mit-reflection.md"));

            Console.ReadLine();
        }
    }
}
