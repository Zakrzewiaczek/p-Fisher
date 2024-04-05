using System;

namespace p_Fisher
{
    static internal class Funkcje
    {
        #region Email data

        public static string from_email = ""; //"qcwecdgfvsdd@o2.pl";
        public static string password = "";   //"JuanPablo2137";
        public static string smtp = "";       //"poczta.o2.pl";
        
        public static string[] e_mail = { "", "" }; //title, body

        #endregion

        public static void Send(string email)
        {
            if (from_email == string.Empty || !from_email.Contains("@") || !from_email.Contains("."))
            {
                Console.ForegroundColor = Program.output_color;
                Console.Write("Enter your correct email: ");

                Console.ForegroundColor = Program.text_color;
                from_email = Console.ReadLine();

                Send(email);
            }

            else if (password == string.Empty)
            {
                Console.ForegroundColor = Program.output_color;
                Console.Write("Enter your correct password: ");

                Console.ForegroundColor = Program.text_color;
                ConsoleKeyInfo key;

                do
                {
                    key = Console.ReadKey(true);

                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        password += key.KeyChar;
                        Console.Write("*");
                    }
                    else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Remove(password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                while (key.Key != ConsoleKey.Enter);

                Console.Write(Environment.NewLine);

                Send(email);
            }

            else if (smtp == string.Empty || !smtp.Contains("."))
            {
                Console.ForegroundColor = Program.output_color;
                Console.Write("Enter your correct SMTP server: ");

                Console.ForegroundColor = Program.text_color;
                smtp = Console.ReadLine();

                Send(email);
            }

            else if (!email.Contains("@") || !email.Contains(".") || email == string.Empty)
            {
                Program.error("Invalid email adress");
                email = "";

                Send(email);
            }

            else
            {
                Console.ForegroundColor = Program.output_color;

                Console.WriteLine($"SMTP {smtp} | {from_email} => {email}");

                #region Sending e-mail

                /*SmtpClient smtp_client = new SmtpClient()
                {
                    Host = smtp,
                    Port = 465,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential()
                    {
                        UserName = from_email,
                        Password = password,
                    }
                };
                MailMessage message = new MailMessage()
                {
                    From = new MailAddress(from_email, from_email.Replace("@o2.pl", "")),
                    Subject = e_mail[0],
                    Body = e_mail[1]
                };
                message.To.Add(new MailAddress(email));
                try
                {
                    smtp_client.Send(message);
                    Console.WriteLine("The email has been successfully sent to the address " + email);
                }
                catch (Exception ex)
                {
                    Program.error("An Program.error occurred while sending the email. Program.error: " + ex.ToString());
                }*/

                #endregion
            }
        }

        //save_preset i read_preset zostają (save_preset, read_preset, preset)
        public static void Help(string funct)
        {
            Console.ForegroundColor = Program.output_color;

            switch (funct)
            {
                case "change_color":
                    Console.WriteLine("\r\nSets console background and objects colors.\r\n\r\nchange_color [object] [Color]\r\n\r\n   object          Element whose color we change\r\n   Color           Specifies color of object\r\n\r\nList of objects that can be changed color:\r\n\r\n   background      Background color (once the color is set, the console is cleared)\r\n   logo            Splash logo color\r\n   text            Color of text written by the user\r\n   output          Console output text color\r\n   Program.error           Program.errors color\r\n   prompt          Prompt color\r\n\r\nColors can only be normal and dark (e.g. blue and dark blue).\r\n\r\nFor example, command: \"change_color background green\" sets background color to green");
                    break;

                ///////////
                //Funkcje
                ///////////

                case "":
                    Console.WriteLine("\r\nFor more information on a specific command, type help [command-name]\r\n\r\nCommands:\r\n\r\n   change_color       Changes the colors of elements in the console\r\n   change_prompt      Changes the appearance of the prompt\r\n   change_title       Changes the console title\r\n   clear              Cleans the console\r\n   get                Displays the value of a variable\r\n   help               Displays help\r\n   powershell         Executes the powershell command\r\n   send               Sends a message with a virus to an e-mail address\r\n   set                Sets the value of the variable\r\n   show_logo          Show logo\r\n");
                    break;

                default:
                    Program.error("The specified command was not found");
                    Help("");
                    break;
            }
        }

        public static void Set(string argument)
        {
            switch (argument)
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
        public static void Get(string argument)
        {
            if (argument == "title") Console.WriteLine("Title: " + e_mail[0] + Environment.NewLine);
            else if (argument == "content") Console.WriteLine("Email content:" + Environment.NewLine + e_mail[1] + Environment.NewLine);
            else if (argument == "sender") Console.WriteLine("Sender: " + from_email + Environment.NewLine);
        }

        public static string Replace(string value, string oldValue, string newValue)
        {
            int place = value.IndexOf(oldValue);

            if (place != -1) return value.Remove(place, oldValue.Length).Insert(place, newValue);

            return value;
        }

        public static void DrawTextProgressBar(int progress, int total, string process)
        {
            Console.CursorVisible = false;

            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = 32;
            Console.Write("]"); //end
            Console.CursorLeft = 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= 31; i++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorLeft = 35;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + "% of " + total.ToString() + "%" + process); //blanks at the end remove any excess
        }
        public static void DrawMenuMarker(int position, int lenght, int offset, string marker)
        {
            Console.CursorTop = offset;
            Console.CursorLeft = 0;

            for (int a = 0; a <= lenght; a++)
            {
                for (int b = 1; b <= marker.Length; b++) Console.Write(" ");

                Console.CursorTop++;
                Console.CursorLeft = 0;
            }

            Console.CursorTop = position + offset - 1;
            Console.CursorLeft = 0;

            Console.WriteLine(marker);
        }
    }
}
