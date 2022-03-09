
namespace Maze_Generator
{
    partial class Maze_Generator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maze_Generator));
            this.Generate_Maze = new System.Windows.Forms.Button();
            this.Debug = new System.Windows.Forms.Label();
            this.Grid_Slider = new System.Windows.Forms.TrackBar();
            this.Clear_Grid = new System.Windows.Forms.Button();
            this.Create_Grid = new System.Windows.Forms.Button();
            this.Solve_Maze = new System.Windows.Forms.Button();
            this.My_timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Slider)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Generate_Maze
            // 
            this.Generate_Maze.Enabled = false;
            this.Generate_Maze.Location = new System.Drawing.Point(921, 432);
            this.Generate_Maze.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Generate_Maze.Name = "Generate_Maze";
            this.Generate_Maze.Size = new System.Drawing.Size(205, 60);
            this.Generate_Maze.TabIndex = 1;
            this.Generate_Maze.Text = "Generate_Maze";
            this.Generate_Maze.UseVisualStyleBackColor = true;
            this.Generate_Maze.Click += new System.EventHandler(this.Generate_Maze_Click);
            // 
            // Debug
            // 
            this.Debug.AutoSize = true;
            this.Debug.Enabled = false;
            this.Debug.Location = new System.Drawing.Point(975, 70);
            this.Debug.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Debug.Name = "Debug";
            this.Debug.Size = new System.Drawing.Size(0, 17);
            this.Debug.TabIndex = 2;
            // 
            // Grid_Slider
            // 
            this.Grid_Slider.Location = new System.Drawing.Point(840, 143);
            this.Grid_Slider.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Grid_Slider.Maximum = 7;
            this.Grid_Slider.Name = "Grid_Slider";
            this.Grid_Slider.Size = new System.Drawing.Size(340, 56);
            this.Grid_Slider.TabIndex = 3;
            this.Grid_Slider.Scroll += new System.EventHandler(this.Grid_Slider_Scroll);
            // 
            // Clear_Grid
            // 
            this.Clear_Grid.Location = new System.Drawing.Point(921, 330);
            this.Clear_Grid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Clear_Grid.Name = "Clear_Grid";
            this.Clear_Grid.Size = new System.Drawing.Size(205, 79);
            this.Clear_Grid.TabIndex = 4;
            this.Clear_Grid.Text = "Clear_Grid";
            this.Clear_Grid.UseVisualStyleBackColor = true;
            this.Clear_Grid.Click += new System.EventHandler(this.Clear_Grid_Click);
            // 
            // Create_Grid
            // 
            this.Create_Grid.Location = new System.Drawing.Point(921, 239);
            this.Create_Grid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Create_Grid.Name = "Create_Grid";
            this.Create_Grid.Size = new System.Drawing.Size(205, 66);
            this.Create_Grid.TabIndex = 8;
            this.Create_Grid.Text = "Create_Grid";
            this.Create_Grid.UseVisualStyleBackColor = true;
            this.Create_Grid.Click += new System.EventHandler(this.Create_Grid_Click);
            // 
            // Solve_Maze
            // 
            this.Solve_Maze.Enabled = false;
            this.Solve_Maze.Location = new System.Drawing.Point(921, 516);
            this.Solve_Maze.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Solve_Maze.Name = "Solve_Maze";
            this.Solve_Maze.Size = new System.Drawing.Size(205, 80);
            this.Solve_Maze.TabIndex = 9;
            this.Solve_Maze.Text = "Solve_Maze";
            this.Solve_Maze.UseVisualStyleBackColor = true;
            this.Solve_Maze.Click += new System.EventHandler(this.Solve_Maze_Click);
            // 
            // My_timer
            // 
            this.My_timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 783);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1203, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutUsToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.aboutUsToolStripMenuItem.Text = "About Us";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // Maze_Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 811);
            this.Controls.Add(this.Solve_Maze);
            this.Controls.Add(this.Create_Grid);
            this.Controls.Add(this.Clear_Grid);
            this.Controls.Add(this.Grid_Slider);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.Generate_Maze);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1221, 858);
            this.MinimumSize = new System.Drawing.Size(1221, 858);
            this.Name = "Maze_Generator";
            this.Text = "Maze_Generator";
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Slider)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Generate_Maze;
        private System.Windows.Forms.Label Debug;
        private System.Windows.Forms.TrackBar Grid_Slider;
        private System.Windows.Forms.Button Clear_Grid;
        private System.Windows.Forms.Button Create_Grid;
        private System.Windows.Forms.Button Solve_Maze;
        private System.Windows.Forms.Timer My_timer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
    }
}

