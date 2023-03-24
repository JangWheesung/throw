using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] prefab;
    GameObject[] poolingFrefab = new GameObject[16];
    bool firstCreatMap;

    void Awake()
    {
        CreateMap();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ground.SetActive(false);

        if (player.transform.position.y >= 160)
        {
            CreateMap();

            player.transform.position = new Vector2(player.transform.position.x, 11f);
        }
    }

    void CreateMap()
    {
        //x: -20, 20
        //y: -70, 60
        if (firstCreatMap)
        {
            //InitObject();

            for (int i = 3; i < 16; i++)
            {
                poolingFrefab[i].transform.position = new Vector2(Random.Range(20, -20), i * 10);
                poolingFrefab[i].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            }
        }
        else
        {
            for (int i = 30; i < 160; i += 10)
            {
                Vector2 popPos = new Vector2(Random.Range(20, -20), i);
                Quaternion popAngle = Quaternion.Euler(0, 0, Random.Range(0, 360));
                poolingFrefab[i/10] = Instantiate(prefab[Random.Range(0, prefab.Length)], popPos, popAngle);
            }
        }
        firstCreatMap = true;
    }

    void InitObject()
    {
        GameObject[] clone = new GameObject[16];
        for (int i = 3; i < 16; i++)
        {
            poolingFrefab[i] = clone[Random.Range(3, 15)];
        }
    }
}
