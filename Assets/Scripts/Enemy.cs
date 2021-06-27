using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public event Action<int> event_enemy_dead;
    public event Action event_enemy_time_up;
    [SerializeField] float waiting_time, dead_time = 0.2f;
    [SerializeField] int score = 1, lives = 1;
    [SerializeField] Sprite dead,time_over;
    [SerializeField] public float reload_time = 0.25f;
    public virtual void Start()
    {
        UI ui = FindObjectOfType<UI>();
        ui.event_enemy_time_up(this);
        ui.event_enemy_dead(this);
        StartCoroutine(waiting());
    }
     IEnumerator waiting()
    {
        //this.gameObject.gameObject.GetComponent<SpriteRenderer>().sprite = time_over;
        yield return new WaitForSeconds(waiting_time);
        extra_features();
        yield return new WaitForSeconds(1f);
        event_enemy_time_up?.Invoke();
        Destroy(this.gameObject);
    }
    IEnumerator dead_timing()
    {
        yield return new WaitForSeconds(dead_time);
        event_enemy_dead?.Invoke(score);
        Destroy(this.gameObject);
    }
    public virtual void OnMouseDown()
    {
        lives--;
        if (lives == 0) { enemy_dead(); }
    }

    private void enemy_dead()
    {
        //this.gameObject.gameObject.GetComponent<SpriteRenderer>().sprite = dead;
        StartCoroutine(dead_timing());
    }
    public abstract void extra_features();
}
