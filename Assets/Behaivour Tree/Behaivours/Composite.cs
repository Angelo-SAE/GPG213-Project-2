using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Composite : BehaivourTreeNode
{
    protected List<BehaivourTreeNode> children = new List<BehaivourTreeNode>();

    public abstract bool ExecuteBehaviour();

    public void AddNodes(BehaivourTreeNode[] nodes)
    {
      for(int a = 0; a < nodes.Length; a++)
      {
        children.Add(nodes[a]);
      }
    }

    public void AddNode(BehaivourTreeNode node)
    {
      children.Add(node);
    }
}
