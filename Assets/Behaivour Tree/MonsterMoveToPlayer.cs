using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveToPlayer : Leaf
{
    private GameObject monsterObject;
    private Vector3Object playerPosition;

    public MonsterMoveToPlayer(GameObject mObject, Vector3Object pPosition)
    {
      monsterObject = mObject;
      playerPosition = pPosition;
    }

    public override bool ExecuteBehaviour()
    {
      Debug.Log("MovingToPlayer");
      return true;
    }
}
