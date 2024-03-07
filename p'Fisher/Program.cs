#define installer //Comment if you want to use p'Fisher application
                  //Uncomment if you want to use installer


using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Net.Http;
using System.Runtime.CompilerServices;


/*
using System.Windows.Media.Converters;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Windows.Documents;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Media;
using System.Web.Services.Description;
using System.Xml.Linq;
*/

namespace p_Fisher
{
    static internal class Program
    {
        public static string input_chars = "p'Fisher $~ ";

        public static ConsoleColor text_color = ConsoleColor.White;
        public static ConsoleColor logo_color = ConsoleColor.Cyan;
        public static ConsoleColor error_color = ConsoleColor.Red;
        public static ConsoleColor output_color = ConsoleColor.Yellow;
        public static ConsoleColor prompt_color = ConsoleColor.DarkGreen;

        public static bool isTitleChanged = false;

        [STAThread]
        static void Main() 
        {
            #if !installer

                logo();

                if (!isTitleChanged) Console.Title = " p'Fisher";

                //If user press Ctrl + C, the program will not be closed and starts Main() again
                //Console.CancelKeyPress += (s, e) => { Main(); };

                while (true)
                {
                    isTitleChanged = true;

                    string odp = console_input();
                    Console.ForegroundColor = output_color;

                    try { commands(odp); } catch (Exception) {}
                }

            #else

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new installer());

            #endif
        }

        static readonly Action<string> error = (content) => 
        {
            Console.ForegroundColor = error_color;
            Console.WriteLine(content);
            Console.ForegroundColor = text_color;
        };
        static readonly Action logo = () => 
        {
            //Console.WriteLine("\r\n\r\n    \r\n\r\n");
            Console.ForegroundColor = logo_color;
            Console.WriteLine("\r\n\r\n                                                                             \r\n               ]{  " +
                ":@@@@@@@} [@@>  ^@@@@@{. -@@%. .@@@:~@@@@@@@<.@@@@@@~     \r\n                ~@>:@@@.     [@@>:@@@   #@@+-@@%. .@@@:~@@#." +
                "    .@@@.  {@@*  \r\n     :@<-#%@=:     :@@@---.  [@@>:%%@@}--:. -@@%---@@@:~@@#----:.@@@.  {@@*  \r\n     :@@@:^@@[     :" +
                "@@@^^^:  [@@>  -^^)@@%(~-@@@^^^@@@:~@@%^^^^~.@@@(((%%^-  \r\n     :@@@:^@@[     :@@@.     [@@>:#<  .-#@@+-@@%. .@@@:~@@#. " +
                "   .@@@---#@#+  \r\n     :@@@:^@@[     :@@@.     [@@>:@@@   #@@+-@@%. .@@@:~@@#.    .@@@.  {@@*  \r\n     :@@@@@@~      :@" +
                "@@.     [@@>  ^@@@@@{. -@@%. .@@@:~@@@@@@@<.@@@.  {@@*  \r\n     :@@@:                                                    " +
                "               \r\n     .***.                                                                   \r\n                      " +
                "                             ..                        \r\n                                              ..:]=~<.         " +
                "              \r\n                                            .*(~.^+..-                       \r\n                       " +
                "                  .=[~*..    .=                       \r\n                                       .[<.:>.      :.          " +
                "             \r\n                                    .~#+=^~.       .+                        \r\n                        " +
                "         ..=#~+.            ^.                       \r\n                                 =#+.].             :.           " +
                "            \r\n                               :{( .<               .<.                      \r\n                         " +
                "    .)#:.<.                .<.                      \r\n                            -#)>-                   .:.           " +
                "           \r\n                          .>%+.+.                    ..                      \r\n                         ." +
                "[#: ~~                     .:                      \r\n                        .{#: -+                      .~            " +
                "          \r\n                       .##..^:                       .^.                     \r\n                      .#%}>" +
                ":.                        .{~                     \r\n                     .%#:>.                        .^=#*^:          " +
                "         \r\n                    .#%:>*-.                        .^^^+                    \r\n                   .(%##(*){" +
                "-                      +@@@@@#:                  \r\n                  .#%#.}~}+[.                     *%.+.==(@.         " +
                "        \r\n                 .(%%}. .:).                     .@%=@-==(@^                 \r\n                .+%%#.     .." +
                "                     >@@@@@@@{:                 \r\n                :%%%=                                                 " +
                "       \r\n               .(%%[                                                         \r\n               *%%#.          " +
                "                                               \r\n              :#%%*                                                    " +
                "      \r\n             .(%%]                                                           \r\n             *%%{.             " +
                "                                              \r\n            .#%%+                                                       " +
                "     \r\n            +#%(.       \r\n\r\n");
        };
        static readonly Func<string> console_input = () =>
        {
            Console.ForegroundColor = prompt_color;
            Console.Write(input_chars);

            Console.ForegroundColor = output_color;
            string odp = Console.ReadLine();

            Console.ForegroundColor = text_color;

            return odp;
        };
        static readonly Func<string, bool> IsNameValid = (payload) => 
        {
            if (payload == string.Empty) return false;

            foreach (char c in payload)
            {
                // Sprawdzenie, czy znak jest literą, cyfrą lub znakiem podkreślenia
                if (!char.IsLetterOrDigit(c) && c != '_')
                {
                    return false;
                }
            }
            return true;
        };

