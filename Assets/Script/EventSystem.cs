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
    public static event Action OncharacterDead;

    //�ͦ��X�m
    public static event Action<Vector2> OnFlagGenerated;

    //����
    public static event Action<string> OnDamage;


    public static event Action<string, AudioClip> OnAudioGenerated;//���ɥͦ� 

    //�C�����A�˴�
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




    // ����Ĳ�o��
    public static void TriggerAudioGenerated(string text, AudioClip audio)
    {
        OnAudioGenerated?.Invoke(text, audio);
    }

    // ���A��s�ƥ�
    public static void TriggerStatusUpdated(string status)
    {
        StatusUpdated?.Invoke(status);
    }
}

