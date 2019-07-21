using System;
using System.Ini;

namespace IniLibrarySample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of IniDocument
            IniDocument document = new IniDocument();
            document.Load("Sample.ini");

            // Make some changes
            document.Sections["First"].Parameters.Add(
                new IniParameter("Property3", 512)
            );

            // Change syntax and formatting settings
            document.SyntaxDefinition = new IniSyntaxDefinition() {
                CommentStartChar = '#'
            };

            // Write out
            document.Save(Console.Out, new IniWriterFormattingSettings { SortParameters = true });

            // Wait for a key
            Console.ReadLine();
        }
    }
}
