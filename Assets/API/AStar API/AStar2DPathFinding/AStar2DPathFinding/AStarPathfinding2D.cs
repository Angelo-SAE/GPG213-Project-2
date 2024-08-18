using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AStar2DPathFinding
{
    public class AStarPathfinding2D : MonoBehaviour
    {
        private void Start()
        {
            closedList = new LinkedList<GridNode>();
            openList = new LinkedList<GridNode>();
            GenerateGridNodes();
        }

        private void FixedUpdate()
        {
            if (moving)
            {
                MoveTowardsPoint();
            }
        }


        [SerializeField] private float movementSpeed;

        public void MoveToEndNode()
        {
            endPosition = new Vector2Int((int)Mathf.Floor(transform.position.x), (int)Mathf.Floor(transform.position.y));
            startPosition = new Vector2Int((int)Mathf.Floor(endObject.transform.position.x), (int)Mathf.Floor(endObject.transform.position.y));
            moving = false;
            foundPath = false;
            FindStarPath();
        }

        [Header("Path Finding")]
        [SerializeField] private GameObject endObject;
        private Vector2Int startPosition, endPosition;
        [SerializeField] private int orthogonalMovementToll, maxChecks;
        private LinkedList<GridNode> closedList, openList;
        private GridNode currentNode, startNode, endNode;
        private bool foundPath, moving;

        private void FindStarPath()
        {
            ClearGridNodes();
            endNode = gridNodes[endPosition.x, endPosition.y];
            startNode = gridNodes[startPosition.x, startPosition.y];
            CheckForPathFound(startNode);
            GetNodeNeighbours(startNode);
        }

        private void GetNodeNeighbours(GridNode node)
        {
            //Debug.Log(node.gridPosition);
            currentNode = node;
            CloseNode(currentNode);
            for (int a = 0; a < movementDirection.Count; a++)
            {
                int currentXDirection = node.gridPosition.x + movementDirection[a].x;
                int currentYDirection = node.gridPosition.y + movementDirection[a].y;
                if (currentXDirection < gridNodes.GetLength(0) && currentXDirection >= 0 && currentYDirection < gridNodes.GetLength(1) && currentYDirection >= 0)
                {
                    if (!gridNodes[currentXDirection, currentYDirection].closed && gridNodes[currentXDirection, currentYDirection].isWalkable)
                    {
                        CalculateGCost(gridNodes[currentXDirection, currentYDirection]);
                    }
                }
            }
            if (!foundPath && openList.Count() > 0)
            {
                CheckNextNode();
            }
        }

        private void CheckNextNode()
        {
            GetNodeNeighbours(openList.PopFirst());
        }

        private void CalculateGCost(GridNode node)
        {
            int tempGCost = currentNode.gCost + orthogonalMovementToll;

            if (!node.open)
            {
                node.gCost = tempGCost;
                node.parentNode = currentNode;
                CalculateHCost(node);
            }
            else if (node.gCost > tempGCost)
            {
                node.gCost = tempGCost;
                node.parentNode = currentNode;
                CalculateFCost(node);
            }
        }

        private void CalculateHCost(GridNode node)
        {
            int tempHCost = (Mathf.Abs(node.gridPosition.x - endNode.gridPosition.x) + Mathf.Abs(node.gridPosition.y - endNode.gridPosition.y)) * orthogonalMovementToll;
            node.hCost = tempHCost;
            CalculateFCost(node);
        }

        private void CalculateFCost(GridNode node)
        {
            node.fCost = node.gCost + node.hCost;
            SortNodeIntoList(node);
            CheckForPathFound(node);
        }

        private void SortNodeIntoList(GridNode node)
        {
            if (!node.open)
            {
                if (openList.Count() == 0)
                {
                    openList.AddToFront(node);
                    node.open = true;
                }
                else
                {
                    for (int a = 0; a < openList.Count(); a++)
                    {
                        if (node.fCost <= openList.GetElementAt(a).fCost)
                        {
                            openList.InsertElementAt(a, node);
                            node.open = true;
                            break;
                        }
                    }
                }
            }
            if (!node.open)
            {
                openList.AddToBack(node);
                node.open = true;
            }
        }

        private void CloseNode(GridNode node)
        {
            closedList.AddToFront(node);
            node.open = false;
            node.closed = true;
        }

        private void CheckForPathFound(GridNode node)
        {
            if (node.gridPosition.x == endPosition.x && node.gridPosition.y == endPosition.y)
            {
                currentNode = node;
                moving = true;
                foundPath = true;
            }
        }

        private void ClearGridNodes()
        {
            int xGrid = Mathf.Abs((int)gridEnd.x - (int)gridStart.x);
            int yGrid = Mathf.Abs((int)gridEnd.y - (int)gridStart.y);
            for (int a = 0; a < xGrid; a++)
            {
                for (int b = 0; b < yGrid; b++)
                {
                    GridNode tempNode = gridNodes[a, b];
                    tempNode.open = false;
                    tempNode.closed = false;
                    tempNode.parentNode = null;
                }
            }
            closedList = new LinkedList<GridNode>();
            openList = new LinkedList<GridNode>();
        }

        private void MoveTowardsPoint()
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(currentNode.worldPosition.x, currentNode.worldPosition.y), movementSpeed);
            if ((Vector2)transform.position == new Vector2(currentNode.worldPosition.x, currentNode.worldPosition.y))
            {
                if (currentNode.parentNode is null)
                {
                    foundPath = false;
                    moving = false;
                }
                else
                {
                    currentNode = currentNode.parentNode;
                }
            }
        }

        //Grid Stuff
        [Header("GridStuff")]
        [SerializeField] private Vector2Int gridStart;
        [SerializeField] private Vector2Int gridEnd;
        [SerializeField] private LayerMask wallLayer;
        [SerializeField] private int nodeHeight, nodeWidth;
        private GridNode[,] gridNodes;

        private void GenerateGridNodes()
        {
            int tempXStart = 0;
            int tempYStart = 0;
            int xGrid = Mathf.Abs(gridEnd.x - gridStart.x);
            int yGrid = Mathf.Abs(gridEnd.y - gridStart.y);
            gridNodes = new GridNode[xGrid, yGrid];

            for (int a = 0; a < xGrid; a++)
            {
                for (int b = 0; b < yGrid; b++)
                {
                    Vector3Int nodeGridPosition = new Vector3Int(tempXStart, tempYStart, 0);
                    Vector2 nodeWorldPosition = new Vector2((tempXStart * nodeWidth) + (nodeWidth / 2f), (tempYStart * nodeHeight) + (nodeHeight / 2f));
                    if (Physics2D.OverlapBox(nodeWorldPosition, new Vector2(nodeWidth / 1.5f, nodeHeight / 1.5f), 0f, wallLayer) is null)
                    {
                        gridNodes[a, b] = new GridNode(nodeGridPosition, nodeWorldPosition, true);
                    }
                    else
                    {
                        gridNodes[a, b] = new GridNode(nodeGridPosition, nodeWorldPosition, false);
                    }
                    tempYStart++;
                }
                tempYStart = 0;
                tempXStart++;
            }
        }

        private List<Vector3Int> movementDirection = new List<Vector3Int>
    {
      new Vector3Int(0,1,0),
      new Vector3Int(1,0,0),
      new Vector3Int(0,-1,0),
      new Vector3Int(-1,0,0)
    };
    }
}
