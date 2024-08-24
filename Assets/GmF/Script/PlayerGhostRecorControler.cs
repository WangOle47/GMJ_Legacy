using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GmF
{
    public class PlayerGhostRecorControler : MonoBehaviour
    {
        private void Awake()
        {
            GmF.GhostSystemManager.GhostSystemManager_Instance.SetPlayerGhostRecorControler(this);
        }
    }
}