        static void saving_to_file(StreamWriter sw) 
        {
            //Colors
            sw.WriteLine(text_color.ToString());
            sw.WriteLine(logo_color.ToString());
            sw.WriteLine(error_color.ToString());
            sw.WriteLine(output_color.ToString());
            sw.WriteLine(prompt_color.ToString());
            sw.WriteLine(Console.BackgroundColor.ToString());

            //Prompt
            sw.WriteLine(input_chars);

            //Title
            sw.WriteLine(Console.Title);

            //From e-mail

            _ = new funkcje();
            sw.WriteLine(funkcje.from_email);

            //Message title and body

            sw.WriteLine(funkcje.e_mail[0]);

            string data = funkcje.e_mail[1];
            //data = data.Replace("\n", @"\n");
            //data = data.Replace("\r", string.Empty);

            sw.Write(data);
        }
        static void entering_from_file(string line) 
        {
            Console.Clear();

            string[] content = line.Split('\n');
            string[] funkcje_str = { "text", "logo", "error", "output", "prompt", "background" };

            for (int i = 0; i <= 5; i++) commands("change_color " + funkcje_str[i] + " " + content[i]);

            //Prompt
            input_chars = content[6];

            //Title
            Console.Title = " " + content[7];

            //From e-mail

            _ = new funkcje();
            funkcje.from_email = content[8];

            //Message title and body

            funkcje.e_mail[0] = content[9];

            funkcje.e_mail[1] = string.Empty;
            for (int i = 10; i < content.Length; i++) funkcje.e_mail[1] += (content[i] + "\n");

            Main();
        }

