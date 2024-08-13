using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float knockbackPower;

    public void GetHit(Vector3 hitFrom)
    {
      rb.AddForce((transform.position - hitFrom).normalized * knockbackPower, ForceMode.Impulse);
    }
}
