using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : Decorator
{
    //Inherits Child very little

    public override bool ExecuteBehaviour()
    {
      return true;
    }

    public override bool ExecuteBehaviour(int repetitions)
    {
      for(int a = 0; a < repetitions; a++)
      {
        if(!child.ExecuteBehaviour())
        {
          return false;
        }
      }
      return true;
    }
}
