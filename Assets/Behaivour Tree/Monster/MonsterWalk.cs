using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalk : Leaf
{
    private MonsterMovement monsterMovement;

    public MonsterWalk(MonsterMovement mMovement)
    {
      monsterMovement = mMovement;
    }

    public override void ExecuteBehaviour(BehaivourTreeNode node)
    {
      monsterMovement.MoveForward(2, 2, node);
    }
}
