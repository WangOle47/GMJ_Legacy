using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_HP : MonoBehaviour
{
    public GameObject Inputmanager;
    public float HP = 100;
    private Vector2 revival_point;
    private Vector2 Dead_point;
    private Vector2 First_point;

    private void OnEnable()
    {
        EventSystem.OnDamage += dead;
        EventSystem.OnFlagGenerated += revival_point_set;
    }
    private void OnDisable()
    {
        EventSystem.OnDamage -= dead;
        EventSystem.OnFlagGenerated -= revival_point_set;
    }
    private void Start()
    {
        First_point = transform.position;
        revival_point = First_point;
    }
    private void revival_point_set(Vector2 vector)
    {
        revival_point = transform.position;
    }

    public void dead(string type)
    {
        if (type == "ReStart")//重新開始
        {
            transform.position = First_point;
            return;
        }
        Inputmanager.SetActive(false);
        HP = 0;
        Dead_point = transform.position;
        EventSystem.CharacterDead(Dead_point);
        if(type == "Collision")//會留遺物
        {

        }
        else if(type == "Trigger")//不會留遺物
        {

        }
        else if (type == "Self_destruct")//自爆
        {


        }
        StartCoroutine(revival());
    }

    IEnumerator revival()
    {
        yield return new WaitForSeconds(1f);
        HP = 100;
        transform.position = revival_point;
        Inputmanager.SetActive(true);
    }

}
