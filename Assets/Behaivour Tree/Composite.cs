using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Composite : BehaivourTreeNode
{
    protected List<BehaivourTreeNode> children = new List<BehaivourTreeNode>();

    public abstract bool ExecuteBehaviour();

    public void AddNode(BehaivourTreeNode node)
    {
      children.Add(node);
    }
}
