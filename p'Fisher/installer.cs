using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.IO.Compression;
using IWshRuntimeLibrary;
using System.Drawing;

namespace p_Fisher
{
    public partial class installer : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        private void change_install_enabled(object sender, EventArgs e) { install_cancel.Enabled = path_txtbox.Text != string.Empty; }
        private void browse(object sender, EventArgs e) { if (browseFolder.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(browseFolder.SelectedPath)) path_txtbox.Text = browseFolder.SelectedPath; }


        public static string error_content = "";


        public installer()
        {
            InitializeComponent();

            install_panel.Hide();
            open.Hide();
            installation_status_end.Hide();
            show_errors.Hide();
        }

        private void enable_close_button(bool bEnable)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);

            if (hMenu == IntPtr.Zero) return;

            if (bEnable) EnableMenuItem(hMenu, 0xF060, 0x00000000);
            else EnableMenuItem(hMenu, 0xF060, 0x00000001);
        }

        private static void making_shorcut(string installationPath, string targetPath)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(targetPath);

            // Ustaw właściwości skrótu
            shortcut.TargetPath = Path.Combine(installationPath, @"bin\Debug\p'Fisher.exe");
            shortcut.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            shortcut.Description = "It's very strong and dangerous tool";
            shortcut.IconLocation = Path.Combine(installationPath, @"logo.ico");

            shortcut.Save();
        }

        private void install(object sender, EventArgs e)
        {
            if (install_cancel.Text == "Finish")
            {
                if(open.Checked) System.Diagnostics.Process.Start(Path.Combine(path_txtbox.Text, @"bin\Debug\p'Fisher.exe"));
                Environment.Exit(0);
            }

            if (path_txtbox.Text == string.Empty)
            {
                System.Windows.Forms.MessageBox.Show("Installation path cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if(install_cancel.Text == "Cancel")
            {
                if (System.Windows.Forms.MessageBox.Show("Are your sure to cancel installation?", "Cancel installation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    finish(false); 
                    return;
                }
            }

            else if (!Directory.Exists(path_txtbox.Text))
            {
                System.Windows.Forms.MessageBox.Show("The specified directory does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            path_panel.Hide();
            checkbox_panel.Hide();
            install_panel.Show();

            install_cancel.Text = "Cancel";

            enable_close_button(false);

            try
            {
                string url = "https://codeload.github.com/Zakrzewiaczek/pFisher/zip/refs/heads/main";

                //////////////////////////////////////////////////////////////////
                /////////      Usuwanie plików z miejsca docelowego      /////////
                
                Directory.Delete(path_txtbox.Text, true);
                Directory.CreateDirectory(path_txtbox.Text);


                ////////////////////////////////////////////////////////////////////
                /////////      Pozbywanie się niepotrzebnych operacji      /////////
                


                if (!Directory.Exists(Path.Combine(Path.GetTempPath(), "pFisher-main")))
                {
                    if(!System.IO.File.Exists(Path.Combine(Path.GetTempPath(), "pFisher-main.zip")))
                    {
                        //////////////////////////////////////////////
                        /////////      Pobieranie pliku      /////////

                        status_lbl.Text = "Status: downloading pFisher-main.zip";

                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(url, Path.Combine(Path.GetTempPath(), "pFisher-main.zip"));
                        }

                        progressBar.Value = 30;
                    }
                    
                    //////////////////////////////////////////////////
                    /////////      Wypakowywanie plików      /////////

                    status_lbl.Text = "Status: unpacking pFisher-main.zip";
                    ZipFile.ExtractToDirectory(Path.Combine(Path.GetTempPath(), "pFisher-main.zip"), Path.GetTempPath());
                    progressBar.Value = 50;
                }



                ///////////////////////////////////////////////
                /////////      Kopiowanie plików      /////////

                status_lbl.Text = "Status: installing to target directory";
                CopyDirectory(Path.Combine(Path.GetTempPath(), @"pFisher-main\p'Fisher"), path_txtbox.Text, true);
                progressBar.Value = 80;

                /////////////////////////////////////////
                /////////      Czyszczenie      /////////

                status_lbl.Text = "Status: clearing after installation";

                Directory.Delete(Path.Combine(Path.GetTempPath(), "pFisher-main"), true);
                System.IO.File.Delete(Path.Combine(Path.GetTempPath(), "pFisher-main.zip"));

                progressBar.Value = 90;

                /////////////////////////////////////////////
                /////////      Dodatkowe opcje      /////////


                // Tworzenie skrótu na pulpicie (jeżeli zostało zaznaczone)
                if(shortcut_in_desktop.Checked)
                {
                    status_lbl.Text = "Status: making shortcut in Desktop";

                    string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "pFisher.lnk");

                    // Utwórz obiekt skrótu
                    making_shorcut(path_txtbox.Text, shortcutPath);
                }

                progressBar.Value = 95;

                //Dodawanie do Menu Start (jeżeli zostało zaznaczone)
                if(menu_start.Checked)
                {
                    status_lbl.Text = "Status: adding to Menu Start";

                    string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu), "pFisher.lnk");

                    // Utwórz obiekt skrótu
                    making_shorcut(path_txtbox.Text, shortcutPath);
                }

                progressBar.Value = 100;
            }
            catch (Exception ex)
            {
                finish(false, ex.Message);
                return;
            }

            finish(true);
        }

        private void finish(bool success, string errorContent = "")
        {
            enable_close_button(true);

            install_panel.Hide();

            if (success) open.Show();
            else
            {
                show_errors.Show();
                error_content = errorContent;
            }

            installation_status_end.Show();
            installation_status_end.Text = success ? "Installation completed successfully" : "Installation failed";

            install_cancel.Text = "Finish";
        }
        private void show_form_error_content(object sender, EventArgs e)
        {
            Form form2 = new Form
            {
                ShowInTaskbar = false,
                ShowIcon = false,
                
                Text = "Error content",

                MinimizeBox = false,
                MaximizeBox = false,

                FormBorderStyle = FormBorderStyle.FixedSingle,
                BackColor = Color.FromArgb(21, 21, 21),

                Size = new Size(270, 200),
                StartPosition = FormStartPosition.CenterParent
            };

            TextBox content_label = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Multiline = true,

                Location = new Point(10, 10),
                Size = new Size(240, 150),

                BackColor = Color.FromArgb(21, 21, 21),
                ForeColor = Color.FromArgb(255, 255, 255),

                Font = new Font("Microsoft YaHei;", 10),

                Text = $"Error content: \n {error_content}"
            };

            Button ok = new Button
            {
                Text = "OK",
                Font = new Font("Microsoft YaHei", 8),
                Size = new Size(70, 33),
                Location = new Point(160, 110),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(21, 21, 21),
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                FlatAppearance = { BorderSize = 2, BorderColor = Color.FromArgb(100, 100, 100),
                    MouseDownBackColor = Color.FromArgb(11, 11, 11), MouseOverBackColor = Color.FromArgb(11, 11, 11)}
            };

            ok.Click += (s, e2) => form2.Close();


            Button copy_clipboard = new Button
            {
                Text = "Copy to clipboard",
                Font = new Font("Microsoft YaHei", 8),
                Size = new Size(120, 33),
                Location = new Point(25, 110),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(21, 21, 21),
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleCenter,
                FlatAppearance = { BorderSize = 2, BorderColor = Color.FromArgb(100, 100, 100), 
                    MouseDownBackColor = Color.FromArgb(11, 11, 11), MouseOverBackColor = Color.FromArgb(11, 11, 11)}
            };

            copy_clipboard.Click += (s, e2) => Clipboard.SetText(error_content);

            form2.Controls.Add(ok);
            form2.Controls.Add(copy_clipboard);
            form2.Controls.Add(content_label);

            form2.ShowDialog();
        }

        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
    }
}
