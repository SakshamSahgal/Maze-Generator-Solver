# Maze-Generator-Solver
Generates random solvable mazes and solves them in realtime.


MAZE GENERATION PROJECT

Designed and Developed by: Saksham Sahgal and Bhavya Wig

Project Overview:

> This project is built on Visual studio [Winforms] using C: language.

>It generates random solvable mazes and solves them in realtime.

>User can select the size of the maze and a starting point for the maze generation to begin , the end point is the bottom right cell.

>We use the concept of Depth First Algorithm (DFS) to both generate and solve mazes.


Here is a brief description of the code for better understanding.

How Do We Generate Mazes ?

Pseudo Code :

>select starting point
>mark starting point visited
>push starting point in a stack of pairs
while(stack is not empty)
{
	>select top coordinates of stack as current cell
	if( any unvisited neighbour of current cell is available )
	{
		>randomly choose an unvisited available neighbour of current cell
		>push that neighbour into the stack of pair
		>mark it as visited
		>open its way via Async function
	}
	else
		pop current cell from the stack
}
HOW DO We Solve Mazes?

Pseudo Code :

> Add the start pointcoordinates into the stack ofpairs . mark it as visited and color this cell
whi|e(stack is notempty)
{
	> selectthe topmostcoordinates ofthe stack as currentcell
	lf(current cell is bottom right cell)	
		Maze solved:
	else
	{
		if(any neighbor ofthis cell exists where path is possible and neighbor is unvisited)
		{
		> add that neighbour into the stack
		> Color that neighbor cell
		> mark that cell as visited
		}
		else
		{
		>pop this cell from the stack
		>decolorize this cell
		}
	}
}

We initialize grid_size which is the frame in which maze will be formed. Cell_size will indicate the length of each box in maze when grid will be created. Desired_values is the values which the slider can take and create respective grid. Cell_frames is an image array of size 16 which stores all possibilities of walls in a cell. Vis_cell_frames stores all possibilities same as cell_frames but will be used to solve the maze while cell_frames to generate maze. Call_freq stores the time period of timer, it depicts that the smaller mazes will be solved slower that the large mazes. Start_point_i and start_point_j indicates the start point coordinates of i,j. can_highlight which is initially true indicates whether to highlight cells in the grid when cursor passes by. Start_selected indicates whether a start point in the grid is chosen or not. All these variables are global and hence can be accessed anywhere in the code.
There is a function called extract_row_col, the sole purpose is to extract two numbers iii and jjj which are the respective row and column of each cell from its string id. These are then stored in a tuple named ‘t’.
We created a class called Cells which stores various properties of a cell. We initialize four Boolean integers namely Upper_Wall, Right_Wall, Down_Wall, Left_Wall. An integer frameindex which sets different frames to cell. We also store a highlighted image in highlighted image. A constructor named cells is created which sets all four Boolean of walls to false, which means all the walls are not present. It also creates a new picturebox in each cell frame and sets its width, height, location, image. Sets when mouse enters and leaves a cell. There is a function update_cell_frame which sets image to a cell if its not null. There are 8 functions named like turn_off_upper_wall, turn_on_upper_wall, turn_off_down_wall and so on. It updates respective Booleans to true and false respectively and updates frameindex and calls update_cell_frame function. Highlight function adds the highlighted (green) image on the respective cell. Get_cell_state returns frameindex. 
Green_highlight is a function which extracts the current cell from the tuple values ‘t’ we stored initially, at which is mouse is pointing and updates the cell picture.  
Beck_to_normal function removes the green highlight on the cell by checking if can_highlight is true and this cell has a is_starting as false.
Initialize_Cell_Frames : it sets all indexes of cell_frames to their respective pictures.(It stores all permutations of walls on and off). 
Construct_Grid : it creates empty cells and stores it into current cells and also adds them to front and the picturebox at the end. It also makes all walls on and hence the grid is formed.
generate_maze : when we call this function sound starts to play with formation of a valid maze. We here make a Boolean array vis to make sure all cells are visited. Hence, the vis array is initially false, except the starting point. Initially, the first cell indexes are added to the queue. We run a while loop till the stack is empty. It selects the top most element and checks if there is a unvisited neighbour. If it finds such a neighbour it pushes that neighbour into stack of pair and marks the vis array true. Async function is called thereafter. If no neighbour is found it pops the uppermost element of the stack. This is basically implementation of Depth First Search (DFS). 
trace_wall : this function makes sure that a possible maze is created. It checks if the ith cell has left wall on then the i-1th cell right wall should also be on and so on for all the respective overlapping walls.
Delete_prev is a function we call when we click Clear grid as it clears the grid and sets all cells to blank and we are able to see the picturebox frame. 
When we click the Generate maze button so we make sure that the user doesn’t generate a new one so we disable the button and solve maze button enabled. It also sets can_highlight to false because we have already set the start point and hence no need to highlight the cells. It also calls the generate maze to create one.
We enable generate maze only when grid is created. We enable the solve maze only when maze is generated and remove the highlight option. 
If we change the slider value after creation of a grid of specific value. Then the program checks if we have already created a grid with same slider value. If not created we create it again else we prompt the message of already created. It also checks if maze generation has take place or not by checking the value of grid_created. Even if maze is already created it creates a new grid and we can again select a start point.
timer_Tick :  solving a maze also involves the same algorithm with which we created it. This time it sets the cells to the new created highlighted boxes which mark a valid path. If we have to backtrace a given path then it also changes the box to the initial cell frame. So at the end only the path is highlighted. 



