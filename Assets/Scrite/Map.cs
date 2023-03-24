using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject player;

    [SerializeField] int gap;
    [SerializeField] GameObject[] prefab;
    GameObject[] poolingFrefab = new GameObject[16];

    TrailRenderer trailRenderer;

    bool firstCreatMap;
    int stage = 0;

    void Awake()
    {
        trailRenderer = GameObject.FindWithTag("Ball").GetComponent<TrailRenderer>();

        CreateMap();
        firstCreatMap = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ground.SetActive(false);
        if (player.transform.position.y >= 165 + (stage * 145))
        {
            ++stage;
            CreateMap();

            transform.position = new Vector2(0, stage * 145);
        }
    }

    void CreateMap()
    {
        if (firstCreatMap)
        {
            int[] j = new int[16];
            for (int i = 3; i < 16; i++)
            {
                int randomPos = Random.Range(20, -20);
                for (; randomPos >= j[i - 1] - gap && randomPos <= j[i - 1] + gap;)
                {
                    randomPos = Random.Range(20, -20);
                }
                j[i] = randomPos;

                poolingFrefab[i].transform.position = new Vector2(randomPos, (i * 10) + (stage * 145));
                poolingFrefab[i].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            }
        }
        else
        {
            int[] j = new int[16];
            for (int i = 30; i < 160; i += 10)
            {
                int randomPos = Random.Range(20, -20);
                for (; randomPos >= j[(i / 10) - 1] - gap && randomPos <= j[(i / 10) - 1] + gap;)
                {
                    randomPos = Random.Range(20, -20);
                }
                j[(i / 10)] = randomPos;

                Vector2 popPos = new Vector2(randomPos, i);
                Quaternion popAngle = Quaternion.Euler(0, 0, Random.Range(0, 360));
                poolingFrefab[i/10] = Instantiate(prefab[Random.Range(0, prefab.Length)], popPos, popAngle);
            }
        }
    }
}
