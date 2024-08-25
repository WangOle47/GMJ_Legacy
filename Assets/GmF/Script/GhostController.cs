using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    AnimationCurve recordX = new AnimationCurve();
    AnimationCurve recordY = new AnimationCurve();
    float RePlayTimeScale = 1;
    float OverTime = 0;
    Vector2 lastPos = Vector2.zero;
    public bool isMoveing = false;

    Chika.GhostPlayedSoundEffectPlayer _GhostPlayedSoundEffectPlayer = null;
    Chika.GhostMovingSoundEffectPlayer _GhostMovingSoundEffectPlayer = null;

    public bool DebugTool_RePlay = false;
    public bool DebugTool_PlayStartSoung = false;
    public bool DebugTool_PlayMovingSoung = false;
    public bool DebugTool_StopMovingSoung = false;

    public void ToDestory()
    {
        Destroy(gameObject);
    }

    public void StartPlay(AnimationCurve setRecordX, AnimationCurve setRecordY, float setRePlayTimeScale)
    {
        if(_GhostPlayedSoundEffectPlayer == null)
        {
            _GhostPlayedSoundEffectPlayer = FindAnyObjectByType<Chika.GhostPlayedSoundEffectPlayer>();
            if(_GhostPlayedSoundEffectPlayer == null)
            {
                Debug.LogError("Can't find GhostPlayedSoundEffectPlayer");
            }
            else
            {
                _GhostPlayedSoundEffectPlayer.Play();
            }
        }

        if (_GhostMovingSoundEffectPlayer == null)
        {
            _GhostMovingSoundEffectPlayer = FindAnyObjectByType<Chika.GhostMovingSoundEffectPlayer>();
            if (_GhostMovingSoundEffectPlayer == null)
            {
                Debug.LogError("Can't find GhostMovingSoundEffectPlayer");
            }
        }

        RePlayTimeScale = setRePlayTimeScale;
        recordX.ClearKeys();
        foreach (var item in setRecordX.keys)
        {
            recordX.AddKey(item.time, item.value);
        }
        recordY.ClearKeys();
        foreach (var item in setRecordY.keys)
        {
            recordY.AddKey(item.time, item.value);
        }
    }

    private void Update()
    {
        if (DebugTool_RePlay)
        {
            DebugTool_RePlay = false;
            OverTime = 0;
        }

        if (DebugTool_PlayStartSoung)
        {
            DebugTool_PlayStartSoung = false;
            _GhostPlayedSoundEffectPlayer.Play();
        }

        if (DebugTool_PlayMovingSoung)
        {
            DebugTool_PlayMovingSoung = false;
            _GhostMovingSoundEffectPlayer.Play();
        }

        if (DebugTool_StopMovingSoung)
        {
            DebugTool_StopMovingSoung = false;
            _GhostMovingSoundEffectPlayer.Stop();
        }

        OverTime = OverTime + (Time.deltaTime * RePlayTimeScale);
        
        transform.position = new Vector3(recordX.Evaluate(OverTime), recordY.Evaluate(OverTime), transform.position.z);

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, -Vector2.up, 0.1f, LayerMask.GetMask("Ground"));
        
        if (lastPos.x != transform.position.x && hits.Length > 0)
        {
            if (!isMoveing)
            {
                _GhostMovingSoundEffectPlayer.Play();
            }
            isMoveing = true;
        }
        else
        {
            if (isMoveing)
            {
                _GhostMovingSoundEffectPlayer.Stop();
            }
            isMoveing = false;
        }

        transform.localScale = new Vector3(lastPos.x > transform.position.x ? -1 : 1, 1, 1);

        lastPos = transform.position;
    }
}
