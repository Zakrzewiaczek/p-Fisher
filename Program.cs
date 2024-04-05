#region Comment if you want to use p'Fisher, not installer
//#define installer
#endregion

#region Unblocking file command (cmd / powershell)
//gci -recurse (Get-Location) | Unblock-File
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace p_Fisher
{
    static internal class Program
    {
        #region variables

        public static string input_chars = "p'Fisher $~ ";

        public static ConsoleColor text_color = ConsoleColor.White;
        public static ConsoleColor logo_color = ConsoleColor.Cyan;
        public static ConsoleColor error_color = ConsoleColor.Red;
        public static ConsoleColor output_color = ConsoleColor.Yellow;
        public static ConsoleColor prompt_color = ConsoleColor.DarkGreen;

        public static bool isTitleChanged = false;

        public static List<string> payload = new List<string>();

        #endregion

        #region DllImports
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;

        #endregion
        
        #region Functions

        public static readonly Action<string> error = (content) =>
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
        static readonly Func<string, bool> isFileExist = (file_name) =>
        {
            string[] files = Directory.GetFiles("payloads", file_name + ".*");

            if (files.Length > 0) return true;
            else return false;
        };

        static void SavingToFile(StreamWriter sw)
        {
            Funkcje.DrawTextProgressBar(0, 100, "");

            #region Colors

            sw.WriteLine(text_color.ToString());
            sw.WriteLine(logo_color.ToString());
            sw.WriteLine(error_color.ToString());
            sw.WriteLine(output_color.ToString());
            sw.WriteLine(prompt_color.ToString());
            sw.WriteLine(Console.BackgroundColor.ToString());

            Funkcje.DrawTextProgressBar(15, 100, "");

            #endregion

            #region Prompt

            sw.WriteLine(input_chars);

            Funkcje.DrawTextProgressBar(25, 100, "");

            #endregion

            #region Title

            sw.WriteLine(Console.Title);

            Funkcje.DrawTextProgressBar(35, 100, "");

            #endregion

            #region From e-mail

            sw.WriteLine(Funkcje.from_email);

            Funkcje.DrawTextProgressBar(45, 100, "");

            #endregion

            #region Message title and body

            sw.WriteLine(Funkcje.e_mail[0]);

            Funkcje.DrawTextProgressBar(50, 100, "");



            string data = Funkcje.e_mail[1];
            //data = data.Replace("\n", @"\n");
            //data = data.Replace("\r", string.Empty);

            sw.WriteLine(data + "\n~~");

            Funkcje.DrawTextProgressBar(75, 100, "");

            #endregion

            #region Selected payloads

            foreach (string elem in payload)
            {
                sw.WriteLine(elem);
            }

            Funkcje.DrawTextProgressBar(100, 100, "");

            #endregion
        }
        static void EnteringToFile(string line)
        {
            Console.Clear();

            string[] content = line.Split('\n');
            string[] funkcje_str = { "text", "logo", "error", "output", "prompt", "background" };

            for (int i = 0; i <= 5; i++) {
                CommandsListChecking("change_color " + funkcje_str[i] + " " + content[i]);
            }

            //Prompt
            input_chars = content[6];

            //Title
            Console.Title = " " + content[7];

            //From e-mail
            Funkcje.from_email = content[8];

            //Message title and body

            Funkcje.e_mail[0] = content[9];

            Funkcje.e_mail[1] = string.Empty;
            for (int i = 10; i < content.Length; i++) Funkcje.e_mail[1] += (content[i] + "\n");

            Main();
        }

        #endregion


        [STAThread]
        static void Main()
        {
            #region p'Fisher installator function in Main()
            
            #if installer
                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_HIDE);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new installer());
            #endif

            #endregion
            #region p'Fisher program function in Main()

            #if !installer

            logo();

                if (!isTitleChanged)
                {
                    Console.Title = " p'Fisher";
                }
                if(!Directory.Exists("payloads")) 
                {
                    Directory.CreateDirectory("payloads");
                }

                //If user press Ctrl + C, the program will not be closed and starts Main() again
                //Console.CancelKeyPress += (s, e) => { Main(); };

                while (true)
                {
                    Console.CursorVisible = true;

                    isTitleChanged = true;

                    string odp = console_input();
                    Console.ForegroundColor = output_color;

                    CommandsListChecking(odp);

                    /*try 
                    { 
                        CommandsListChecking(odp); 
                    } 
                    catch (Exception ex) 
                    { 
                        error($"Error: {ex.Message}"); 
                    }*/
                }

#endif
            #endregion
        }

        [STAThread]
        public static void CommandsListChecking(string output)
        {
            if (output == string.Empty)
                Console.Write("");

            #region Checking commands

            else if (output.Contains("change_prompt"))
            {
                input_chars = output.Replace("change_prompt ", string.Empty);

                if (input_chars == "change_prompt" || input_chars == string.Empty)
                {
                    input_chars = "$~ ";
                }
            }
            else if (output.Contains("change_title"))
            {
                Console.Title = " " + output.Replace("change_title ", string.Empty);

                if (Console.Title == "change_title" || Console.Title == string.Empty)
                {
                    Console.Title = " " + "p'Fisher";
                }
            }
            else if (output.Contains("change_color"))
            {
                output = output.Replace("change_color", string.Empty);

                if (output == string.Empty)
                {
                    error("Too many or too few values were entered");
                    Funkcje.Help("change_color");
                }
                else
                {
                    string[] odpowiedzi = output.Split(' ');

                    if (odpowiedzi[1] == string.Empty || odpowiedzi[2] == string.Empty || odpowiedzi.Length != 3)
                    {
                        error("Too many or too few values were entered");
                        Funkcje.Help("change_color");
                    }
                    else
                    {
                        ConsoleColor color = new ConsoleColor();

                        try
                        {
                            //Conversing string to ConsoleColor
                            color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), odpowiedzi[2], true);
                        }
                        catch (Exception)
                        {
                            error("Invalid color");
                            Funkcje.Help("change_color");
                        }

                        #region Changing colors of elements

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

                        #endregion
                    }
                }
            }

            else if (output == "clear") 
                Console.Clear();

            else if (output == "exit") 
                Environment.Exit(0);

            else if (output == "show_logo") logo();

            else if (output.Contains("help"))
            {
                if (output == "help")
                {
                    Funkcje.Help("");
                }
                else
                {
                    Funkcje.Help(output.Replace("help ", ""));
                }
            }

            /*
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
                    //Reading file

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
                else 
                { 
                    error("There is no path specified\r\n"); 
                    Funkcje.Help("save_preset"); 
                }

                if (isPathSpecifed)
                {
                    if (!file_path.Contains(".pfs"))
                    {
                        error("File is not correct\nAllowed files is *.pfs\n");
                    }
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

                            EnteringToFile(content);
                        }

                        catch (Exception e) 
                        { 
                            error("Error: " + e.Message); 
                        }
                    }
                }
            }*/

            else if (output.Contains("preset"))
            {
                output = Funkcje.Replace(output, "preset", "").Trim();

                string[] args = output.Split(' ');
                
                string operation = args[0];

                List<string> list = new List<string>(args); //temporary List for remove 0 index elem.
                list.RemoveAt(0); // Deleting first item
                
                args = list.ToArray();

                if(operation == "save" || operation == "-s")
                {
                    string file_path = "";
                    bool isPathSpecifed = false;

                    //if path isn't given
                    if (args.Length == 0)
                    {
                        SaveFileDialog sFile = new SaveFileDialog()
                        {
                            Filter = "Preset file (*.pfs)|*.pfs",
                            Title = "Save preset"
                        };

                        if (sFile.ShowDialog() == DialogResult.OK)
                        {
                            file_path = sFile.FileName;
                            isPathSpecifed = true;
                        }
                    }

                    //if path is given
                    else if (args.Length == 1)
                    {
                        file_path = args[0];
                        isPathSpecifed = true;
                    }

                    else
                    {
                        error("Too many arguments\n");
                        Funkcje.Help("save_preset");
                    }

                    //If path is valid
                    if (isPathSpecifed)
                    {
                        if(File.Exists(file_path))
                        {
                            string odp = "";

                            while(odp.ToLower() != "y" && odp.ToLower() != "n" && odp != string.Empty)
                            {
                                Console.WriteLine($"File {Path.GetFileName(file_path)} is exist. Do you want to continue (Y/n)? (default is Y)  ");
                                odp = Console.ReadLine();
                            }

                            if(odp.ToLower() == "y")
                            {
                                File.Delete(file_path);
                                CommandsListChecking($"preset -s {file_path}");
                            }
                        }
                        else
                        {
                            string destination_path = Path.GetDirectoryName(file_path);

                            if (!file_path.Contains(".pfs"))
                            {
                                error("File is not correct\nAllowed files is *.pfs\n");
                            }
                            else if(!Directory.Exists(destination_path))
                            {
                                error("Directory is not exist\n");
                            }
                            else
                            {
                                try
                                {
                                    StreamWriter sw = new StreamWriter(file_path);

                                    Console.WriteLine();

                                    SavingToFile(sw);
                                    sw.Close();

                                    Console.WriteLine($"\n\nPreset saved successfuly in {file_path}\n");
                                }
                                catch (Exception e)
                                {
                                    error("Error: " + e.Message);
                                }
                            }
                        }
                    }
                }

                else if(operation == "read" || operation == "-r")
                {
                    string file_path = "";
                    bool isPathSpecifed = false;

                    //If path is not given
                    if (args.Length == 0)
                    {
                        //Reading file

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

                    //If path is given
                    else if(args.Length == 1)
                    {
                        file_path = args[0];
                        isPathSpecifed = true;
                    }

                    else
                    {
                        error("Too many arguments\n");
                        Funkcje.Help("read_preset");
                    }


                    if (isPathSpecifed)
                    {
                        if (!file_path.Contains(".pfs"))
                        {
                            error("File is not correct\nAllowed files is *.pfs\n");
                        }
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

                                EnteringToFile(content);
                            }

                            catch (Exception e)
                            {
                                error("Error: " + e.Message);
                            }
                        }
                    }
                }

                else
                {
                    error("An incorrect mode has been selected");
                    Funkcje.Help("preset");
                }
            }

            else if (output.Contains("powershell"))
            {
                if (output.Contains(" => ") && output.Replace("powershell =>", string.Empty).Replace(" ", string.Empty) != string.Empty)
                {
                    output = output.Replace("powershell =>", string.Empty);

                    //Starting powershell command
                    var processStartInfo = new ProcessStartInfo("powershell.exe", output)
                    {
                        RedirectStandardOutput = true,
                        UseShellExecute = false
                    };

                    var process = new Process { StartInfo = processStartInfo };
                    process.Start();

                    Console.WriteLine(process.StandardOutput.ReadToEnd());
                }
                else { error("There is no command specified\r\n"); Funkcje.Help("powershell"); }
            }

            else if (output.Contains("send") && (!output.Contains("sender")))
            {
                if (output.Replace(" ", "") == "send")
                {
                    string file_path = "";
                    bool isPathSpecifed = false;

                    //Opening file with e-mails list
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

                        for (int i = 0; i < content.Length; i++) if (content[i] != string.Empty) 
                        {
                            Funkcje.Send(content[i]);
                        }

                        Console.WriteLine();
                    }
                }
                else if (output.Contains(" => ") && output.Replace("send =>", string.Empty).Replace(" ", string.Empty) != string.Empty)
                {
                    output = output.Replace("send =>", string.Empty);
                    output = output.Replace(" ", string.Empty);

                    Funkcje.Send(output);
                }
                else { error("There is no e-mail specified\r\n"); Funkcje.Help("send"); }
            } 
            //dodać 1/X, 2/X, 3/X itd. przy send=>

            else if (output.Contains("payload"))
            {
                string file_path = "", payload_name = "";
                bool isPathSpecifed = false;

                output = Funkcje.Replace(output, "payload", "");

                if (output.Replace(" ", "") == string.Empty) 
                { 
                    error("There is no option specified"); 
                    Funkcje.Help("payload"); 
                }

                else if (output.Contains("add"))
                {
                    output = output.Replace("add", "").Trim();

                    if (output.Contains("=>"))
                    {
                        Match match = Regex.Match(output, "\"(.*?)\"");

                        if (match.Success)
                        {
                            file_path = match.Groups[1].Value;
                        }
                        else
                        {
                            file_path = output.Substring(0, output.IndexOf("=>"));
                        }

                        payload_name = output.Substring(output.IndexOf("=>") + 2).Trim();

                        isPathSpecifed = true;
                    }
                    else
                    {
                        if (output.Replace(" ", "") == string.Empty)
                        {
                            //Opening payload file
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
                            file_path = output.Replace("\"", "");

                            if (File.Exists(file_path)) isPathSpecifed = true;
                            else 
                            {
                                error("File is not exist\r\n");
                            }
                        }
                    }

                    if (isPathSpecifed)
                    {
                        Console.WriteLine($"Ścieżka pliku: {file_path}");

                        if (isFileExist(payload_name)) { error($"Payload called {payload_name} already exist"); payload_name = string.Empty; Console.ForegroundColor = output_color; }

                        if (payload_name == string.Empty)
                        {
                            Console.Write("Write payload name (only letters, digits and _ )\n>> ");

                            bool isValid = false;

                            while (!isValid)
                            {
                                Console.ForegroundColor = text_color;
                                payload_name = Console.ReadLine();
                                Console.ForegroundColor = output_color;
                                
                                //Checking if name is valid (if file doesn't exist and name has no '>', '|' e.t.c.)
                                isValid = IsNameValid(payload_name) && !isFileExist(payload_name);

                                if (!isValid)
                                {
                                    error(isFileExist(payload_name) ? $"Payload called {payload_name} already exist" : "Invalid payload name, try again");

                                    Console.ForegroundColor = output_color;
                                    Console.Write(">> ");
                                }
                            }
                        }

                        try
                        {
                            //Copying file to payloads folder

                            using (var sourceStream = new FileStream(file_path, FileMode.Open))
                            {
                                using (var destinationStream = new FileStream($"payloads\\{payload_name}{Path.GetExtension(file_path)}", FileMode.Create))
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
                                        Funkcje.DrawTextProgressBar(percent, 100, "");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($" | \nError: {ex.Message}");
                            Main();
                        }

                        Console.CursorVisible = true;
                        Console.WriteLine($"\nPayload added successfuly (name: {payload_name})");
                    }
                }
                else if (output.Contains("remove"))
                {
                    output = output.Replace("remove", "");
                    output = output.Replace(" ", "");

                    if (output == string.Empty)
                    {
                        //Wybieranie payload do usunięcia

                        string[] files = Directory.GetFiles("payloads", "*.*");

                        if (files.Length == 0) {
                            Console.WriteLine("There is no payload to delete");
                        }
                        else
                        {
                            Console.WriteLine("Select payload you want to delete: \n");

                            ////////////////////////////////////////////////

                            for (int i = 0; i < files.Length; i++) {
                                Console.WriteLine("  " + Path.GetFileNameWithoutExtension(files[i]));
                            }
                            Console.WriteLine();

                            int wybrane = 1, offset = Console.CursorTop - files.Length - 1;

                            Console.CursorVisible = false;
                            Funkcje.DrawMenuMarker(1, files.Length, offset, "*");

                            while (true)
                            {
                                if (Console.KeyAvailable)
                                {
                                    ConsoleKeyInfo key = Console.ReadKey(true);

                                    if (key.Key == ConsoleKey.Escape)
                                    {
                                        Console.CursorTop = offset + files.Length;
                                        Console.CursorLeft = 0;

                                        break;
                                    }

                                    else if (key.Key == ConsoleKey.UpArrow)
                                    {
                                        if (wybrane > 1) wybrane--;
                                    }
                                    else if (key.Key == ConsoleKey.DownArrow)
                                    {
                                        if (wybrane < files.Length) wybrane++;
                                    }
                                    else if (key.Key == ConsoleKey.Enter)
                                    {
                                        Console.CursorVisible = true;

                                        Console.CursorTop = offset + files.Length;
                                        Console.CursorLeft = 0;

                                        string wybrany_payload = files[wybrane - 1].Replace("payloads\\", " ");

                                        Console.WriteLine();
                                        CommandsListChecking($"payload remove {Path.GetFileNameWithoutExtension(wybrany_payload)}");

                                        break;
                                    }

                                    Funkcje.DrawMenuMarker(wybrane, files.Length, offset, "*");
                                }
                            }
                        }
                    }
                    else
                    {
                        if (output != string.Empty)
                        {
                            if (!isFileExist(output)) {
                                error($"Payload called {output} is not exist");
                            }
                            else
                            {
                                string mode;
                                Console.Write($"Are you sure you want to remove payload \"{output}\"? \n");

                                do
                                {
                                    Console.Write("[Y] Yes  [N] No  [?] Help (default is \"Y\"): ");

                                    Console.ForegroundColor = text_color;
                                    mode = Console.ReadLine().ToLower();
                                    Console.ForegroundColor = output_color;
                                }
                                while (mode != "y" && mode != "n" && mode != "?" && mode != string.Empty);

                                switch (mode)
                                {
                                    case "?":
                                        {
                                            Funkcje.Help("payload");
                                        }
                                        break;

                                    case "n": break;

                                    default:

                                        string[] files = Directory.GetFiles("payloads", output + ".*");
                                        foreach (var file in files) {
                                            File.Delete(file);
                                        }

                                        {
                                            Console.WriteLine($"Payload \"{output}\" removed successfuly\n");
                                        }
                                        break;
                                }
                            }
                        }
                        else { error("There is no payload name specified"); Funkcje.Help("payload"); }
                    }
                }
                else if (output.Contains("use"))
                {
                    int payload_count = Directory.GetFiles("payloads", "*.*").Length;

                    if (payload_count == 0) 
                    {
                        Console.WriteLine("\nPayload list is empty!\n");
                    }
                    else
                    {
                        output = Funkcje.Replace(output, "use", "");
                        payload.Clear();

                        if (output.Replace(" ", "") == string.Empty)
                        {
                            payload_count = Directory.GetFiles("payloads", "*.*").Length;

                            string[] files;

                            files = Directory.GetFiles("payloads", "*.*");
                            files[files.Length - 1] = "OK";

                            if (files.Length == 1) 
                                Console.WriteLine("There is no payload to delete");

                            else
                            {
                                bool isOKEnabled = false;

                                bool[] isChecked = new bool[files.Length - 1];
                                for (int i = 0; i < isChecked.Length; i++) isChecked[i] = false;

                                Console.WriteLine("Select payload you want to use: \n");
                                Console.WriteLine("   * Payloads\n");

                                ////////////////////////////////////////////////

                                #region Write all elements from files without "OK" (all payloads names)

                                foreach (string file in files)
                                {
                                    if(file != "OK") 
                                        Console.WriteLine("     " + Path.GetFileNameWithoutExtension(file));
                                }
                                Console.WriteLine("\n");

                                #endregion

                                int wybrane = 1, offset = Console.CursorTop - files.Length - 1;

                                Console.CursorVisible = false;
                                Funkcje.DrawMenuMarker(1, files.Length, offset, ">>");

                                while (true)
                                {
                                    bool isChanged = false;

                                    if (Console.KeyAvailable)
                                    {
                                        ConsoleKeyInfo key = Console.ReadKey(true);

                                        if (key.Key == ConsoleKey.Escape)
                                        {
                                            Console.CursorTop = offset + files.Length;
                                            Console.CursorLeft = 0;

                                            break;
                                        }    

                                        else if (key.Key == ConsoleKey.UpArrow)
                                        {
                                            if (wybrane > 1) { wybrane--; isChanged = true; }

                                            if (isOKEnabled)
                                            {
                                                if (wybrane == files.Length) { wybrane--; isChanged = true; }
                                            }
                                        }
                                        else if (key.Key == ConsoleKey.DownArrow)
                                        {
                                            if(isOKEnabled)
                                            {
                                                if (wybrane < files.Length) { wybrane++; isChanged = true; }
                                                if (wybrane == files.Length) { wybrane++; isChanged = true; }
                                            }
                                            else
                                            {
                                                if (wybrane < files.Length - 1) { wybrane++; isChanged = true; }
                                            }
                                        }
                                        else if (key.Key == ConsoleKey.Enter)
                                        {
                                            if (wybrane - 1 == files.Length)
                                            {
                                                //Select payloads only if at least one payload is selected
                                                if (isOKEnabled)
                                                {
                                                    Console.CursorLeft = 0;
                                                    Console.CursorTop = offset + files.Length - 1;

                                                    Console.WriteLine("\nSelected payloads: \n");

                                                    for (int i = 0; i < files.Length - 1; i++)
                                                    {
                                                        string name = Path.GetFileNameWithoutExtension(files[i]);

                                                        if (isChecked[i])
                                                        {
                                                            payload.Add(name);
                                                            Console.WriteLine($"*  {name}");
                                                        }
                                                    }

                                                    Console.WriteLine();

                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                isChecked[wybrane - 1] = !isChecked[wybrane - 1];

                                                Console.CursorTop = offset + wybrane - 1;
                                                Console.CursorLeft = 3;

                                                Console.Write(isChecked[wybrane - 1] ? "*" : " ");
                                            }

                                            #region changing isOKEnabled

                                            isOKEnabled = false;

                                            foreach (bool elem in isChecked)
                                            {
                                                if (elem) isOKEnabled = true;
                                            }

                                            #endregion

                                            #region Drawing / removing "OK" 

                                            //Drawing "OK"
                                            if (isOKEnabled)
                                            {
                                                Console.CursorLeft = 5;
                                                Console.CursorTop = offset + files.Length;

                                                Console.Write("OK");
                                            }

                                            //Removing "OK"
                                            else
                                            {
                                                Console.CursorLeft = 5;
                                                Console.CursorTop = offset + files.Length;

                                                Console.Write("  ");
                                            }

                                            #endregion
                                        }

                                        if (isChanged)
                                            Funkcje.DrawMenuMarker(wybrane, files.Length, offset, ">>");
                                    }
                                }
                            }
                        }
                        else
                        {
                            string[] payloads = output.Split(',');

                            if (payloads.Length > 1)
                            {
                                foreach (string elem in payloads)
                                {
                                    if (!isFileExist(elem.Trim()))
                                    {
                                        error($"Payload called \"{elem.Trim()}\" is not exist");
                                        Console.ForegroundColor = output_color;
                                    }
                                    else {
                                        payload.Add(elem.Trim());
                                    }
                                }

                                Console.WriteLine("Selected payloads: \n");
                                foreach (string elem in payload) {
                                    Console.WriteLine($"*  {elem}");
                                }
                                Console.WriteLine();
                            }
                            else if (isFileExist(output.Trim())) { payload.Add(output.Trim()); Console.WriteLine($"Selected payload: {output.Trim()}\n"); }
                            else {
                                error($"Payload called \"{output.Trim()}\" is not exist");
                            }
                        }
                    }
                }

                else if (output.Trim() == "list")
                {
                    string[] files = Directory.GetFiles("payloads", "*.*");

                    if(files.Length == 0)
                    {
                        Console.WriteLine("\nEmpty\n");
                    }
                    else
                    {
                        Console.WriteLine("Payloads: \n");

                        foreach (string file in files) {
                            Console.WriteLine("  " + Path.GetFileNameWithoutExtension(file));
                        }

                        Console.WriteLine();
                    }
                }
                else if (output.Trim() == "list selected")
                {
                    if (payload.Count == 0) Console.WriteLine("\nEmpty\n");
                    else
                    {
                        Console.WriteLine("Selected payloads: \n");

                        foreach (string elem in payload)
                        {
                            Console.WriteLine($"  * {elem}");
                        }

                        Console.WriteLine();
                    }
                }

                else { error("Option is not correct"); Funkcje.Help("payload"); }
            }

            else if (output.Contains("set"))
            {
                output = output.Replace("set", string.Empty);
                output = output.Replace(" ", string.Empty);

                if (output == string.Empty) 
                { 
                    error("There is no option specified\r\n"); 
                    Funkcje.Help("set"); 
                }
                else 
                {
                    Funkcje.Set(output);
                }
            }
            else if (output.Contains("get"))
            {
                output = output.Replace("get", string.Empty);
                output = output.Replace(" ", string.Empty);

                if (output == string.Empty) 
                {
                    error("There is no variable specified\r\n"); 
                    Funkcje.Help("get"); 
                }
                else 
                {
                    Funkcje.Get(output);
                }
            }

            #endregion

            else 
            { 
                error("Command is not correct\r\n\r\n"); 
                Funkcje.Help(""); 
            }
        }
    }
}