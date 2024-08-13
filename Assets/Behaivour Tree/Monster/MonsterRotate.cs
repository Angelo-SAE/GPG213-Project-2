using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRotate : Leaf
{
    private MonsterMovement monsterMovement;

    public MonsterRotate(MonsterMovement mMovement)
    {
      monsterMovement = mMovement;
    }

    public override void ExecuteBehaviour(BehaivourTreeNode node)
    {
      monsterMovement.Rotate(Random.Range(0, 1 + 1), node);
    }
}
