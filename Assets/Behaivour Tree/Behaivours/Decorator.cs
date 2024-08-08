using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator : BehaivourTreeNode
{
    protected BehaivourTreeNode child;

    public abstract bool ExecuteBehaviour();

    public abstract bool ExecuteBehaviour(int a);

    public void AddNode(BehaivourTreeNode node)
    {
      child = node;
    }
}
