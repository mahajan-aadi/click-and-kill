using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnner : MonoBehaviour
{
    [SerializeField] Enemy[] enemies;
    [SerializeField] BoxCollider2D BoxCollider2D;
    int len;
    float _x, _y;
    Vector2 _center;
    private void Start()
    {
        assign();
        len = enemies.Length;
        StartCoroutine(spawn());
    }
    void assign()
    {
        _center = BoxCollider2D.GetComponent<Transform>().position;
        _x = BoxCollider2D.size.x;
        _y = BoxCollider2D.size.y;
    }
    IEnumerator spawn()
    {
        Enemy enemy=enemy_choose();
        float __time = enemy.reload_time;
        Vector2 new_pos = position_choose();
        Instantiate(enemy, new_pos, Quaternion.identity);
        yield return new WaitForSeconds(__time);
        StartCoroutine(spawn());
    }
    Enemy enemy_choose()
    {
        return enemies[Random.Range(0, len)];
    }
    Vector2 position_choose()
    {
        Vector2 new_pos = new Vector2(_center.x + Random.Range(-_x / 2, _x / 2),
                                    _center.y + Random.Range(-_y / 2, _y / 2));
        return new_pos;
    }
}
