using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

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

        static void Main()
        {
            Console.Title = "p'Fisher";
            logo();

            while (true)
            {
                string odp = console_input();
                Console.ForegroundColor = output_color;
                funkcje(odp);
            }
        }

        static readonly Action logo = () =>
        {
            //Console.WriteLine("\r\n\r\n    \r\n\r\n");
            Console.ForegroundColor = logo_color;
            Console.WriteLine("\r\n\r\n                                                                             \r\n               ]{  :@@@@@@@} [@@>  ^@@@@@{. -@@%. .@@@:~@@@@@@@<.@@@@@@~     \r\n                ~@>:@@@.     [@@>:@@@   #@@+-@@%. .@@@:~@@#.    .@@@.  {@@*  \r\n     :@<-#%@=:     :@@@---.  [@@>:%%@@}--:. -@@%---@@@:~@@#----:.@@@.  {@@*  \r\n     :@@@:^@@[     :@@@^^^:  [@@>  -^^)@@%(~-@@@^^^@@@:~@@%^^^^~.@@@(((%%^-  \r\n     :@@@:^@@[     :@@@.     [@@>:#<  .-#@@+-@@%. .@@@:~@@#.    .@@@---#@#+  \r\n     :@@@:^@@[     :@@@.     [@@>:@@@   #@@+-@@%. .@@@:~@@#.    .@@@.  {@@*  \r\n     :@@@@@@~      :@@@.     [@@>  ^@@@@@{. -@@%. .@@@:~@@@@@@@<.@@@.  {@@*  \r\n     :@@@:                                                                   \r\n     .***.                                                                   \r\n                                                   ..                        \r\n                                              ..:]=~<.                       \r\n                                            .*(~.^+..-                       \r\n                                         .=[~*..    .=                       \r\n                                       .[<.:>.      :.                       \r\n                                    .~#+=^~.       .+                        \r\n                                 ..=#~+.            ^.                       \r\n                                 =#+.].             :.                       \r\n                               :{( .<               .<.                      \r\n                             .)#:.<.                .<.                      \r\n                            -#)>-                   .:.                      \r\n                          .>%+.+.                    ..                      \r\n                         .[#: ~~                     .:                      \r\n                        .{#: -+                      .~                      \r\n                       .##..^:                       .^.                     \r\n                      .#%}>:.                        .{~                     \r\n                     .%#:>.                        .^=#*^:                   \r\n                    .#%:>*-.                        .^^^+                    \r\n                   .(%##(*){-                      +@@@@@#:                  \r\n                  .#%#.}~}+[.                     *%.+.==(@.                 \r\n                 .(%%}. .:).                     .@%=@-==(@^                 \r\n                .+%%#.     ..                     >@@@@@@@{:                 \r\n                :%%%=                                                        \r\n               .(%%[                                                         \r\n               *%%#.                                                         \r\n              :#%%*                                                          \r\n             .(%%]                                                           \r\n             *%%{.                                                           \r\n            .#%%+                                                            \r\n            +#%(.       \r\n\r\n");
        };

        static readonly Action<string> error = (content) =>
        {
            Console.ForegroundColor = error_color;
            Console.WriteLine(content);
            Console.ForegroundColor = text_color;
        };

        static string console_input()
        {
            Console.ForegroundColor = prompt_color;
            Console.Write(input_chars);
            Console.ForegroundColor = text_color;

            return Console.ReadLine();
        }

        static void funkcje(string output)
        {
            funkcje f = new funkcje();

            if (output == string.Empty) Console.Write("");
            else if (output.Contains("change_prompt")) input_chars = output.Replace("change_prompt ", string.Empty);
            else if (output.Contains("change_title")) Console.Title = output.Replace("change_title ", string.Empty);

            else if (output == "clear") Console.Clear();
            else if (output == "exit") Environment.Exit(0);

            else if (output.Contains("help"))
            {
                if (output == "help") f.help("");
                else f.help(output.Replace("help ", ""));
            }

            else if (output == "show_logo") logo();

            else if (output.Contains("powershell"))
            {
                if (output.Contains(" => ") && output.Replace("powershell =>", string.Empty).Replace(" ", string.Empty) != string.Empty)
                {
                    output = output.Replace("powershell =>", string.Empty);

                    var processStartInfo = new ProcessStartInfo("powershell.exe", output);
                    processStartInfo.RedirectStandardOutput = true;
                    processStartInfo.UseShellExecute = false;

                    var process = new Process();
                    process.StartInfo = processStartInfo;
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

            else if (output.Contains("send"))
            {
                if (output.Contains(" => ") && output.Replace("send =>", string.Empty).Replace(" ", string.Empty) != string.Empty)
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

            else { error("Command is not correct\r\n\r\n"); f.help("set"); }
        }
    }

    public class funkcje
    {
        public static string[] e_mail = { "", "" }; //title, body

        static readonly Action<string> error = (content) =>
        {
            Console.ForegroundColor = Program.error_color;
            Console.WriteLine(content);
            Console.ForegroundColor = Program.text_color;
        };

        public void help(string funct)
        {
            Console.ForegroundColor = Program.output_color;

            switch(funct)
            {
                case "change_color":
                    Console.WriteLine("\r\nSets console background and objects colors.\r\n\r\nchange_color [object] [Color]\r\n\r\n   object          Element whose color we change\r\n   Color           Specifies color of object\r\n\r\nList of objects that can be changed color:\r\n\r\n   background      Background color (once the color is set, the console is cleared)\r\n   logo            Splash logo color\r\n   text            Color of text written by the user\r\n   output          Console output text color\r\n   error           Errors color\r\n   prompt          Prompt color\r\n\r\nColors can only be normal and dark (e.g. blue and dark blue).\r\n\r\nFor example, command: \"change_color background green\" sets background color to green");
                    break;

                ///////////
                //Funkcje
                ///////////

                case "":
                    Console.WriteLine("\r\nFor more information on a specific command, type help [command-name]\r\n\r\nCommands:\r\n\r\n   change_color       Changes the colors of elements in the console\r\n   change_prompt      Changes the appearance of the prompt\r\n   change_title       Changes the console title\r\n   clear              Cleans the console\r\n   get                Displays the value of a variable\r\n   help               Displays help\r\n   powershell         Executes the powershell command\r\n   send               Sends a message with a virus to an e-mail address\r\n   set                Sets the value of the variable\r\n   show_logo          Show logo\r\n");
                    break;

                default:
                    error("The specified command was not found");
                    help("");
                    break;
            }
        }
        
        public static readonly string display_name = "pfisher";
        public static readonly string from_email = "pfisher@onet.eu";
        public static readonly string password = "JuanPablo2137";

        public void send(string email)
        {
            if (display_name == string.Empty || from_email == string.Empty || password == string.Empty) error("Email, password and display name of the user were not included in the variables!");
            else if (!email.Contains("@") || !email.Contains(".") || email == string.Empty) error("Invalid email adress");
            else
            {
                try
                {
                    SmtpClient client = new SmtpClient //("smtp-mai1.out100k.com");
                    {
                        Host = "smtp.poczta.onet.pl",
                        Port = 465,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(from_email, password, "smtp.poczta.onet.pl"),
                        EnableSsl = true
                    };

                    MailMessage message = new MailMessage(from_email, email);
                    message.Subject = "Test Mail";

                    message.Body = "Body\r\nBody2";
                    client.Send(message);

                    Console.WriteLine("Wyslano wiadomosc");
                }
                catch (Exception ex) 
                {
                    error(ex.ToString());
                }





                /*SmtpClient smtp = new SmtpClient()
                {
                    Host = "smtp-mail.outlook.com",
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,

                    Credentials = new NetworkCredential()
                    {
                        UserName = from_email, //////////
                        Password = password,
                    }
                };

                MailMessage message = new MailMessage()
                {
                    From = new MailAddress(from_email, display_name),
                    Subject = e_mail[0],
                    Body = e_mail[1]
                };
                message.To.Add(new MailAddress(email));

                //SmtpMail.SmtpServer=smtpServer;

                try 
                {
                    smtp.Send(message);
                    Console.WriteLine("The email has been successfully sent to the address " + email);
                }
                catch (Exception ex) 
                {
                    error("An error occurred while sending the email. Error: " + ex.ToString());
                }*/
            }
        }
        public void set(string argument)
        {
            switch(argument)
            {
                case "title":
                    Console.WriteLine("Write title of message (Enter saves message title): ");
                    Console.ForegroundColor = Program.text_color;
                    e_mail[0] = Console.ReadLine();
                    break;

                case "content":
                    e_mail[1] = "";
                    string wartosc;

                    Console.WriteLine("Write your message (if you want to save, write ~~ and press Enter): ");
                    Console.ForegroundColor = Program.text_color;

                    do
                    {
                        wartosc = Console.ReadLine();

                        if (wartosc.Contains(@"\~~"))
                        {
                            wartosc = wartosc.Replace(@"\~~", "~~");
                            e_mail[1] += (wartosc + Environment.NewLine);

                            wartosc = "";
                        }
                        else if (wartosc != "~~") e_mail[1] += (wartosc + Environment.NewLine);

                        if (wartosc.Contains("~~") && wartosc != "~~") break;
                    }
                    while (!wartosc.Contains("~~"));

                    break;
            }
        }

        public void get(string argument)
        {
            if(argument == "title") Console.WriteLine("Title: " + e_mail[0] + Environment.NewLine);
            else if(argument == "content") Console.WriteLine("Email content:" + Environment.NewLine + e_mail[1] + Environment.NewLine);
        }
    }
}
