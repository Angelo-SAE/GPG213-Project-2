using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] private float attackRange, attackCooldown;
    [SerializeField] private Transform attackLocation;
    [SerializeField] private LayerMask playerLayer;
    private float timeLeft;
    private bool onCooldown;

    private void OnDrawGizmos()
    {
      Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }

    private void Update()
    {
      if(onCooldown)
      {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
          onCooldown = false;
        }
      }
    }

    public void Attack()
    {
      if(!onCooldown)
      {
        Collider[] playerCollider = Physics.OverlapSphere(attackLocation.position, attackRange, playerLayer);
        if(playerCollider is not null)
        {
          playerCollider[0].GetComponent<Player>().GetHit(transform.position);
        }
        onCooldown = true;
        timeLeft = attackCooldown;
      }
    }
}
