# Coding2_Lab11

How does each pathfinding algorithms calculate and prioritize paths?

BFS - Explores the nodes through a queue that uses cameFrom to guarantee the shortest path.
DFS - Explores all possible paths with a heuristic that is always zero, to find the shortest path.
A* - BFS guarantees the shortest path, but is more efficient by using a PrioirtyQueue. 

<br>
What challenges arise when dynamically updating obstacles in real-time?

Some challenges include the possibility of overlapping actors and the requirement of clearing/resetting generated assets. 

<br>
Which algorithm should you choose and how should you adapt it for larger grids or open-world settings?

You should choose A* as it is the fastest option, and uses PriorityQueue. Even though it is the least cost-effective option, large open worlds require quick, efficient loading. 

<br>
What would your approach be if you were to add weighted cells (e.g., "difficult terrain" areas)?
Have a preset range randomizer to set the weights of each cell, so there would be some element of randomization while keeping it in a controlled environment. 
