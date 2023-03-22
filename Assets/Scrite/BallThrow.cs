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

    bool canThrow;

    private void Awake()
    {
        
    }

    void Update()
    {
        while (true)
        {
            flyAngle = SetVector();
            if (flyAngle != 0) Debug.Log(flyAngle); break;
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
