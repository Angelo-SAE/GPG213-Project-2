using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterKill : Leaf
{
  public override bool ExecuteBehaviour()
  {
    Debug.Log("Killing");
    return false;
  }
}
