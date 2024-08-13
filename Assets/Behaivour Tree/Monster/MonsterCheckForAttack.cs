using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCheckForAttack : Leaf
{
    private Vector3Object playerPosition;
    private Monster monster;

    public MonsterCheckForAttack(Monster monsterScript, Vector3Object pPosition)
    {
      monster = monsterScript;
      playerPosition = pPosition;
    }

    public override void ExecuteBehaviour(BehaivourTreeNode node)
    {
      parentNode = node;
      RaycastHit hit;
      Physics.Raycast(monster.gameObject.transform.position, playerPosition.value - monster.gameObject.transform.position, out hit, 3.5f);
      if(hit.collider is not null)
      {
        if(hit.collider.tag == "Player")
        {
          AttackPlayer();
          return;
        }
      }
      parentNode.ReturnResult(true);
    }

    private void AttackPlayer()
    {
      monster.Attack();
      parentNode.ReturnResult(true);
    }
}
