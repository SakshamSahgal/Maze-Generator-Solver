To Play around with it  , just install the windows setup in -->> Deployment Setup/Maze Setup/Release/Maze Setup.msi 
and you are ready to go.

# Maze-Generator-Solver
Generates random solvable mazes and solves them in realtime.


<strong>MAZE GENERATION PROJECT : DOCUMENTATION</strong>

Designed and Developed by: Saksham Sahgal and Bhavya Wig

<strong>Project Overview:</strong>

> This project is built on Visual studio [Winforms] using C# language.

>It generates random solvable mazes and solves them in realtime.

>User can select the size of the maze and a starting point for the maze generation to begin , the end point is the bottom right cell.

>We use the concept of Depth First Algorithm (DFS) to both generate and solve mazes.


<strong>Here is a brief description of the code for better understanding.</strong>

<strong>How Do We Generate Mazes ?</strong>

<strong>Pseudo Code :</strong>

>select starting point
>mark starting point visited
>push starting point in a stack of pairs
>
>while(stack is not empty)
<br/> &nbsp;&nbsp;{
<br/>	&nbsp;&nbsp;>select top coordinates of stack as current cell
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;if( any unvisited neighbour of current cell is available )
<br/>&nbsp;&nbsp;&nbsp;&nbsp;	{
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	>randomly choose an unvisited available neighbour of current cell
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	>push that neighbour into the stack of pair
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	>mark it as visited
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	>open its way via Async function
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;}
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;else
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	pop current cell from the stack
<br/>&nbsp;&nbsp;&nbsp;&nbsp;}

<strong>How Do We Solve Mazes?</strong>

<strong>Pseudo Code :</strong>

> Add the start pointcoordinates into the stack ofpairs . mark it as visited and color this cell
<br/>whi|e(stack is not empty)
<br/>&nbsp;&nbsp;{
<br/>	&nbsp;&nbsp;> select the top most coordinates ofthe stack as currentcell
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;lf(current cell is bottom right cell)	
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	Maze solved:
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;else
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;{
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;	if(any neighbor of this cell exists where path is possible and neighbor is unvisited)
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;	{
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	> add that neighbour into the stack
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	> Color that neighbor cell
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	> mark that cell as visited
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;	}
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;	else
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;	{
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	>pop this cell from the stack
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	>decolorize this cell
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;	}
<br/>	&nbsp;&nbsp;&nbsp;&nbsp;}
<br/>&nbsp;&nbsp;}

We initialize <strong>grid_size</strong> which is the frame in which maze will be formed. <strong>Cell_size</strong> will indicate the length of each box in maze when grid will be created. Desired_values is the values which the slider can take and create respective grid.

 <strong>Cell_frames </strong> is an image array of size 16 which stores all possibilities of walls in a cell. Vis_cell_frames stores all possibilities same as cell_frames but will be used to solve the maze while cell_frames to generate maze. Call_freq stores the time period of timer, it depicts that the smaller mazes will be solved slower that the large mazes. Start_point_i and start_point_j indicates the start point coordinates of i,j. can_highlight which is initially true indicates whether to highlight cells in the grid when cursor passes by. Start_selected indicates whether a start point in the grid is chosen or not. All these variables are global and hence can be accessed anywhere in the code.

There is a function called  <strong>extract_row_col </strong>, the sole purpose is to extract two numbers iii and jjj which are the respective row and column of each cell from its string id. These are then stored in a tuple named ‘t’.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           
	                                                               CELL CLASS
								       
We created a class called <strong> Cells  </strong> which stores various properties of a cell. We initialize four Boolean integers namely 
 <br/><strong>Upper_Wall  </strong>
 <br/><strong>Right_Wall  </strong>
 <br/><strong>Down_Wall </strong>
 <br/><strong>Left_Wall </strong>

An integer frameindex which sets different frames to cell. We also store a highlighted image in highlighted image.

A constructor named <strong>cells </strong> is created which sets all four Boolean of walls to false, which means all the walls are not present. It also creates a new picturebox in each cell frame and sets its width, height, location, image. Sets when mouse enters and leaves a cell. 

There is a function  <strong>update_cell_frame </strong> which sets image to a cell if its not null. There are 8 functions named like turn_off_upper_wall, turn_on_upper_wall, turn_off_down_wall and so on. It updates respective Booleans to true and false respectively and updates frameindex and calls update_cell_frame function. 

 <strong>Highlight function </strong> adds the highlighted (green) image on the respective cell. Get_cell_state returns frameindex. 

 <strong> Green_highlight </strong> is a function which extracts the current cell from the tuple values ‘t’ we stored initially, at which is mouse is pointing and updates the cell picture. 

 <strong>Back_to_normal </strong> function removes the green highlight on the cell by checking if can_highlight is true and this cell has a is_starting as false.

 <strong>Initialize_Cell_Frames : </strong> it sets all indexes of cell_frames to their respective pictures.(It stores all permutations of walls on and off). 

 <strong> Construct_Grid : </strong> it creates empty cells and stores it into current cells and also adds them to front and the picturebox at the end. It also makes all walls on and hence the grid is formed.

 <strong> generate_maze :  </strong>when we call this function sound starts to play with formation of a valid maze. We here make a Boolean array vis to make sure all cells are visited. Hence, the vis array is initially false, except the starting point. Initially, the first cell indexes are added to the queue. We run a while loop till the stack is empty. It selects the top most element and checks if there is a unvisited neighbour. If it finds such a neighbour it pushes that neighbour into stack of pair and marks the vis array true. Async function is called thereafter. If no neighbour is found it pops the uppermost element of the stack. This is basically implementation of Depth First Search (DFS). 

 <strong> trace_wall : </strong> this function makes sure that a possible maze is created. It checks if the ith cell has left wall on then the i-1th cell right wall should also be on and so on for all the respective overlapping walls.

 <strong> Delete_prev  </strong> is a function we call when we click Clear grid as it clears the grid and sets all cells to blank and we are able to see the picturebox frame. 

When we click the Generate maze button so we make sure that the user doesn’t generate a new one so we disable the button and solve maze button enabled. It also sets can_highlight to false because we have already set the start point and hence no need to highlight the cells. It also calls the generate maze to create one.

We enable generate maze only when grid is created. We enable the solve maze only when maze is generated and remove the highlight option. 

If we change the slider value after creation of a grid of specific value. Then the program checks if we have already created a grid with same slider value. If not created we create it again else we prompt the message of already created. It also checks if maze generation has take place or not by checking the value of grid_created. Even if maze is already created it creates a new grid and we can again select a start point.

 <strong> timer_Tick :  </strong>  solving a maze also involves the same algorithm with which we created it. This time it sets the cells to the new created highlighted boxes which mark a valid path. If we have to backtrace a given path then it also changes the box to the initial cell frame. So at the end only the path is highlighted. 

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

