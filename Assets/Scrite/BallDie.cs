using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallDie : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;

    public void Die()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.transform.CompareTag("Object"))
        {
            Instantiate(particle, transform);
            particle.Play();
            Invoke("Die", 1f);
        }
    }
}
