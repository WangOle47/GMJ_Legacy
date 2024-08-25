using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flage : MonoBehaviour
{
    public void Touch()
    {
        GmF.GhostSystemManager.GhostSystemManager_Instance.PlayRecord(0f);
    }

    public void ToDestroy()
    {
        Destroy(gameObject);
    }
}
