using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveToPlayer : Leaf
{
    private MonsterMovement monsterMovement;
    private Vector3Object playerPosition;

    public MonsterMoveToPlayer(MonsterMovement mMovement, Vector3Object pPosition)
    {
      monsterMovement = mMovement;
      playerPosition = pPosition;
    }

    public override void ExecuteBehaviour(BehaivourTreeNode node)
    {
      parentNode = node;
      monsterMovement.MoveTowardsPlayer(3, 3, node);
    }
}
