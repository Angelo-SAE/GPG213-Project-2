using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
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
      sequenceOne.AddNode(new MonsterWalk());
      sequenceOne.AddNode(new MonsterLookForPlayer());
      sequenceOne.AddNode(new MonsterMoveToPlayer());
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
