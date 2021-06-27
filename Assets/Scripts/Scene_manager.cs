using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public void next_scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void first_scene()
    {
        SceneManager.LoadScene(0);
        Destroy(FindObjectOfType<UI>().gameObject);
    }
    public void event_time_up(Time time) { time.event_time_up += next_scene; }
}
