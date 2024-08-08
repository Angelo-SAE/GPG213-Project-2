using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatUntilFail : Decorator
{
    //Inherits Child very little

    public override bool ExecuteBehaviour()
    {
      bool returnsTrue = true;
      while(returnsTrue)
      {
        returnsTrue = child.ExecuteBehaviour();
      }
      return true;
    }

    public override bool ExecuteBehaviour(int a)
    {
      return true;
    }
}
