using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer_Oncullion : MonoBehaviour
{
    public LayerMask playerLayer;
    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & playerLayer) != 0)
        {
            EventSystem.Damage("Collision");
        }
    }
}
