using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Decorator
{
    //Inherits Child very little

    public override void ExecuteBehaviour(BehaivourTreeNode node)
    {
      parentNode = node;
      RunNode();
    }

    public override void ExecuteBehaviour(BehaivourTreeNode node, int a) {}

    public override void ReturnResult(bool result)
    {
      if(result)
      {
        parentNode.ReturnResult(false);
      } else {
        parentNode.ReturnResult(true);
      }
    }

    private void RunNode()
    {
      child.ExecuteBehaviour(this);
    }
}
