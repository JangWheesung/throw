using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject[] patten;
    [SerializeField] GameObject player;

    void Awake()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ground.SetActive(false);
        if (player.transform.position.y >= 160)
        {
            player.transform.position = new Vector2(player.transform.position.x, 11f);
        }
    }
}
