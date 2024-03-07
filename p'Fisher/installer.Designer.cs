namespace p_Fisher
{
    partial class installer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(installer));
            this.label_pFisher = new System.Windows.Forms.PictureBox();
            this.logo = new System.Windows.Forms.Label();
            this.path_txtbox = new System.Windows.Forms.TextBox();
            this.path_lbl = new System.Windows.Forms.Label();
            this.browse_path = new System.Windows.Forms.Button();
            this.textbox_white_bg = new System.Windows.Forms.PictureBox();
            this.browseFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.install_cancel = new System.Windows.Forms.Button();
            this.path_panel = new System.Windows.Forms.Panel();
            this.checkbox_panel = new System.Windows.Forms.Panel();
            this.shortcut_in_desktop = new System.Windows.Forms.CheckBox();
            this.menu_start = new System.Windows.Forms.CheckBox();
            this.install_panel = new System.Windows.Forms.Panel();
            this.status_lbl = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.installation_status_end = new System.Windows.Forms.Label();
            this.open = new System.Windows.Forms.CheckBox();
            this.show_errors = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.label_pFisher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_white_bg)).BeginInit();
            this.path_panel.SuspendLayout();
            this.checkbox_panel.SuspendLayout();
            this.install_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_pFisher
            // 
            this.label_pFisher.BackgroundImage = global::p_Fisher.Properties.Resources.label;
            this.label_pFisher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.label_pFisher.Location = new System.Drawing.Point(23, 42);
            this.label_pFisher.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label_pFisher.Name = "label_pFisher";
            this.label_pFisher.Size = new System.Drawing.Size(564, 218);
            this.label_pFisher.TabIndex = 0;
            this.label_pFisher.TabStop = false;
            // 
            // logo
            // 
            this.logo.AutoSize = true;
            this.logo.Font = new System.Drawing.Font("Lucida Sans Typewriter", 4.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logo.Location = new System.Drawing.Point(575, 42);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(312, 210);
            this.logo.TabIndex = 1;
            this.logo.Text = resources.GetString("logo.Text");
            // 
            // path_txtbox
            // 
            this.path_txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.path_txtbox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.path_txtbox.Location = new System.Drawing.Point(157, 14);
            this.path_txtbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.path_txtbox.Name = "path_txtbox";
            this.path_txtbox.Size = new System.Drawing.Size(483, 20);
            this.path_txtbox.TabIndex = 2;
            this.path_txtbox.Text = "C:\\Users\\jakub.zakrzewski\\Desktop\\Nowy folder";
            this.path_txtbox.TextChanged += new System.EventHandler(this.change_install_enabled);
            // 
            // path_lbl
            // 
            this.path_lbl.AutoSize = true;
            this.path_lbl.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.path_lbl.Location = new System.Drawing.Point(8, 12);
            this.path_lbl.Name = "path_lbl";
            this.path_lbl.Size = new System.Drawing.Size(125, 20);
            this.path_lbl.TabIndex = 3;
            this.path_lbl.Text = "Installation path";
            // 
            // browse_path
            // 
            this.browse_path.AutoSize = true;
            this.browse_path.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.browse_path.FlatAppearance.BorderSize = 2;
            this.browse_path.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.browse_path.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.browse_path.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browse_path.Location = new System.Drawing.Point(669, 6);
            this.browse_path.Name = "browse_path";
            this.browse_path.Size = new System.Drawing.Size(119, 33);
            this.browse_path.TabIndex = 4;
            this.browse_path.Text = "Browse";
            this.browse_path.UseVisualStyleBackColor = true;
            this.browse_path.Click += new System.EventHandler(this.browse);
            // 
            // textbox_white_bg
            // 
            this.textbox_white_bg.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_white_bg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textbox_white_bg.Location = new System.Drawing.Point(148, 6);
            this.textbox_white_bg.Name = "textbox_white_bg";
            this.textbox_white_bg.Size = new System.Drawing.Size(500, 33);
            this.textbox_white_bg.TabIndex = 5;
            this.textbox_white_bg.TabStop = false;
            // 
            // install_cancel
            // 
            this.install_cancel.AutoSize = true;
            this.install_cancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.install_cancel.FlatAppearance.BorderSize = 2;
            this.install_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.install_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.install_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.install_cancel.Location = new System.Drawing.Point(703, 434);
            this.install_cancel.Name = "install_cancel";
            this.install_cancel.Size = new System.Drawing.Size(119, 33);
            this.install_cancel.TabIndex = 6;
            this.install_cancel.Text = "Install";
            this.install_cancel.UseVisualStyleBackColor = true;
            this.install_cancel.Click += new System.EventHandler(this.install);
            // 
            // path_panel
            // 
            this.path_panel.Controls.Add(this.path_txtbox);
            this.path_panel.Controls.Add(this.path_lbl);
            this.path_panel.Controls.Add(this.browse_path);
            this.path_panel.Controls.Add(this.textbox_white_bg);
            this.path_panel.Location = new System.Drawing.Point(34, 292);
            this.path_panel.Name = "path_panel";
            this.path_panel.Size = new System.Drawing.Size(800, 44);
            this.path_panel.TabIndex = 7;
            // 
            // checkbox_panel
            // 
            this.checkbox_panel.Controls.Add(this.shortcut_in_desktop);
            this.checkbox_panel.Controls.Add(this.menu_start);
            this.checkbox_panel.Location = new System.Drawing.Point(34, 376);
            this.checkbox_panel.Name = "checkbox_panel";
            this.checkbox_panel.Size = new System.Drawing.Size(260, 100);
            this.checkbox_panel.TabIndex = 8;
            // 
            // shortcut_in_desktop
            // 
            this.shortcut_in_desktop.AutoSize = true;
            this.shortcut_in_desktop.Location = new System.Drawing.Point(12, 24);
            this.shortcut_in_desktop.Name = "shortcut_in_desktop";
            this.shortcut_in_desktop.Size = new System.Drawing.Size(195, 23);
            this.shortcut_in_desktop.TabIndex = 1;
            this.shortcut_in_desktop.Text = "Create shortcut in desktop";
            this.shortcut_in_desktop.UseVisualStyleBackColor = true;
            // 
            // menu_start
            // 
            this.menu_start.AutoSize = true;
            this.menu_start.Location = new System.Drawing.Point(12, 53);
            this.menu_start.Name = "menu_start";
            this.menu_start.Size = new System.Drawing.Size(144, 23);
            this.menu_start.TabIndex = 0;
            this.menu_start.Text = "Add to menu start";
            this.menu_start.UseVisualStyleBackColor = true;
            // 
            // install_panel
            // 
            this.install_panel.Controls.Add(this.status_lbl);
            this.install_panel.Controls.Add(this.progressBar);
            this.install_panel.Location = new System.Drawing.Point(37, 278);
            this.install_panel.Name = "install_panel";
            this.install_panel.Size = new System.Drawing.Size(799, 108);
            this.install_panel.TabIndex = 9;
            // 
            // status_lbl
            // 
            this.status_lbl.AutoSize = true;
            this.status_lbl.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.status_lbl.Location = new System.Drawing.Point(-1, 80);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(263, 23);
            this.status_lbl.TabIndex = 11;
            this.status_lbl.Text = "Status: downloading index.json";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.progressBar.Location = new System.Drawing.Point(3, 24);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(776, 39);
            this.progressBar.TabIndex = 10;
            // 
            // installation_status_end
            // 
            this.installation_status_end.AutoSize = true;
            this.installation_status_end.Font = new System.Drawing.Font("Microsoft YaHei", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.installation_status_end.Location = new System.Drawing.Point(31, 306);
            this.installation_status_end.Name = "installation_status_end";
            this.installation_status_end.Size = new System.Drawing.Size(813, 60);
            this.installation_status_end.TabIndex = 10;
            this.installation_status_end.Text = "Installation completed successfully";
            // 
            // open
            // 
            this.open.AutoSize = true;
            this.open.Checked = true;
            this.open.CheckState = System.Windows.Forms.CheckState.Checked;
            this.open.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.open.Location = new System.Drawing.Point(553, 440);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(132, 24);
            this.open.TabIndex = 10;
            this.open.Text = "Open p\'Fisher";
            this.open.UseVisualStyleBackColor = true;
            // 
            // show_errors
            // 
            this.show_errors.AutoSize = true;
            this.show_errors.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.show_errors.FlatAppearance.BorderSize = 2;
            this.show_errors.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.show_errors.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.show_errors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_errors.Location = new System.Drawing.Point(577, 434);
            this.show_errors.Name = "show_errors";
            this.show_errors.Size = new System.Drawing.Size(119, 33);
            this.show_errors.TabIndex = 11;
            this.show_errors.Text = "Show error";
            this.show_errors.UseVisualStyleBackColor = true;
            this.show_errors.Click += new System.EventHandler(this.show_form_error_content);
            // 
            // installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(869, 511);
            this.Controls.Add(this.show_errors);
            this.Controls.Add(this.installation_status_end);
            this.Controls.Add(this.open);
            this.Controls.Add(this.install_cancel);
            this.Controls.Add(this.install_panel);
            this.Controls.Add(this.checkbox_panel);
            this.Controls.Add(this.path_panel);
            this.Controls.Add(this.label_pFisher);
            this.Controls.Add(this.logo);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "installer";
            this.Text = "p\'Fisher installer";
            ((System.ComponentModel.ISupportInitialize)(this.label_pFisher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_white_bg)).EndInit();
            this.path_panel.ResumeLayout(false);
            this.path_panel.PerformLayout();
            this.checkbox_panel.ResumeLayout(false);
            this.checkbox_panel.PerformLayout();
            this.install_panel.ResumeLayout(false);
            this.install_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox label_pFisher;
        private System.Windows.Forms.Label logo;
        private System.Windows.Forms.TextBox path_txtbox;
        private System.Windows.Forms.Label path_lbl;
        private System.Windows.Forms.Button browse_path;
        private System.Windows.Forms.PictureBox textbox_white_bg;
        private System.Windows.Forms.FolderBrowserDialog browseFolder;
        private System.Windows.Forms.Button install_cancel;
        private System.Windows.Forms.Panel path_panel;
        private System.Windows.Forms.Panel checkbox_panel;
        private System.Windows.Forms.CheckBox shortcut_in_desktop;
        private System.Windows.Forms.CheckBox menu_start;
        private System.Windows.Forms.Panel install_panel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label status_lbl;
        private System.Windows.Forms.Label installation_status_end;
        private System.Windows.Forms.CheckBox open;
        private System.Windows.Forms.Button show_errors;
    }
}