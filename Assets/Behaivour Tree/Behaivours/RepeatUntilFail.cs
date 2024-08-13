using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatUntilFail : Decorator
{
    //Inherits Child very little

    public override void ExecuteBehaviour(BehaivourTreeNode node)
    {
      parentNode = node;
      ExecuteNode();
    }

    public override void ExecuteBehaviour(BehaivourTreeNode node, int a) {}

    public override void ReturnResult(bool result)
    {
      if(result)
      {
        ExecuteNode();
      } else {
        parentNode.ReturnResult(true);
      }
    }

    private void ExecuteNode()
    {
      child.ExecuteBehaviour(this);
    }
}
