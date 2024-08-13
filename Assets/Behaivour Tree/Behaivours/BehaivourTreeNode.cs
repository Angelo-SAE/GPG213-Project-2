using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BehaivourTreeNode
{
    void ExecuteBehaviour(BehaivourTreeNode node);
    void ReturnResult(bool result);
}
