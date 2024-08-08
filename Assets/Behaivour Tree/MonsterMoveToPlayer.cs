using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveToPlayer : Leaf
{
  public override bool ExecuteBehaviour()
  {
    Debug.Log("MovingToPlayer");
    return true;
  }
}
