using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] private Vector3Object playerPosition;
    private Sequence sequenceOne;
    private Sequence sequenceTwo;
    private Selector selectorOne;

    private void Start()
    {
      selectorOne = new Selector();
      sequenceOne = new Sequence();
      sequenceTwo = new Sequence();
      AddNodesToSequenceOne();
      AddNodesToSequenceTwo();
      AddNodesToSelectorOne();
    }

    private void AddNodesToSequenceOne()
    {
      sequenceOne.AddNode(new MonsterLookForPlayer(this.gameObject, playerPosition));
      sequenceOne.AddNode(new MonsterMoveToPlayer(this.gameObject, playerPosition));
      sequenceOne.AddNode(new MonsterKill());
    }

    private void AddNodesToSequenceTwo()
    {
      sequenceTwo.AddNode(new MonsterRotate());
      sequenceTwo.AddNode(new MonsterWalk());
    }

    private void AddNodesToSelectorOne()
    {
      selectorOne.AddNode(sequenceOne);
      selectorOne.AddNode(sequenceTwo);
    }

    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.E))
      {
        selectorOne.ExecuteBehaviour();
      }
    }
}
