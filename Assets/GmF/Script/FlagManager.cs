using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GmF
{
    public class FlagManager : MonoBehaviour
    {
        static FlagManager Instance;
        public static FlagManager FlagManager_Instance
        {
            get
            {
                if(Instance == null)
                {
                    GameObject go = new GameObject("FlagManager");
                    Instance = go.AddComponent<FlagManager>();
                    DontDestroyOnLoad(Instance);
                }
                return Instance;
            }
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnEnterPlayMode]
        static void InitializeInEditor()
        {
            Instance = null;
        }
#endif

        GameObject FlagePrefab = null;
        GameObject EndFlagePrefab = null;
        GameObject EndFlagGO = null;
        Flage _Flage = null;

        private void Awake()
        {
            
        }

        public void Init()
        {
            EventSystem.OnFlagGenerated -= CreateFlage;
            EventSystem.OnFlagGenerated += CreateFlage;
            EventSystem.OncharacterDead += CreateEndFlage;
        }

        public void CreateFlage(Vector2 pos)
        {
            Debug.Log("<color=white>CreateFlage</color>");
            if (FlagePrefab == null)
            {
                FlagePrefab = Resources.Load<GameObject>("Prefab/Flage");
            }

            if(_Flage != null)
            {
                _Flage.ToDestroy();
                _Flage = null;
            }

            GameObject newFlag = Instantiate(FlagePrefab) as GameObject;
            newFlag.name = "Flage";
            _Flage = newFlag.AddComponent<Flage>();
            _Flage.transform.position = pos;
        }

        public void CreateEndFlage(Vector2 pos)
        {
            Debug.Log("<color=white>CreateEndFlage</color>");
            if (EndFlagePrefab == null)
            {
                EndFlagePrefab = Resources.Load<GameObject>("Prefab/EndFlage");
            }

            if (EndFlagGO != null)
            {
                Destroy(EndFlagGO);
                EndFlagGO = null;
            }

            EndFlagGO = Instantiate(EndFlagePrefab) as GameObject;
            EndFlagGO.name = "EndFlage";
            EndFlagGO.transform.position = pos;
        }
    }
}

