using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer_Oncullion : MonoBehaviour
{
    private LayerMask playerLayer;
    private void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            EventSystem.Damage("Collision");
        }
    }
}
