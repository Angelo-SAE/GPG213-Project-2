using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private UnityEvent movePlayer;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
          movePlayer.Invoke();
        }
    }
}
