using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer_Ontrigger : MonoBehaviour
{
    public LayerMask playerLayer; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            EventSystem.Damage("Trigger");
        }
    }
}
