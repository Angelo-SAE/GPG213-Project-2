using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    //Inherits Children very wierd

    public override bool ExecuteBehaviour()
    {
      for(int a = 0; a < children.Count; a++)
      {
        if(children[a].ExecuteBehaviour())
        {
          return true;
        }
      }
      return false;
    }
}
