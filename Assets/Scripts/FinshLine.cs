using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class FinshLine : MonoBehaviour
{
    private LayerMask playerLayer;
    public GameObject FinishPanel;
    public UnityEngine.UI.Text Time_text;
    public UnityEngine.UI.Text Finish_Time_text;
    public float StartTime = 0;


    float CurrentTime => Time.time - StartTime;

    private void Start()
    {     
        playerLayer = LayerMask.NameToLayer("Player");
        StartTime = Time.time;
    }
    private void Update()
    {
        var timeSpan = TimeSpan.FromSeconds(CurrentTime);
        Time_text.text = timeSpan.ToString(@"mm\:ss");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            var timeSpan = TimeSpan.FromSeconds(CurrentTime);
            Finish_Time_text.text = timeSpan.ToString(@"mm\:ss");
            FinishPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            FinishPanel.SetActive(false);
            StartTime = Time.time;
        }
    }
}
