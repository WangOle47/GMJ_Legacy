using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
���Ѩt�Τ��Ҧ��ƥ�PĲ�o�覡
�n�X�R��L�ƥ󳣥Ѧ��h���K�[
 */
public static class EventSystem
{
    //���⪬�A
    public static event Action<bool> Oncharacter; 

    public static event Action<string, AudioClip> OnAudioGenerated;//���ɥͦ� 

    //���Y�ƥ�
    public static event Action<Texture2D> OnImageCaptured;

    //���s�ƥ�
    public static event Action OnCaptureButtonPressed;

    //�C�����A�˴�
    public static event Action<string> StatusUpdated;

    public static void CharacterDead(bool dead)
    {
        Oncharacter?.Invoke(dead);
    }







    // ����Ĳ�o��
    public static void TriggerAudioGenerated(string text, AudioClip audio)
    {
        OnAudioGenerated?.Invoke(text, audio);
    }

    // �۾��ƥ�Ĳ�o��
    public static void TriggerImageCaptured(Texture2D image)
    {
        OnImageCaptured?.Invoke(image);
    }


    // ���s�ƥ�Ĳ�o��
    public static void TriggerCaptureButtonPressed() //���
    {
        OnCaptureButtonPressed?.Invoke();
    }

    public static void CapturePressed()//Ĳ�o�Ӭۥ\��
    {
        OnCaptureButtonPressed?.Invoke();
    }

    // ���A��s�ƥ�
    public static void TriggerStatusUpdated(string status)
    {
        StatusUpdated?.Invoke(status);
    }
}

