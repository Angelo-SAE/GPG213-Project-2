using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private Vector3Object playerPosition;

    [Header("Others")]
    [SerializeField] private MonsterMovement monsterMovement;
    [SerializeField] private MonsterAttack monsterAttack;
    private StartNode startNode;
    private Sequence sequenceOne;
    private Sequence sequenceTwo;
    private Selector selectorOne;
    [SerializeField] public bool cycleDone;

    private void Start()
    {
      startNode = new StartNode();
      selectorOne = new Selector();
      sequenceOne = new Sequence();
      sequenceTwo = new Sequence();
      startNode.AddNode(selectorOne);
      AddNodesToSequenceOne();
      AddNodesToSequenceTwo();
      AddNodesToSelectorOne();
    }

    private void AddNodesToSequenceOne()
    {
      sequenceOne.AddNode(new MonsterLookForPlayer(this.gameObject, playerPosition));
      sequenceOne.AddNode(new MonsterMoveToPlayer(monsterMovement, playerPosition));
      sequenceOne.AddNode(new MonsterCheckForAttack(this, playerPosition));
    }

    private void AddNodesToSequenceTwo()
    {
      sequenceTwo.AddNode(new MonsterRotate(monsterMovement));
      sequenceTwo.AddNode(new MonsterWalk(monsterMovement));
    }

    private void AddNodesToSelectorOne()
    {
      selectorOne.AddNode(sequenceOne);
      selectorOne.AddNode(sequenceTwo);
    }

    private void Update()
    {
      if(cycleDone)
      {
        cycleDone = false;
        startNode.ExecuteBehaviour(this);
      }
    }

    public void Attack()
    {
      monsterAttack.Attack();
    }
}
