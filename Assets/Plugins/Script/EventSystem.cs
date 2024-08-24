using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
提供系統中所有事件與觸發方式
要擴充其他事件都由此去做添加
 */
public static class EventSystem
{
    //角色狀態
    public static event Action OncharacterDead;

    //生成旗幟
    public static event Action<Vector2> OnFlagGenerated;

    //受傷
    public static event Action<string> OnDamage;


    public static event Action<string, AudioClip> OnAudioGenerated;//音檔生成 

    //遊戲狀態檢測
    public static event Action<string> StatusUpdated;


    public static void CharacterDead()
    {
        OncharacterDead?.Invoke();
    }
    public static void FlagGenerated(Vector2 vector2)
    {
        OnFlagGenerated?.Invoke(vector2);
    }
    public static void Damage(string type)
    {
        OnDamage?.Invoke(type);
    }




    // 音檔觸發器
    public static void TriggerAudioGenerated(string text, AudioClip audio)
    {
        OnAudioGenerated?.Invoke(text, audio);
    }

    // 狀態更新事件
    public static void TriggerStatusUpdated(string status)
    {
        StatusUpdated?.Invoke(status);
    }
}

