using UnityEngine;
using System;
using System.Linq;

public class TimeManager : MonoBehaviour
{
    private ITimeListener[] timeListeners;

    [SerializeField] private float daytime = 20f, nightTime = 5f;

    public bool day = true;
    private float timer = 0f;

    public float timeScale = 1f;

    private void Awake()
    {
        timeListeners = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)
            .OfType<ITimeListener>()
            .ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;


        if (day)
        {
            if (Time.time - timer >= daytime)
            {
                ChangeToNight();
            }
        }
        else
        {
            if (Time.time - timer >= nightTime)
            {
                ChangeToDay();
            }
        }
    }

    private void ChangeToDay()
    {
        day = true;

        timer = Time.time;

        foreach (var t in timeListeners)
        {
            t.ChangeToDay();
        }
    }

    private void ChangeToNight()
    {
        day = false;

        timer = Time.time;

        foreach (var t in timeListeners)
        {
            t.ChangeToNight();
        }
    }
}
