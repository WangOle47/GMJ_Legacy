using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    AnimationCurve recordX = new AnimationCurve();
    AnimationCurve recordY = new AnimationCurve();
    float RePlayTimeScale = 1;
    float OverTime = 0;

    public bool DebugTool_RePlay = false;

    public void ToDestory()
    {
        Destroy(gameObject);
    }

    public void StartPlay(AnimationCurve setRecordX, AnimationCurve setRecordY, float setRePlayTimeScale)
    {
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
        OverTime = OverTime + (Time.deltaTime * RePlayTimeScale);
        transform.position = new Vector3(recordX.Evaluate(OverTime), recordY.Evaluate(OverTime), transform.position.z);
    }
}
