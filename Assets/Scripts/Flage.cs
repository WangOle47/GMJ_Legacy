using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flage : MonoBehaviour
{
    public void Touch()
    {
        GmF.GhostSystemManager.GhostSystemManager_Instance.PlayRecord();
    }

    public void ToDestroy()
    {
        Destroy(gameObject);
    }
}
