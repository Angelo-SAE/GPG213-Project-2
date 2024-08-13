using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer master;
    [SerializeField] private Slider volumeSlider, sensSlider;
    [SerializeField] private FloatObject sens;

    private void Start()
    {
      sensSlider.value = sens.value;
      float woop = 0;
      master.GetFloat("masterVolume", out woop);
      volumeSlider.value = woop;
    }

    public void SetVolume()
    {
      master.SetFloat("masterVolume", volumeSlider.value);
    }

    public void SetSens()
    {
      sens.value = sensSlider.value;
    }

    public void LoadScene(string sceneName)
    {
      SceneManager.LoadScene(sceneName);
    }
}