        [STAThread]
        public static void commands(string output)
        {
            funkcje f = new funkcje();

            if (output == string.Empty) Console.Write("");
            else if (output.Contains("change_prompt")) { input_chars = output.Replace("change_prompt ", string.Empty); if (input_chars == "change_prompt" || input_chars == string.Empty) { input_chars = "$~ "; } }
            else if (output.Contains("change_title")) { Console.Title = " " + output.Replace("change_title ", string.Empty); if (Console.Title == "change_title" || Console.Title == string.Empty) { Console.Title = " " + "p'Fisher"; } }

            else if (output == "clear") Console.Clear();
            else if (output == "exit") Environment.Exit(0);

            else if (output == "show_logo") logo();

            else if (output.Contains("help")) 
            {
                if (output == "help") f.help("");
                else f.help(output.Replace("help ", ""));
            }

            else if (output.Contains("payload"))
            {
                output = f.replace(output, "payload", "");
                //output.Replace("payload", "");

                if(!Directory.Exists("payloads")) Directory.CreateDirectory("payloads");

                if (output.Replace(" ", "") == String.Empty) { error("There is no option specified"); f.help("payload"); }
                else if (output.Contains("add"))
                {
                    //payload add C:\payload.exe
                    //payload remove payload2 [lub] payload

                    output = output.Replace("add", "");
                    output = output.Replace(" ", "");

                    string file_path = "", payload_name = "";
                    bool isPathSpecifed = false;

                    if (output == string.Empty)
                    {
                        using (OpenFileDialog rFile = new OpenFileDialog())
                        {
                            rFile.Filter = "Payload file (*.*)|*.*";
                            rFile.Title = "Read payload";

                            if (rFile.ShowDialog() == DialogResult.OK)
                            {
                                file_path = rFile.FileName;
                                isPathSpecifed = true;
                            }
                        }
                    }
                    else
                    {
                        file_path = output;

                        if (File.Exists(file_path)) { isPathSpecifed = true; }
                        else { error("File is not correct\r\n"); f.help("payload"); }
                    }

                    if (isPathSpecifed)
                    {
                        Console.WriteLine($"Ścieżka pliku: {file_path}");

                        //File.Copy(file_path, $"payloads\\{Path.GetFileName(file_path)}", true);

                        try
                        {
                            using (var sourceStream = new FileStream(file_path, FileMode.Open))
                            {
                                using (var destinationStream = new FileStream($"payloads\\{Path.GetFileName(file_path)}", FileMode.Create))
                                {
                                    byte[] buffer = new byte[1024 * 1024]; // 1MB buffer
                                    int bytesRead;
                                    long totalRead = 0;

                                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        destinationStream.Write(buffer, 0, bytesRead);
                                        totalRead += bytesRead;

                                        int percent = Convert.ToInt32((double)totalRead / sourceStream.Length * 100);

                                        Console.CursorVisible = false;
                                        f.drawTextProgressBar(percent, 100, "");
                                    }
                                }
                            }

                            Console.WriteLine(" | Payload added successfuly.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($" | \nError: {ex.Message}");
                            Main();
                        }

                        Console.CursorVisible = true;

                        Console.Write("Write payload name (only letters, digits and _ )\n>> ");

                        bool isValid = false;
                        while (!isValid)
                        {
                            payload_name = Console.ReadLine();

                            isValid = IsNameValid(payload_name);
                            if (!isValid) 
                            { 
                                error("Invalid payload name, try again");  
                                
                                Console.ForegroundColor = output_color;
                                Console.Write(">> ");
                                Console.ForegroundColor = text_color;
                            }
                        }

                        Console.WriteLine($"Payload name: {payload_name}");

                        Console.WriteLine($"Payload added successfuly");
                    }
                }
                else if (output.Contains("remove"))
                {
                    output = output.Replace(" ", "");

                    if (output == String.Empty) { error("There is no payload name specified"); f.help("payload"); }
                    else
                    {
                        output = output.Replace("remove", "");
                        output = output.Replace(" ", "");

                        if (output != String.Empty)
                        {
                            Console.WriteLine($"Removing payload: {output}");
                        }
                        else { error("There is no payload name specified"); f.help("payload"); }
                    }
                }
                else if (output.Contains("use"))
                {
                    Console.WriteLine("Use XXXXXXX");
                }
                else { error("Option is not correct"); f.help("payload"); }
            }

            else if (output.Contains("save_preset")) 
            {
                string file_path = "";

                bool isPathSpecifed = false;

                if (output.Contains(" => ") && output.Replace("save_preset => ", string.Empty) != string.Empty)
                {
                    output = output.Replace("save_preset => ", string.Empty);

                    file_path = output;
                    isPathSpecifed = true;
                }
                else if (output == "save_preset" || output == "save_preset ")
                {
                    using (SaveFileDialog sFile = new SaveFileDialog())
                    {
                        sFile.Filter = "Preset file (*.pfs)|*.pfs";
                        sFile.Title = "Save preset";

                        if (sFile.ShowDialog() == DialogResult.OK)
                        {
                            file_path = sFile.FileName;
                            isPathSpecifed = true;
                        }
                    }
                }
                else
                {
                    error("There is no path specified\r\n");
                    f.help("save_preset");
                }

                if (isPathSpecifed)
                {
                    if (!file_path.Contains(".pfs"))
                    {
                        error("File is not correct\r\n");
                        f.help("save_preset");
                    }
                    else
                    {
                        try
                        {
                            StreamWriter sw = new StreamWriter(file_path);

                            saving_to_file(sw);

                            sw.Close();
                        }
                        catch (Exception e)
                        {
                            error("Error: " + e.Message);
                        }
                    }
                }
            }

            else if (output.Contains("read_preset")) 
            {
                string file_path = "";

                bool isPathSpecifed = false;

                if (output.Contains(" => ") && output.Replace("read_preset => ", string.Empty) != string.Empty)
                {
                    output = output.Replace("read_preset => ", string.Empty);

                    file_path = output;
                    isPathSpecifed = true;
                }
                else if (output == "read_preset" || output == "read_preset ")
                {
                    using (OpenFileDialog rFile = new OpenFileDialog())
                    {
                        rFile.Filter = "Preset file (*.pfs)|*.pfs";
                        rFile.Title = "Read preset";

                        if (rFile.ShowDialog() == DialogResult.OK)
                        {
                            file_path = rFile.FileName;
                            isPathSpecifed = true;
                        }
                    }
                }
                else { error("There is no path specified\r\n"); f.help("save_preset"); }

                if (isPathSpecifed)
                {
                    if (!file_path.Contains(".pfs")) { error("File is not correct\r\n"); f.help("read_preset"); }
                    else
                    {
                        try
                        {
                            string content = "", line = "";

                            StreamReader sr = new StreamReader(file_path);

                            line = sr.ReadLine();
                            while (line != null)
                            {
                                content += (line + "\n");
                                line = sr.ReadLine();
                            }

                            sr.Close();

                            //content = content.Replace(@"\n", "\r\n");

                            entering_from_file(content);
                        }

                        catch (Exception e) { error("Error: " + e.Message); }
                    }
                }
            }

            else if (output.Contains("powershell"))  
            {
                if (output.Contains(" => ") && output.Replace("powershell =>", string.Empty).Replace(" ", string.Empty) != string.Empty)
                {
                    output = output.Replace("powershell =>", string.Empty);

                    var processStartInfo = new ProcessStartInfo("powershell.exe", output)
                    {
                        RedirectStandardOutput = true,
                        UseShellExecute = false
                    };

                    var process = new Process { StartInfo = processStartInfo };
                    process.Start();

                    Console.WriteLine(process.StandardOutput.ReadToEnd());
                }
                else { error("There is no command specified\r\n"); f.help("powershell"); }
            }

            else if (output.Contains("change_color")) 
            {
                output = output.Replace("change_color", string.Empty);

                if (output == string.Empty) { error("Too many or too few values were entered"); f.help("change_color"); }
                else
                {
                    string[] odpowiedzi = output.Split(' ');

                    if (odpowiedzi[1] == string.Empty || odpowiedzi[2] == string.Empty || odpowiedzi.Length != 3) { error("Too many or too few values were entered"); f.help("change_color"); }
                    else
                    {
                        ConsoleColor color = new ConsoleColor();

                        try { color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), odpowiedzi[2], true); }
                        catch (Exception) { error("Invalid color"); f.help("change_color"); }

                        switch (odpowiedzi[1])
                        {
                            case "background":
                                Console.BackgroundColor = color;
                                Console.Clear();
                                break;

                            case "logo":
                                logo_color = color;
                                break;

                            case "text":
                                text_color = color;
                                break;

                            case "output":
                                output_color = color;
                                break;

                            case "error":
                                error_color = color;
                                break;

                            case "prompt":
                                prompt_color = color;
                                break;
                        }
                    }
                }
            }

            else if (output.Contains("send") && (!output.Contains("sender")))
            {
                if (output.Replace(" ", "") == "send")
                {
                    string file_path = "";
                    bool isPathSpecifed = false;

                    using (OpenFileDialog rFile = new OpenFileDialog())
                    {
                        rFile.Filter = "Text file (*.txt)|*.txt|Dictionary file (*.dic)|*.dic";
                        rFile.Title = "Read preset";

                        if (rFile.ShowDialog() == DialogResult.OK)
                        {
                            file_path = rFile.FileName;
                            isPathSpecifed = true;
                        }
                    }

                    if (isPathSpecifed)
                    {
                        Console.WriteLine($"\nReading file from {file_path}\n");

                        StreamReader sr = new StreamReader(file_path);
                        string cont = "", line;

                        line = sr.ReadLine();

                        while (line != null)
                        {
                            cont += (line + "\n");
                            line = sr.ReadLine();
                        }

                        sr.Close();

                        string[] content = cont.Split('\n');

                        for (int i = 0; i < content.Length; i++) if (content[i] != string.Empty) f.send(content[i]);
                        Console.WriteLine();
                    }
                }
                else if (output.Contains(" => ") && output.Replace("send =>", string.Empty).Replace(" ", string.Empty) != string.Empty)
                {
                    output = output.Replace("send =>", string.Empty);
                    output = output.Replace(" ", string.Empty);

                    f.send(output);
                }
                else { error("There is no e-mail specified\r\n"); f.help("send"); }
            }

            else if (output.Contains("set"))
            {
                output = output.Replace("set", string.Empty);
                output = output.Replace(" ", string.Empty);

                if (output == string.Empty) { error("There is no option specified\r\n"); f.help("set"); }
                else f.set(output);
            }

            else if (output.Contains("get")) 
            {
                output = output.Replace("get", string.Empty);
                output = output.Replace(" ", string.Empty);

                if (output == string.Empty) { error("There is no variable specified\r\n"); f.help("get"); }
                else f.get(output);
            }

            else { error("Command is not correct\r\n\r\n"); f.help(""); }
        }
    }
}