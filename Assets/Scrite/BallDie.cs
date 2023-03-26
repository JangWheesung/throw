using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class BallDie : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] ParticleSystem particle;
    [SerializeField] GameObject arrow;

    new Rigidbody2D rigidbody2D;
    new Collider2D collider2D;
    SpriteRenderer spriteRenderer;
    TrailRenderer trailRenderer;

    Map map;

    public bool die;

    private void Awake()
    {
        Time.timeScale = 1;
        image.DOFade(0, 1);

        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        collider2D = gameObject.GetComponent<Collider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        trailRenderer = gameObject.GetComponent<TrailRenderer>();

        map = FindAnyObjectByType<Map>();
    }

    public void Die()
    {
        die = true;

        PlayerPrefs.SetFloat("score", map.score);
        if(map.score > PlayerPrefs.GetFloat("best"))
            PlayerPrefs.SetFloat("best", map.score);

        image.DOFade(1, 1).OnComplete(() => { SceneManager.LoadScene("Play"); });
    }

    void DieProcess()
    {
        Time.timeScale = 0.5f;
        BallThrow.instance.enabled = false;
        arrow.SetActive(false);
        rigidbody2D.gravityScale = 0;
        collider2D.enabled = false;
        spriteRenderer.enabled = false;
        trailRenderer.emitting = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.transform.CompareTag("Object"))
        {
            Instantiate(particle, transform);
            particle.Play();
            Invoke("Die", 0.2f);
            DieProcess();
        }
    }
}
