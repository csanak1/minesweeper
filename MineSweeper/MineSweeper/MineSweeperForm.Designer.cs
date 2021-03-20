namespace MineSweeper
{
    partial class MineSweeperForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MineSweeperForm));
            this.tileGrid = new MineSweeper.MineSweeperForm.TileGrid();
            this.flagCounter_lbl = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.Game_menuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGame_menuStripOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NewGame_Beginner_menuStripOption = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGame_Intermediate_menuStripOption = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGame_Expert_menuStripOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Information_menuStripOption = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_menuStripOption = new System.Windows.Forms.ToolStripMenuItem();
            this.gameButton_btn = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameButton_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // tileGrid
            // 
            this.tileGrid.Location = new System.Drawing.Point(10, 50);
            this.tileGrid.Name = "tileGrid";
            this.tileGrid.Size = new System.Drawing.Size(260, 199);
            this.tileGrid.TabIndex = 0;
            // 
            // flagCounter_lbl
            // 
            this.flagCounter_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flagCounter_lbl.AutoSize = true;
            this.flagCounter_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flagCounter_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.flagCounter_lbl.Location = new System.Drawing.Point(221, 8);
            this.flagCounter_lbl.Name = "flagCounter_lbl";
            this.flagCounter_lbl.Size = new System.Drawing.Size(2, 33);
            this.flagCounter_lbl.TabIndex = 2;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Game_menuStrip});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(284, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // Game_menuStrip
            // 
            this.Game_menuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGame_menuStripOption,
            this.menuStripSeparator1,
            this.NewGame_Beginner_menuStripOption,
            this.NewGame_Intermediate_menuStripOption,
            this.NewGame_Expert_menuStripOption,
            this.menuStripSeparator2,
            this.Information_menuStripOption,
            this.Exit_menuStripOption});
            this.Game_menuStrip.Name = "Game_menuStrip";
            this.Game_menuStrip.Size = new System.Drawing.Size(45, 20);
            this.Game_menuStrip.Text = "Játék";
            // 
            // NewGame_menuStripOption
            // 
            this.NewGame_menuStripOption.Name = "NewGame_menuStripOption";
            this.NewGame_menuStripOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewGame_menuStripOption.Size = new System.Drawing.Size(180, 22);
            this.NewGame_menuStripOption.Text = "Új játék";
            this.NewGame_menuStripOption.Click += new System.EventHandler(this.NewGame_menuStripOption_Click);
            // 
            // menuStripSeparator1
            // 
            this.menuStripSeparator1.Name = "menuStripSeparator1";
            this.menuStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // NewGame_Beginner_menuStripOption
            // 
            this.NewGame_Beginner_menuStripOption.Name = "NewGame_Beginner_menuStripOption";
            this.NewGame_Beginner_menuStripOption.Size = new System.Drawing.Size(180, 22);
            this.NewGame_Beginner_menuStripOption.Tag = "Beginner";
            this.NewGame_Beginner_menuStripOption.Text = "Kezdő";
            this.NewGame_Beginner_menuStripOption.Click += new System.EventHandler(this.MenuStip_DifficultyChanged);
            // 
            // NewGame_Intermediate_menuStripOption
            // 
            this.NewGame_Intermediate_menuStripOption.Name = "NewGame_Intermediate_menuStripOption";
            this.NewGame_Intermediate_menuStripOption.Size = new System.Drawing.Size(180, 22);
            this.NewGame_Intermediate_menuStripOption.Tag = "Intermediate";
            this.NewGame_Intermediate_menuStripOption.Text = "Középhaladó";
            this.NewGame_Intermediate_menuStripOption.Click += new System.EventHandler(this.MenuStip_DifficultyChanged);
            // 
            // NewGame_Expert_menuStripOption
            // 
            this.NewGame_Expert_menuStripOption.Name = "NewGame_Expert_menuStripOption";
            this.NewGame_Expert_menuStripOption.Size = new System.Drawing.Size(180, 22);
            this.NewGame_Expert_menuStripOption.Tag = "Expert";
            this.NewGame_Expert_menuStripOption.Text = "Haladó";
            this.NewGame_Expert_menuStripOption.Click += new System.EventHandler(this.MenuStip_DifficultyChanged);
            // 
            // menuStripSeparator2
            // 
            this.menuStripSeparator2.Name = "menuStripSeparator2";
            this.menuStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // Exit_menuStripOption
            // 
            this.Exit_menuStripOption.Name = "Exit_menuStripOption";
            this.Exit_menuStripOption.Size = new System.Drawing.Size(180, 22);
            this.Exit_menuStripOption.Tag = "Exit";
            this.Exit_menuStripOption.Text = "Kilépés";
            this.Exit_menuStripOption.Click += new System.EventHandler(this.Exit_menuStripOption_Click);
            // 
            // gameButton_btn
            // 
            this.gameButton_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gameButton_btn.BackgroundImage = global::MineSweeper.Properties.Resources.game_button;
            this.gameButton_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gameButton_btn.Location = new System.Drawing.Point(125, 8);
            this.gameButton_btn.Name = "gameButton_btn";
            this.gameButton_btn.Size = new System.Drawing.Size(35, 35);
            this.gameButton_btn.TabIndex = 1;
            this.gameButton_btn.TabStop = false;
            this.gameButton_btn.Click += new System.EventHandler(this.LoadGame_Click);
            // 
            // MineSweeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.flagCounter_lbl);
            this.Controls.Add(this.gameButton_btn);
            this.Controls.Add(this.tileGrid);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MineSweeperForm";
            this.Text = "Aknakereső";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameButton_btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TileGrid tileGrid;

        private System.Windows.Forms.PictureBox gameButton_btn;
        private System.Windows.Forms.Label flagCounter_lbl;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem Game_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem NewGame_menuStripOption;
        private System.Windows.Forms.ToolStripSeparator menuStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem NewGame_Beginner_menuStripOption;
        private System.Windows.Forms.ToolStripMenuItem NewGame_Intermediate_menuStripOption;
        private System.Windows.Forms.ToolStripMenuItem NewGame_Expert_menuStripOption;
        private System.Windows.Forms.ToolStripSeparator menuStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Information_menuStripOption;
        private System.Windows.Forms.ToolStripMenuItem Exit_menuStripOption;
    }
}

