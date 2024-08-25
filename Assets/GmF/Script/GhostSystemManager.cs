using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GmF
{
    public class GhostSystemManager : MonoBehaviour
    {
        public static GhostSystemManager Instance;

        public static GhostSystemManager GhostSystemManager_Instance
        {
            get
            {
                if(Instance == null)
                {
                    GameObject go = new GameObject("GhostSystemManager");
                    Instance = go.AddComponent<GhostSystemManager>();
                    DontDestroyOnLoad(go);
                }
                return Instance;
            }
        }

        private PlayerGhostRecorControler _PlayerGhostRecorControler;

        public void SetPlayerGhostRecorControler(PlayerGhostRecorControler playerGhostRecorControler)
        {
            _PlayerGhostRecorControler = playerGhostRecorControler;
        }

        private GhostController _GhostController;
        private GameObject _GhostPrefab;

        bool onRecord = false;
        AnimationCurve newRecordX = new AnimationCurve();
        AnimationCurve newRecordY = new AnimationCurve();
        float StartRecordTime = 0;

        AnimationCurve oldRecordX = new AnimationCurve();
        AnimationCurve oldRecordY = new AnimationCurve();

        public float RePlayTimeScal = 1;

        CharacterOnFlagNotReadySoundEffectPlayer _CharacterOnFlagNotReadySoundEffectPlayer = null;

        public bool DebugTool_StartRecord = false;
        public bool DebugTool_EndRecord = false;

        public bool DebugTool_RePlayRecord = false;

        private void Awake()
        {
            EventSystem.OnFlagGenerated -= StartRecord;
            EventSystem.OncharacterDead -= EndRecord;
            EventSystem.OnFlagGenerated += StartRecord;
            EventSystem.OncharacterDead += EndRecord;
            FlagManager.FlagManager_Instance.Init();
        }

        public void StartRecord(Vector2 pos)
        {
            Debug.Log("<color=white>StartRecord</color>");
            if (_GhostController != null)
            {
                _GhostController.ToDestory();
                _GhostController = null;
            }

            newRecordX.ClearKeys();
            newRecordY.ClearKeys();
            onRecord = true;
            StartRecordTime = Time.time;
        }

        public void EndRecord(Vector2 pos)
        {
            Debug.Log("<color=white>EndRecord</color>");
            onRecord = false;
            oldRecordX.ClearKeys();
            foreach(var item in newRecordX.keys)
            {
                oldRecordX.AddKey(item.time, item.value);
            }
            oldRecordY.ClearKeys();
            foreach (var item in newRecordY.keys)
            {
                oldRecordY.AddKey(item.time, item.value);
            }
        }

        public void PlayRecord()
        {
            Debug.Log("<color=white>PlayRecord</color>");
            if(oldRecordX.length == 0 || oldRecordY.length == 0)
            {
                Debug.Log("<color=yellow>Record is not ready!</color>");
                if (_CharacterOnFlagNotReadySoundEffectPlayer == null)
                {
                    _CharacterOnFlagNotReadySoundEffectPlayer = FindAnyObjectByType<CharacterOnFlagNotReadySoundEffectPlayer>();
                    if (_CharacterOnFlagNotReadySoundEffectPlayer == null)
                    {
                        Debug.LogError("Can't find CharacterOnFlagNotReadySoundEffectPlayer");
                    }
                }
                else
                {
                    _CharacterOnFlagNotReadySoundEffectPlayer.Play();
                }
                return;
            }
            if (_GhostController != null)
            {
                _GhostController.ToDestory();
                _GhostController = null;
            }

            if (_GhostPrefab == null)
            {
                _GhostPrefab = Resources.Load<GameObject>("Prefab/GhostCharacter");
            }
            
            GameObject newGhost = Instantiate(_GhostPrefab) as GameObject;
            _GhostController = newGhost.AddComponent<GhostController>();

            _GhostController.StartPlay(oldRecordX, oldRecordY, RePlayTimeScal);
        }

        private void Update()
        {
            if(DebugTool_StartRecord)
            {
                DebugTool_StartRecord = false;
                StartRecord(Vector2.zero);
            }

            if (DebugTool_EndRecord)
            {
                DebugTool_EndRecord = false;
                EndRecord(Vector2.zero);
            }

            if (DebugTool_RePlayRecord)
            {
                DebugTool_RePlayRecord = false;
                PlayRecord();
            }

            if (onRecord)
            {
                Vector2 pos = _PlayerGhostRecorControler.gameObject.transform.position;
                newRecordX.AddKey(Time.time - StartRecordTime, pos.x);
                newRecordY.AddKey(Time.time - StartRecordTime, pos.y);
            }
        }
    }
}

