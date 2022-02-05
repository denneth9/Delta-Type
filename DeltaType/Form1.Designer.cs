namespace DeltaType
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCharacterDefenitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.bootMeUp1 = new WK.Libraries.BootMeUpNS.BootMeUp(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Text";
            this.notifyIcon1.BalloonTipTitle = "Title";
            this.notifyIcon1.Text = "Delta Type";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFromStartupToolStripMenuItem,
            this.editCharacterDefenitionsToolStripMenuItem});
            this.settingsToolStripMenuItem.Image = global::DeltaType.Properties.Resources.gear;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // removeFromStartupToolStripMenuItem
            // 
            this.removeFromStartupToolStripMenuItem.Name = "removeFromStartupToolStripMenuItem";
            this.removeFromStartupToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.removeFromStartupToolStripMenuItem.Text = "Remove From Startup";
            this.removeFromStartupToolStripMenuItem.Click += new System.EventHandler(this.removeFromStartupToolStripMenuItem_Click);
            // 
            // editCharacterDefenitionsToolStripMenuItem
            // 
            this.editCharacterDefenitionsToolStripMenuItem.Name = "editCharacterDefenitionsToolStripMenuItem";
            this.editCharacterDefenitionsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.editCharacterDefenitionsToolStripMenuItem.Text = "Edit Character Defenitions";
            this.editCharacterDefenitionsToolStripMenuItem.Click += new System.EventHandler(this.editCharacterDefenitionsToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click_1);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Version 1.1.2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "IGNORE ME";
            // 
            // bootMeUp1
            // 
            this.bootMeUp1.BootArea = WK.Libraries.BootMeUpNS.BootMeUp.BootAreas.Registry;
            this.bootMeUp1.ContainerControl = this;
            this.bootMeUp1.Enabled = false;
            this.bootMeUp1.Exception = ((System.Exception)(resources.GetObject("bootMeUp1.Exception")));
            this.bootMeUp1.Parameters = "silent";
            this.bootMeUp1.ParentForm = this;
            this.bootMeUp1.RunWhenDebugging = false;
            this.bootMeUp1.Tag = null;
            this.bootMeUp1.TargetUser = WK.Libraries.BootMeUpNS.BootMeUp.TargetUsers.CurrentUser;
            this.bootMeUp1.UseAlternativeOnFail = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 62);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Delta-Type";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolTip toolTip1;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem removeFromStartupToolStripMenuItem;
        private Label label1;
        private WK.Libraries.BootMeUpNS.BootMeUp bootMeUp1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem editCharacterDefenitionsToolStripMenuItem;
    }
}