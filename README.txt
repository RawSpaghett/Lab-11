How does each pathfinding algorithms calculate and prioritize paths?
BFS - explores the grid outward, one row at a time. does not consider distance to the goal
A* - combines djikstra and total distance to goal to find shortest path
Djikstra - calculates total cost for each node and calculates based on shortest total cost


What challenges arise when dynamically updating obstacles in real-time?
One large problem is efficiently maintaining a valid path. If you do one search when the game starts with moving obstacles, odds are you
are going to end up being blocked. To combat this, you can update your path more often. But doing this also hurts, as you may start to
effect your own performance. If you are running many enemies at once that are using high cost searching, you will also end up running into the same problem as recalculating one over and over again, as that is what you are doing.

Which algorithm should you choose and how should you adapt it for larger grids or open-world settings?
You should realistically not only use one search algorithm, as choosing solely one will end up biting you in the back. If you were to just use A* on a large mmo like world with thousands of npcs, you are going to make most computers absolutely chug. You could start small, maybe just adding A* to everything, and then adding a path validation checker to let you know if you need to recalculate. Then you can expand farther and use some hierarchal pathfinding to split your grid up and help performance costs even more.

What would your approach be if you were to add weighted cells (e.g., "difficult terrain" areas)?
A* would be the most efficient, as it combines djikstra, which is solely for calculating total cost, and the distance to the goal. This will
allow you to create whatever hard to traverse or slow environment that you would like to, while still getting there in the most efficient time.