using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRotate : Leaf
{
  public override bool ExecuteBehaviour()
  {
    Debug.Log("Rotating");
    return true;
  }
}
