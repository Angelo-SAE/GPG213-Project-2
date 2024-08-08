using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalk : Leaf
{
  public override bool ExecuteBehaviour()
  {
    Debug.Log("Walk");
    return true;
  }
}
