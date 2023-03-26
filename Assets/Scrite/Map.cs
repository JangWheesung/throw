using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Map : MonoBehaviour
{
    [Header("UiText")]
    [SerializeField] Text nameT;
    [SerializeField] Text pressT;
    [SerializeField] Text scoreT;
    [SerializeField] Text bestT;

    [Header("Object")]
    [SerializeField] GameObject ground;
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] prefab;
    GameObject[] poolingFrefab = new GameObject[16];

    [Header("Value")]
    [SerializeField] int gap;

    Camera camera;
    BallDie ballDie;

    bool firstCreatMap;
    int stage = 0;
    public float score;

    void Awake()
    {
        ballDie = FindObjectOfType<BallDie>();

        CreateMap();
        firstCreatMap = true;

        camera = Camera.main;
        camera.backgroundColor = Random.ColorHSV(0, 1, 0.4f, 0.6f, 0.9f, 1f);

        scoreT.text = $"Score {Mathf.Floor(PlayerPrefs.GetFloat("score"))}";
        bestT.text = $"Best {Mathf.Floor(PlayerPrefs.GetFloat("best"))}";

        nameT.rectTransform.DOMoveY(700, 1).SetEase(Ease.OutCubic)
            .OnComplete(() =>
            {
                pressT.DOFade(1, 1);
            });
    }
    
    void Update()
    {
        if (score < player.transform.position.y && !ballDie.die)
            score = player.transform.position.y;
        scoreT.text = $"Score {Mathf.Floor(score)}";


        if (Input.GetKeyDown(KeyCode.Space))
        {
            nameT.DOFade(0, 1);
            pressT.DOFade(0, 1);
            bestT.DOFade(0, 1);
            scoreT.rectTransform.DOMove(new Vector2(200, 1000), 1).SetEase(Ease.OutCubic);
            ground.SetActive(false);
        }

        MapPos();
    }

    void MapPos()
    {
        if (player.transform.position.y >= 165 + (stage * 145))
        {
            ++stage;
            CreateMap();

            transform.position = new Vector2(0, stage * 145);
        }

        if (player.transform.position.y < (stage * 145))
        {
            BallThrow.instance.enabled = false;
            ballDie.Die();
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
                poolingFrefab[i].GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 0.5f, 0.9f, 0.9f, 1f);
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
                int randomObject = Random.Range(0, prefab.Length);
                prefab[randomObject].GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 0.5f, 0.9f, 0.9f, 1f);
                poolingFrefab[i / 10] = Instantiate(prefab[randomObject], popPos, popAngle);
                poolingFrefab[i / 10] = Instantiate(prefab[randomObject], popPos, popAngle);
            }
        }
    }
}
