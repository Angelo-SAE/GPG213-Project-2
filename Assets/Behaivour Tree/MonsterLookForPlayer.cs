using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLookForPlayer : Leaf
{
  public override bool ExecuteBehaviour()
  {
    //if(Physics.RaycastHit(transform.position, ))
    Debug.Log("L;ooking");
    return true;
  }
}
