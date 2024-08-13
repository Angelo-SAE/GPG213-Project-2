using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float knockbackPower;
    [SerializeField] private int playerHealth;
    [SerializeField] private AudioSource uuough;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private UnityEvent onDeath;

    public void GetHit(Vector3 hitFrom)
    {
      //rb.AddForce((transform.position - hitFrom).normalized * knockbackPower, ForceMode.Impulse);
      uuough.Play();
      playerHealth -= 10;
      healthSlider.value = playerHealth;
      CheckForDead();
    }

    private void CheckForDead()
    {
      if(playerHealth <= 0)
      {
        onDeath.Invoke();
        Cursor.lockState = CursorLockMode.None;
      }
    }
}
