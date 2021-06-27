using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time : MonoBehaviour
{
    [SerializeField] int _time;
    Text time_text;
    public event Action event_time_up; 
    private void Start()
    {
        time_text = GetComponent<Text>();
        update_time();
        StartCoroutine(start_time());
        change_level();
    }

    private void change_level()
    {
        FindObjectOfType<UI>().event_time_up(this);
        FindObjectOfType<Scene_manager>().event_time_up(this);
    }

    IEnumerator start_time()
    {
        if (_time == 0)
        {
            time_end();
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        _time--;
        update_time();
        StartCoroutine(start_time());
    }

    private void time_end()
    {
        event_time_up?.Invoke();
    }

    private void update_time()
    {
        int time_min = (int)Mathf.Floor(_time / 60);
        int time_sec = _time % 60;
        time_text.text = time_min + ":" + time_sec;
    }
}
