using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_SetFlage : MonoBehaviour
{
    public int count;
    private float last_time;
    private float Dirction = 1f;
    public void Flag(InputAction.CallbackContext ctx)
    {
        if (Time.time > Dirction + last_time)
        {
            EventSystem.FlagGenerated(this.transform.position);
            last_time = Time.time;
            ++count;
        }
    }
}
