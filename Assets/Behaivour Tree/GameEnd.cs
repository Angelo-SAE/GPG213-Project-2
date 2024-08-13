using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private AudioSource gameBreak;
    [SerializeField] private UnityEvent onStartEndSequence;

    private void  OnTriggerEnter(Collider col)
    {
      if(col.tag == "Player")
      {
        StartCoroutine(EndSequence());
      }
    }

    private IEnumerator EndSequence()
    {
      onStartEndSequence.Invoke();
      gameBreak.Play();
      yield return new WaitForSeconds(4.5f);
      Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
      SceneManager.LoadScene(sceneName);
    }

}
