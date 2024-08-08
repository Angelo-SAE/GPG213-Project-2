using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLookForPlayer : Leaf
{
    private Vector3Object playerPosition;
    private GameObject monsterObject;

    public MonsterLookForPlayer(GameObject mObject, Vector3Object pPosition)
    {
      monsterObject = mObject;
      playerPosition = pPosition;
    }

    public override bool ExecuteBehaviour()
    {
      RaycastHit hit;
      Physics.Raycast(monsterObject.transform.position, playerPosition.value - monsterObject.transform.position, out hit, Mathf.Infinity);
      if(hit.collider is not null)
      {
        if(hit.collider.tag == "Player")
        {
          Debug.Log("Looking");
          return true;
        }
      }
      return false;
    }
}
