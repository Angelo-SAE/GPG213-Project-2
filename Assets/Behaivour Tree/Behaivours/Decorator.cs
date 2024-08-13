using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator : BehaivourTreeNode
{
    protected BehaivourTreeNode child;
    protected BehaivourTreeNode parentNode;

    public abstract void ExecuteBehaviour(BehaivourTreeNode node);

    public abstract void ExecuteBehaviour(BehaivourTreeNode node, int a);

    public abstract void ReturnResult(bool result);

    public void AddNode(BehaivourTreeNode node)
    {
      child = node;
    }
}
