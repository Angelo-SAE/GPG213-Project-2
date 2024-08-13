using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Composite : BehaivourTreeNode
{
    protected List<BehaivourTreeNode> children = new List<BehaivourTreeNode>();
    protected BehaivourTreeNode parentNode;
    protected int currentChild;

    public abstract void ExecuteBehaviour(BehaivourTreeNode node);

    public abstract void ReturnResult(bool result);

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
