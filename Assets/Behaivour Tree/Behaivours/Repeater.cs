using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : Decorator
{
    //Inherits Child very little

    private int repetitions, currentRepetition;

    public override void ExecuteBehaviour(BehaivourTreeNode node) {}

    public override void ExecuteBehaviour(BehaivourTreeNode node, int repeat)
    {
      parentNode = node;
      repetitions = repeat;
      currentRepetition = 0;
      RunNode();
    }

    public override void ReturnResult(bool result)
    {
      if(result)
      {
        if(currentRepetition <= repetitions)
        {
          RunNode();
        } else {
          parentNode.ReturnResult(true);
        }
      } else {
        parentNode.ReturnResult(false);
      }
    }

    private void RunNode()
    {
      child.ExecuteBehaviour(this);
    }
}
