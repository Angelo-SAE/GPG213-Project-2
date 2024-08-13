using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : BehaivourTreeNode
{
    private BehaivourTreeNode child;
    private Monster monster;

    public void ExecuteBehaviour(BehaivourTreeNode node) {}

    public void ExecuteBehaviour(Monster mons)
    {
      monster = mons;
      child.ExecuteBehaviour(this);
    }

    public void ReturnResult(bool result)
    {
      if(result)
      {
        monster.cycleDone = true;
      } else {
        monster.cycleDone = true;
      }
    }

    public void AddNode(BehaivourTreeNode node)
    {
      child = node;
    }
}
