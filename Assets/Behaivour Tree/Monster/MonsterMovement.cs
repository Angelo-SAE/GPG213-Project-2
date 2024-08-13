using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private Vector3Object playerPosition;

    [Header("Others")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private AudioSource meow;

    private float currentSpeed, currentTime, maxTime, rotatingCount;
    private bool moveToPlayer, moveForward, rotateMonster, backwards;
    private BehaivourTreeNode tempNode;

    public void MoveTowardsPlayer(float monsterSpeed, float waitTime, BehaivourTreeNode node)
    {
      meow.Play();
      maxTime = waitTime;
      currentSpeed = monsterSpeed;
      currentTime = 0;
      tempNode = node;
      moveToPlayer = true;
    }

    public void MoveForward(float monsterSpeed, float waitTime, BehaivourTreeNode node)
    {
      maxTime = waitTime;
      currentSpeed = monsterSpeed;
      currentTime = 0;
      tempNode = node;
      moveForward = true;
    }

    public void Rotate(float rotation, BehaivourTreeNode node)
    {
      if(rotation == 0)
      {
        rotationSpeed *= -1;
      } else {
        rotationSpeed = Mathf.Abs(rotationSpeed);
      }
      tempNode = node;
      rotatingCount = 0;
      rotateMonster = true;
    }

    private void Update()
    {
      if(moveToPlayer)
      {
        MoveMonsterTowardsPlayer();
      }
      if(moveForward)
      {
        MoveMonsterForward();
      }
      if(rotateMonster)
      {
        RotateMonster();
      }
    }

    private void MoveMonsterTowardsPlayer()
    {
      currentTime += Time.deltaTime;
      rb.velocity = (playerPosition.value - transform.position).normalized * currentSpeed;
      transform.LookAt(playerPosition.value);
      if(currentTime >= maxTime)
      {
        moveToPlayer = false;
        rb.velocity = Vector3.zero;
        tempNode.ReturnResult(true);
      }
      CheckForColliderInFrontClose();
    }

    private void MoveMonsterForward()
    {
      currentTime += Time.deltaTime;
      rb.velocity = transform.forward * currentSpeed;
      if(currentTime >= maxTime)
      {
        moveForward = false;
        rb.velocity = Vector3.zero;
        tempNode.ReturnResult(true);
      }
      CheckForColliderInFrontClose();
    }

    private void RotateMonster()
    {
      float rotation = Time.deltaTime * rotationSpeed;

      transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + rotation, 0);

      rotatingCount += rotation;

      if(CheckForNoColliderFar() || rotatingCount > 90)
      {
        rotateMonster = false;
        tempNode.ReturnResult(true);
      }
    }

    private void CheckForColliderInFrontClose()
    {
      RaycastHit hit;
      Physics.Raycast(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.forward, out hit, 0.8f);
      if(hit.collider is not null)
      {
        Physics.Raycast(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.forward, out hit, 0.8f);
        if(hit.collider is not null)
        {
          moveToPlayer = false;
          moveForward = false;
          rb.velocity = Vector3.zero;
          tempNode.ReturnResult(true);
        }
      }
    }

    private bool CheckForNoColliderFar()
    {
      RaycastHit hit;
      Physics.Raycast(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.forward, out hit, 2f);
      if(hit.collider is null)
      {
        Physics.Raycast(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.forward, out hit, 2f);
        if(hit.collider is null)
        {
          return true;
        }
      }
      return false;
    }

}
