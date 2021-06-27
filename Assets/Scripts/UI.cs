using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Text score_text, life_text;
    const string score_string = "Score: ";
    const string life_string = "Lives left: ";
    int score = 0, lives = 3;
    private void Awake()
    {
        if (FindObjectsOfType<UI>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else { DontDestroyOnLoad(this.gameObject); }
    }
    void change_level()
    {
        lives = 3;
        life_text.text = life_string + lives.ToString();
    }

    public void event_enemy_dead(Enemy enemy) { enemy.event_enemy_dead += increase_score; }
    public void event_enemy_time_up(Enemy enemy) { enemy.event_enemy_time_up += decrease_lives; }
    public void event_time_up(Time time) { time.event_time_up += change_level; }

    void increase_score(int value)
    {
        score += value;
        score_text.text = score_string + score.ToString();
    }
    void decrease_lives() 
    {
        if (lives == 0) { FindObjectOfType<Scene_manager>().first_scene();return; }
        lives--;
        life_text.text = life_string + lives.ToString();
    }
}
