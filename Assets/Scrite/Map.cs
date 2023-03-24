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

        if (player.transform.position.y >= 165)
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
            int[] j = new int[16];
            for (int i = 3; i < 16; i++)
            {
                int randomPos = Random.Range(20, -20);
                for (; randomPos >= j[i - 1] - 7 && randomPos <= j[i - 1] + 7;)
                {
                    randomPos = Random.Range(20, -20);
                }
                j[i] = randomPos;

                poolingFrefab[i].transform.position = new Vector2(randomPos, i * 10);
                poolingFrefab[i].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                //CreatePos(i, out j);
            }
        }
        else
        {
            int[] j = new int[16];
            for (int i = 30; i < 160; i += 10)
            {
                int randomPos = Random.Range(20, -20);
                for (; randomPos >= j[(i / 10) - 1] - 7 && randomPos <= j[(i / 10) - 1] + 7;)
                {
                    randomPos = Random.Range(20, -20);
                }
                j[(i / 10)] = randomPos;

                Vector2 popPos = new Vector2(randomPos, i);
                Quaternion popAngle = Quaternion.Euler(0, 0, Random.Range(0, 360));
                poolingFrefab[i/10] = Instantiate(prefab[Random.Range(0, prefab.Length)], popPos, popAngle);
            }
        }
        firstCreatMap = true;
    }
}
