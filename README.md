## FindPath
FindPath is a console application that allows the user to find the shortest path from the beginning to the end of a given matrix.

### Features and architecture
This project implements the `Strategy pattern`, which allows you to use different algorithms to solve the task. Two algorithms are presented in the project: `BFS search` and `Search based on the Euclidean distance`.
### Description of algorithms:
- `BFS Search`: this algorithm iteratively traverses a given matrix, adding all possible points to the current path at each step that satisfy the problem condition. At the end of each iteration, the old paths are removed and the closest ones to the end point are selected (by Euclidean distance)
- `Search based on the Euclidean distance`: the algorithm iteratively traverses a given matrix, at each step adding to the current path the closest point to the final point from the list of possible points that satisfy the task condition.