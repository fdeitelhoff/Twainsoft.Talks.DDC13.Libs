using System;
using System.IO;
using ClariusLabs.NuDoc;

namespace Twainsoft.Talks.DDC13.Libs.NuDocExample
{
    public class MarkdownVisitor : Visitor
    {
        private StreamWriter StreamWriter { get; set; }

        public MarkdownVisitor(string file)
        {
            StreamWriter = new StreamWriter(file, false);
            Console.SetOut(StreamWriter);
            Console.SetError(StreamWriter);
        }

        public override void VisitMember(Member member)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("# " + member.Id);

            if (member.Info != null)
            {
                Console.WriteLine("### " + member.Info.Module.FullyQualifiedName);
            }

            base.VisitMember(member);
        }

        public override void VisitSummary(Summary summary)
        {
            Console.WriteLine();
            Console.WriteLine("## Summary");
            base.VisitSummary(summary);
        }

        public override void VisitRemarks(Remarks remarks)
        {
            Console.WriteLine();
            Console.WriteLine("## Remarks");
            base.VisitRemarks(remarks);
        }

        public override void VisitExample(Example example)
        {
            Console.WriteLine();
            Console.WriteLine("### Example");
            base.VisitExample(example);
        }

        public override void VisitC(C code)
        {
            // Wrap inline code in ` according to Markdown syntax.
            Console.Write(" `");
            Console.Write(code.Content);
            Console.Write("` ");

            base.VisitC(code);
        }

        public override void VisitCode(Code code)
        {
            Console.WriteLine();
            Console.WriteLine();

            // Indent code with 4 spaces according to Markdown syntax.
            foreach (var line in code.Content.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                Console.Write("    ");
                Console.WriteLine(line);
            }

            Console.WriteLine();
            base.VisitCode(code);
        }

        public override void VisitText(Text text)
        {
            Console.Write(text.Content);
            base.VisitText(text);
        }

        public override void VisitPara(Para para)
        {
            Console.WriteLine();
            Console.WriteLine();
            base.VisitPara(para);
            Console.WriteLine();
            Console.WriteLine();
        }

        public override void VisitSee(See see)
        {
            var cref = NormalizeLink(see.Cref);
            if (!String.IsNullOrWhiteSpace(cref))
            {
                Console.Write(" [{0}]({1}) ", cref.Substring(2), cref);
            }
        }

        public override void VisitSeeAlso(SeeAlso seeAlso)
        {
            var cref = NormalizeLink(seeAlso.Cref);
            Console.WriteLine("[{0}]({1})", cref.Substring(2), cref);
        }

        private string NormalizeLink(string cref)
        {
            if (!String.IsNullOrWhiteSpace(cref))
            {
                return cref.Replace(":", "-").Replace("(", "-").Replace(")", "");
            }
            
            return "";
        }
    }
}
