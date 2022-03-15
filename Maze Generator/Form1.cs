using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Maze_Generator
{
    public partial class Maze_Generator : Form
    {
        static public int grid_size = 600;   // Frame size which is fix
        static public int cell_size = 60;    // Length of 1 box in the maze initially set at 60(min)
        static public int[] desired_values = new int[] { 10, 12, 15, 20, 24, 25, 30, 40 };
        static public Image[] cell_frames = new Image[16]; //stores all wall frames of cells
        static public Image[] vis_cell_frames = new Image[16]; //stores all vis wall frames of cells 
        static public int[] call_freq = new int[] { 90, 80, 70, 60, 40, 30, 20 , 10 };
        static public int start_point_i = 0;
        static public int start_point_j = 0;
        static bool can_highlight = true;
        static bool start_selected = false;
        static bool can_select_start = true;
        static public Tuple<int, int> extract_row_col(string ID)
        {
            int i = 5;
            string ii = "";
            while (ID[i] != ' ')
            {
                ii += ID[i];
                i++;
            }
            i += 3;

            string jj = "";

            while (i < ID.Length)
            {
                jj += ID[i];
                i++;
            }

            int iii = Int32.Parse(ii);
            int jjj = Int32.Parse(jj);
            Tuple<int, int> t = new Tuple<int, int>(iii, jjj);
            return t;
        }

        public class Cells
        {
            public bool Upper_Wall;
            public bool Right_Wall;
            public bool Down_Wall;
            public bool Left_Wall;
            public int frameindex = 0;
            public PictureBox cell_frame;
            public bool is_Starting = false;
            public Image highlighted = Maze.Properties.Resources.Highlighted_Cell;
            public Image starting = Maze.Properties.Resources.Start_Point;
            public Cells(int x, int y, int i, int j)
            {
                Upper_Wall = false;
                Right_Wall = false;
                Down_Wall = false;
                Left_Wall = false;
                cell_frame = new PictureBox();
                cell_frame.Width = cell_size;           // Set width of each box
                cell_frame.Height = cell_size;          // Set height of each box
                cell_frame.Location = new Point(x, y);  // Set Location of the box(upper left hand point
                cell_frame.Image = cell_frames[0];
                cell_frame.SizeMode = PictureBoxSizeMode.StretchImage;
                //cell_frame.Click += debug_Details;
                cell_frame.Click += green_highlight;
                cell_frame.MouseEnter += highlight;
                cell_frame.MouseLeave += back_to_normal;
                cell_frame.Name = "cell " + i + " , " + j;
            }

            public void update_cell_frame() //updates the image
            {
                if (cell_frame != null)
                    cell_frame.Image = cell_frames[frameindex];
            }

            public void turn_off_upper_wall()
            {
                if (Upper_Wall == true)
                {
                    frameindex -= 8;
                    Upper_Wall = false;
                    update_cell_frame();
                }
            }

            public void turn_on_upper_wall()
            {
                if (Upper_Wall == false)
                {
                    frameindex += 8;
                    Upper_Wall = true;
                    update_cell_frame();
                }
            }

            public void turn_off_Right_wall()
            {
                if (Right_Wall == true)
                {
                    frameindex -= 4;
                    Right_Wall = false;
                    update_cell_frame();
                }
            }

            public void turn_on_Right_wall()
            {
                if (Right_Wall == false)
                {
                    frameindex += 4;
                    Right_Wall = true;
                    update_cell_frame();
                }
            }

            public void turn_off_Down_wall()
            {
                if (Down_Wall == true)
                {
                    frameindex -= 2;
                    Down_Wall = false;
                    update_cell_frame();
                }
            }

            public void turn_on_Down_wall()
            {
                if (Down_Wall == false)
                {
                    frameindex += 2;
                    Down_Wall = true;
                    update_cell_frame();
                }
            }

            public void turn_off_Left_wall()
            {
                if (Left_Wall == true)
                {
                    frameindex -= 1;
                    Left_Wall = false;
                    update_cell_frame();
                }
            }

            public void turn_on_Left_wall()
            {
                if (Left_Wall == false)
                {
                    frameindex += 1;
                    Left_Wall = true;
                    update_cell_frame();
                }
            }

            public void highlight_this_cell()
            {
                cell_frame.Image = highlighted;
            }

            public void visit_this_cell() 
            {
                cell_frame.Image = vis_cell_frames[frameindex];
            }

            public void set_starting_cell()
            {
                cell_frame.Image = starting;
                is_Starting = !is_Starting;
            }
            public int get_cell_State()
            {
                return frameindex;
            }
        };


        static List<List<Cells>> current_cells = new List<List<Cells>>();

        static void debug_Details(object sender, EventArgs e)
        {
            string ID = ((PictureBox)sender).Name;
            Tuple<int, int> ij;
            ij = extract_row_col(ID);
            /*start_point_i = ij.Item1;
            start_point_j = ij.Item2;*/
            MessageBox.Show(ij.Item1 + " , " + ij.Item2 + " frame index = " + current_cells[ij.Item1][ij.Item2].frameindex);
        }

        static void green_highlight(object sender, EventArgs e)
        {
            if(can_select_start == true)
            {
                string ID = ((PictureBox)sender).Name;
                Tuple<int, int> ij;
                ij = extract_row_col(ID);
                current_cells[start_point_i][start_point_j].is_Starting = false;
                current_cells[start_point_i][start_point_j].update_cell_frame();
                start_point_i = ij.Item1;
                start_point_j = ij.Item2;
                MessageBox.Show("current start point = " + start_point_i + " " + start_point_j);
                current_cells[ij.Item1][ij.Item2].set_starting_cell();
            }
        }

        static void highlight(object sender, EventArgs e)
        {
            string ID = ((PictureBox)sender).Name;
            Tuple<int, int> ij;
            ij = extract_row_col(ID);
            //MessageBox.Show("current start point = " + start_point_i + " " + start_point_j + " Current starting = " + ij.Item1 + " " + ij.Item2);

            if (can_highlight == true && current_cells[ij.Item1][ij.Item2].is_Starting == false)
            {
                current_cells[ij.Item1][ij.Item2].highlight_this_cell();
            }
        }
        static void back_to_normal(object sender, EventArgs e) //removes the hilights
        {
            string ID = ((PictureBox)sender).Name;
            Tuple<int, int> ij;
            ij = extract_row_col(ID);

            if (can_highlight == true && current_cells[ij.Item1][ij.Item2].is_Starting == false)
                current_cells[ij.Item1][ij.Item2].update_cell_frame();
        }

        

        void Initialize_Cell_Frames() //
        {
            cell_frames[0] =  Maze.Properties.Resources.Frame_0;
            cell_frames[1] =  Maze.Properties.Resources.Frame_1;
            cell_frames[2] =  Maze.Properties.Resources.Frame_2;
            cell_frames[3] =  Maze.Properties.Resources.Frame_3;
            cell_frames[4] =  Maze.Properties.Resources.Frame_4;
            cell_frames[5] =  Maze.Properties.Resources.Frame_5;
            cell_frames[6] =  Maze.Properties.Resources.Frame_6;
            cell_frames[7] =  Maze.Properties.Resources.Frame_7;
            cell_frames[8] =  Maze.Properties.Resources.Frame_8;
            cell_frames[9] =  Maze.Properties.Resources.Frame_9;
            cell_frames[10] = Maze.Properties.Resources.Frame_10;
            cell_frames[11] = Maze.Properties.Resources.Frame_11;
            cell_frames[12] = Maze.Properties.Resources.Frame_12;
            cell_frames[13] = Maze.Properties.Resources.Frame_13;
            cell_frames[14] = Maze.Properties.Resources.Frame_14;
            cell_frames[15] = Maze.Properties.Resources.Frame_15;
            vis_cell_frames[0] = Maze.Properties.Resources.Vis_Frame_0;
            vis_cell_frames[1] = Maze.Properties.Resources.Vis_Frame_1;
            vis_cell_frames[2] = Maze.Properties.Resources.Vis_Frame_2;
            vis_cell_frames[3] = Maze.Properties.Resources.Vis_Frame_3;
            vis_cell_frames[4] = Maze.Properties.Resources.Vis_Frame_4;
            vis_cell_frames[5] = Maze.Properties.Resources.Vis_Frame_5;
            vis_cell_frames[6] = Maze.Properties.Resources.Vis_Frame_6;
            vis_cell_frames[7] = Maze.Properties.Resources.Vis_Frame_7;
            vis_cell_frames[8] = Maze.Properties.Resources.Vis_Frame_8;
            vis_cell_frames[9] = Maze.Properties.Resources.Vis_Frame_9;
            vis_cell_frames[10] = Maze.Properties.Resources.Vis_Frame_10;
            vis_cell_frames[11] = Maze.Properties.Resources.Vis_Frame_11;
            vis_cell_frames[12] = Maze.Properties.Resources.Vis_Frame_12;
            vis_cell_frames[13] = Maze.Properties.Resources.Vis_Frame_13;
            vis_cell_frames[14] = Maze.Properties.Resources.Vis_Frame_14;
            vis_cell_frames[15] = Maze.Properties.Resources.Vis_Frame_15;
        }

        public Maze_Generator()
        {
            try
            {
                InitializeComponent();
                Initialize_Cell_Frames();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
           
        }

        void Construct_Grid()
        {
            int size = desired_values[Grid_Slider.Value]; // size of grid to be constructed rows&cols
            /////////////////////CREATES EMPTY CELLS AND STORES IT INTO CURRENT CELLS////////////////// 

            for (int i = 0; i < size; i++)
            {
                List<Cells> row = new List<Cells>();
                for (int j = 0; j < size; j++)
                {
                    int x = (12 + j * (cell_size)); // gives the x coordinate of ith,jth cell 
                    int y = (12 + i * (cell_size)); // gives the y coordinate of ith,jth cell 
                    Cells C = new Cells(x, y, i, j);
                    Controls.Add(C.cell_frame);      // Adds this Cell to action 
                    C.cell_frame.BringToFront();
                    row.Add(C);
                }
                current_cells.Add(row);
            }
            //////////////////////////////////////////////////////////////////////////////////////////

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    current_cells[i][j].turn_on_upper_wall();
                    current_cells[i][j].turn_on_Right_wall();
                    current_cells[i][j].turn_on_Down_wall();
                    current_cells[i][j].turn_on_Left_wall();
                }
            }
        }

        void generate_maze()
        {
            int size = desired_values[Grid_Slider.Value];
            Stack<Tuple<int, int>> backtrack = new Stack<Tuple<int, int>>();
            bool[,] vis = new bool[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    vis[i, j] = false;
            }

            backtrack.Push(new Tuple<int, int>(start_point_i, start_point_j));
            vis[start_point_i, start_point_j] = true;
            Random random = new Random(DateTime.UtcNow.Millisecond);

            while (backtrack.Count != 0)
            {
                List<Tuple<int, int>> unvisited_neighbours = new List<Tuple<int, int>>();

                int i = backtrack.Peek().Item1;
                int j = backtrack.Peek().Item2;

                if (i - 1 >= 0 && vis[i - 1, j] == false) // up exist  && is unvis
                    unvisited_neighbours.Add(new Tuple<int, int>(i - 1, j));
                if (j - 1 >= 0 && vis[i, j - 1] == false) // left exists && is unvis
                    unvisited_neighbours.Add(new Tuple<int, int>(i, j - 1));
                if (i + 1 < size && vis[i + 1, j] == false)  // down exist && is unvis
                    unvisited_neighbours.Add(new Tuple<int, int>(i + 1, j));
                if (j + 1 < size && vis[i, j + 1] == false)  // right exist && is unvis
                    unvisited_neighbours.Add(new Tuple<int, int>(i, j + 1));

                if (unvisited_neighbours.Count == 0)
                    backtrack.Pop();
                else
                {
                    int index = random.Next(0, 1212) % unvisited_neighbours.Count;
                    int from_i = i;
                    int from_j = j;
                    int to_i = unvisited_neighbours[index].Item1;
                    int to_j = unvisited_neighbours[index].Item2;
                    backtrack.Push(new Tuple<int, int>(to_i, to_j));
                    vis[to_i, to_j] = true;
                    trace_wall(from_i, from_j, to_i, to_j);
                }
            }
        }

        private async void trace_wall(int from_i, int from_j, int to_i, int to_j)
        {
            await Task.Run(() => wait_func());
            if (from_i == to_i && from_j - 1 == to_j)
            {
                current_cells[from_i][from_j].turn_off_Left_wall();
                current_cells[to_i][to_j].turn_off_Right_wall();
            }
            else if (from_i == to_i && from_j + 1 == to_j)
            {
                current_cells[from_i][from_j].turn_off_Right_wall();
                current_cells[to_i][to_j].turn_off_Left_wall();
            }
            else if (from_j == to_j && from_i - 1 == to_i)
            {
                current_cells[from_i][from_j].turn_off_upper_wall();
                current_cells[to_i][to_j].turn_off_Down_wall();
            }
            else if (from_j == to_j && from_i + 1 == to_i)
            {
                current_cells[from_i][from_j].turn_off_Down_wall();
                current_cells[to_i][to_j].turn_off_upper_wall();
            }
        }
        private void wait_func()
        {
            Thread.Sleep(100);
        }

        void delete_prev()
        {
            for (int i = 0; i < current_cells.Count; i++)
            {
                for (int j = 0; j < current_cells[i].Count; j++)
                    Controls.Remove(current_cells[i][j].cell_frame);
            }
            current_cells.Clear();
        }

        private void Generate_Maze_Click(object sender, EventArgs e)
        {
            if (start_selected == true)
            {
                Generate_Maze.Enabled = false;
                Solve_Maze.Enabled = true;
                can_highlight = false;
                can_select_start = false;
                generate_maze();
            }
        }

        private void Grid_Slider_Scroll(object sender, EventArgs e)
        {
            Debug.Text = " size = " + desired_values[Grid_Slider.Value];
            Generate_Maze.Enabled = false;
            Clear_Grid.Enabled = false;
            Solve_Maze.Enabled = false;
        }

        private void Clear_Grid_Click(object sender, EventArgs e)
        {
            if (current_cells.Count == 0)
                MessageBox.Show("Grid already Cleared");
            else
            {
                Generate_Maze.Enabled = false;
                Solve_Maze.Enabled = false;
                delete_prev();
            }
        }

        void Reset_Bools()
        {
            can_select_start = true;
            My_timer.Enabled = false;
            can_highlight = true;
            start_selected = false;
        }

        private void Create_Grid_Click(object sender, EventArgs e)
        {
            Reset_Bools();
            Clear_Grid.Enabled = true;
            Generate_Maze.Enabled = true;
            start_point_i = 0;
            start_point_j = 0;
            start_selected = true;
            bool grid_Created;
            bool maze_generated;

            if ((desired_values[Grid_Slider.Value]) == current_cells.Count)
                grid_Created = true;
            else
                grid_Created = false;

            if (can_highlight == false)
                maze_generated = true;
            else
                maze_generated = false;

            if ((grid_Created == true && maze_generated == true) || (grid_Created == false && maze_generated == false) || (grid_Created == false && maze_generated == true))
            {
                can_highlight = true;
                delete_prev();
                cell_size = grid_size / (desired_values[Grid_Slider.Value]); // Calculate length of each box in maze
                Debug.Text = "grid size = " + cell_size;
                Construct_Grid();
                current_cells[0][0].set_starting_cell();
                MessageBox.Show("Select Start Point of Maze" + "\n" + "current startpoint is marked with green ");
            }
            else if (grid_Created == true && maze_generated == false)
                MessageBox.Show("Grid already Created");
        }

        private void Solve_Maze_Click(object sender, EventArgs e)
        {
            Create_Grid.Enabled = false;
            Clear_Grid.Enabled = false;
            can_select_start = false;
            My_timer.Interval = call_freq[Grid_Slider.Value];
            My_timer.Enabled = true;        
        }


        int size;
        Stack<Tuple<int, int>> path = new Stack<Tuple<int, int>>();
        bool[,] vis;

        private void timer_Tick(object sender, EventArgs e)
        {
            // MessageBox.Show("calling");
            if (Solve_Maze.Enabled == true)
            {
                size = desired_values[Grid_Slider.Value];
                vis = new bool[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        vis[i, j] = false;
                }
                path.Clear();

                path.Push(new Tuple<int, int>(start_point_i, start_point_j));
                vis[start_point_i, start_point_j] = true;
                current_cells[start_point_i][start_point_j].visit_this_cell();
                Solve_Maze.Enabled = false;
            }
            else
            {
                if (path.Count != 0)
                {
                    int i = path.Peek().Item1;
                    int j = path.Peek().Item2;
                    if (i == size - 1 && j == size - 1)
                    {
                        My_timer.Enabled = false;
                        Clear_Grid.Enabled = true;
                        Create_Grid.Enabled = true;
                    }
                    else
                    {
                        //MessageBox.Show("currently at = " + i + " " + j);

                        if (i - 1 >= 0 && vis[i - 1, j] == false && current_cells[i][j].Upper_Wall == false) // up exist  && is unvis && possible to go
                        {
                            //MessageBox.Show("going to = " + (i-1) + " " + j);
                            path.Push(new Tuple<int, int>(i - 1, j));
                            vis[i - 1, j] = true;
                            current_cells[i - 1][j].visit_this_cell();
                        }
                        else if (j - 1 >= 0 && vis[i, j - 1] == false && current_cells[i][j].Left_Wall == false) // left exists && is unvis && possible to go
                        {
                            //MessageBox.Show("going to = " + (i) + " " + (j-1));
                            path.Push(new Tuple<int, int>(i, j - 1));
                            vis[i, j - 1] = true;
                            current_cells[i][j - 1].visit_this_cell();
                        }
                        else if (i + 1 < size && vis[i + 1, j] == false && current_cells[i][j].Down_Wall == false)  // down exist && is unvis && possible to go
                        {
                            //MessageBox.Show("going to = " + (i+1) + " " + (j));
                            path.Push(new Tuple<int, int>(i + 1, j));
                            vis[i + 1, j] = true;
                            current_cells[i + 1][j].visit_this_cell();
                        }
                        else if (j + 1 < size && vis[i, j + 1] == false && current_cells[i][j].Right_Wall == false)  // right exist && is unvis && possible to go
                        {
                            //MessageBox.Show("going to = " + (i) + " " + (j+1));
                            path.Push(new Tuple<int, int>(i, j + 1));
                            vis[i, j + 1] = true;
                            current_cells[i][j + 1].visit_this_cell();
                        }
                        else
                        {
                            Tuple<int, int> tt = new Tuple<int, int>(path.Peek().Item1, path.Peek().Item2);
                            //MessageBox.Show("deleting" + tt.Item1 + " " + tt.Item2);
                            current_cells[tt.Item1][tt.Item2].update_cell_frame();
                            path.Pop();
                        }

                    }
                }
                else
                {
                    My_timer.Enabled = false;
                    Clear_Grid.Enabled = true;
                    Create_Grid.Enabled = true;
                }

            }
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_Us about_us = new About_Us();
            about_us.Show();
        }
    }
}
