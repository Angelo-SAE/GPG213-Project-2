using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
      {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
      }
    }
}
