using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallThrow : MonoBehaviour
{
    float flyAngle;

    [Header("VectorArrow")]
    [SerializeField] GameObject vectorArrow;
    [SerializeField] float arrowR;
    [SerializeField] float arrowSpeed;
    float deg;

    bool canThrow = true;

    Rigidbody2D ballRig;

    private void Awake()
    {
        ballRig = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canThrow)
        {
            while (true)
            {
                flyAngle = SetVector();
                if (flyAngle != 0)
                {
                    ballRig.AddForce(new Vector2(-flyAngle, 90 - flyAngle) * 10);
                }
                break;
            }
        }
    }

    float SetVector()
    {
        var rag = Mathf.Deg2Rad * (deg);
        var x = arrowR * Mathf.Sin(rag);
        var y = arrowR * Mathf.Cos(rag);
        vectorArrow.transform.position = transform.position + new Vector3(x, y);
        vectorArrow.transform.rotation = Quaternion.Euler(0, 0, deg * -1);

        if (Input.GetKey(KeyCode.A)) deg -= arrowSpeed / 5;
        if (Input.GetKey(KeyCode.D)) deg += arrowSpeed / 5;

        if (Input.GetKeyDown(KeyCode.Space))
            return vectorArrow.transform.eulerAngles.z;
        else return 0;
    }

    void SetPower()
    {

    }
}
