using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartbeatManager : MonoBehaviour
{
    public GameObject heartBeat;
    private LineRenderer lineRenderer;
    private int lengthOfLineRenderer;

    public Image health;
    private RectTransform transformOfHealth;
    public float amp;
    public float freq;
    //good freqs are:
    //2.59, 3.28, 0.77, -2.16, -1.8, -1.56, -0.24, -0.08
    //norm at 0.55
    void Start()
    {
        transformOfHealth = health.GetComponent<RectTransform>();

        lineRenderer = heartBeat.GetComponent<LineRenderer>();
        lengthOfLineRenderer = lineRenderer.positionCount;
       // print(lengthOfLineRenderer);
        
        
    }

    private void Update()
    {
        
        var t = Time.time;
        for (int i = 0; i < lengthOfLineRenderer; i++)
        {
            Vector3 k = lineRenderer.GetPosition(i);
            lineRenderer.SetPosition(i, new Vector3( k.x, Mathf.Sin((i + t) * freq)* amp + 3, 0.0f));
        }
    }

    public void ChangeHeartbeat(float freqInput)
    {
        freq = freqInput;
    }

    public void DecreaseHealth()
    {
        
    }
}
