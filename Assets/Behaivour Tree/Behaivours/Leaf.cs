using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Leaf : BehaivourTreeNode
{
    //No Children very sad
    protected BehaivourTreeNode parentNode;

    public abstract void ExecuteBehaviour(BehaivourTreeNode node);

    public void ReturnResult(bool result) {}

}
