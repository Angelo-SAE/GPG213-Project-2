using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    //Inherits Children very wierd

    public override void ExecuteBehaviour(BehaivourTreeNode node)
    {
      parentNode = node;
      currentChild = 0;
      RunNextNode();
    }

    public override void ReturnResult(bool result)
    {
      if(result)
      {
        parentNode.ReturnResult(true);
      } else {
        RunNextNode();
      }
    }

    private void RunNextNode()
    {
      if(currentChild < children.Count)
      {
        currentChild++;
        children[currentChild - 1].ExecuteBehaviour(this);
      } else {
        parentNode.ReturnResult(false);
      }
    }
}
