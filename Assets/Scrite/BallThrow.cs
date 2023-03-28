using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallThrow : MonoBehaviour
{
    public static BallThrow instance;

    [Header("Throw")]
    [SerializeField] float throwSpeed;
    Rigidbody2D ballRig;
    private float flyAngle;

    [Header("VectorArrow")]
    [SerializeField] GameObject vectorArrow;
    [SerializeField] float arrowR;
    [SerializeField] float arrowSpeed;
    private float deg;

    [Header("Audio")]
    [SerializeField] AudioSource jumpSouce;

    private void Awake()
    {
        instance = this;

        ballRig = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Throwing();
    }

    void Throwing()
    {
        while (true)
        {
            flyAngle = SetVector();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpSouce.Play();

                ballRig.velocity = new Vector2(0, 0);
                ballRig.AddForce(new Vector2(-flyAngle, 90 - Mathf.Abs(flyAngle)) * throwSpeed);
            }
            break;
        }
    }

    float SetVector()
    {
        var rag = Mathf.Deg2Rad * (deg);
        var x = arrowR * Mathf.Sin(rag);
        var y = arrowR * Mathf.Cos(rag);
        vectorArrow.transform.position = transform.position + new Vector3(x, y);
        vectorArrow.transform.rotation = Quaternion.Euler(0, 0, deg * -1);
        
        if (Input.GetKey(KeyCode.A) && deg > -89f) deg -= arrowSpeed;
        if (Input.GetKey(KeyCode.D) && deg < 89f) deg += arrowSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float outAngle = vectorArrow.transform.eulerAngles.z;
            if (outAngle > 90) return -(360f - outAngle);
            else return outAngle;
        }
        else return 0;
    }
}
