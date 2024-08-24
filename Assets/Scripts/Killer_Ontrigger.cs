using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer_Ontrigger : MonoBehaviour
{
    private LayerMask playerLayer;
    private void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            EventSystem.Damage("Trigger");
            Debug.Log("hit");
        }
    }
}
