using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AStar2DPathFinding
{
    internal class GridNode
    {
        internal int gCost, hCost, fCost;
        internal bool open, closed, isWalkable;
        internal Vector3Int gridPosition;
        internal Vector3 worldPosition;
        internal GridNode parentNode;

        internal GridNode(Vector3Int gridPos, Vector3 worldPos, bool canWalk)
        {
            gridPosition = gridPos;
            worldPosition = worldPos;
            isWalkable = canWalk;
        }
    }
}
