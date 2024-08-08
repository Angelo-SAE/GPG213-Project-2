using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Decorator
{
    //Inherits Child very little

    public override bool ExecuteBehaviour()
    {
      if(child.ExecuteBehaviour())
      {
        return false;
      }
      return true;
    }

    public override bool ExecuteBehaviour(int a)
    {
      return true;
    }
}
