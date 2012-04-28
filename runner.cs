using System;
using System.Diagnostics;
using System.IO;

class TexturePackerRunner
{
    static void Main()
    {
        string[] cmds = System.Environment.GetCommandLineArgs();

        string TexturePackerPath = @"C:\Program Files\TexturePacker\bin\TexturePacker.exe";
        string Argument =  @"--allow-free-size --max-width 2048 --max-height 2048 --opt RGBA4444 --dither-fs-alpha ";

        System.Diagnostics.Process p;

        if (cmds.Length > 1)
        {
            Directory.CreateDirectory("result");

            for (int i = 1; i < cmds.Length; i++)
            {
                Console.WriteLine(@"Processing : " + cmds[i]);
                string name = Path.GetFileNameWithoutExtension(cmds[i]);
                p = System.Diagnostics.Process.Start(TexturePackerPath, Argument + cmds[i] + @" --sheet " + @"result\" + name + @".png");
                p.WaitForExit();
            }
        }
        else
        {
            Console.WriteLine("no arguments.");
        }
        System.Threading.Thread.Sleep(3000);
    }
}

