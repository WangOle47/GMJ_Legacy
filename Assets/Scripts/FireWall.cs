using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    public GameObject[] fires = new GameObject[4];
    public GameObject Startfire;
    public float Time = 3f;
    public float FireUPTime = 3f;
    private bool state = false;

    public void FixedUpdate()
    {
        if(!state) StartCoroutine(FireUP());
    }

    IEnumerator FireUP()
    {
        state = !state;
        Startfire.SetActive(true);
        yield return new WaitForSeconds(1f);
        Startfire.SetActive(false);
        for (int i = 0; i < fires.Length;i++)
        {
            fires[i].SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(FireUPTime);
        for (int i = fires.Length; i > 0; i--)
        {
            fires[i-1].SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(Time);
        state = !state;
    }
}
