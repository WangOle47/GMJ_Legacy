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
    public static event Action<bool> Oncharacter; 

    public static event Action<string, AudioClip> OnAudioGenerated;//音檔生成 

    //鏡頭事件
    public static event Action<Texture2D> OnImageCaptured;

    //按鈕事件
    public static event Action OnCaptureButtonPressed;

    //遊戲狀態檢測
    public static event Action<string> StatusUpdated;

    public static void CharacterDead(bool dead)
    {
        Oncharacter?.Invoke(dead);
    }







    // 音檔觸發器
    public static void TriggerAudioGenerated(string text, AudioClip audio)
    {
        OnAudioGenerated?.Invoke(text, audio);
    }

    // 相機事件觸發器
    public static void TriggerImageCaptured(Texture2D image)
    {
        OnImageCaptured?.Invoke(image);
    }


    // 按鈕事件觸發器
    public static void TriggerCaptureButtonPressed() //拍照
    {
        OnCaptureButtonPressed?.Invoke();
    }

    public static void CapturePressed()//觸發照相功能
    {
        OnCaptureButtonPressed?.Invoke();
    }

    // 狀態更新事件
    public static void TriggerStatusUpdated(string status)
    {
        StatusUpdated?.Invoke(status);
    }
}

