using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class self_destruct : MonoBehaviour
{
    public void Self_destruct(InputAction.CallbackContext ctx)
    {
        EventSystem.Damage("Self_destruct");
    }
}
