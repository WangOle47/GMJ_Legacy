using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_SetFlage : MonoBehaviour
{ 
    public void Flag(InputAction.CallbackContext ctx)
    {
        EventSystem.FlagGenerated(this.transform.position);
    }
}
