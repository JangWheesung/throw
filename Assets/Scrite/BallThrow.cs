using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallThrow : MonoBehaviour
{
    [Header("VectorArrow")]
    [SerializeField] GameObject vectorArrow;
    [SerializeField] float arrowR;
    [SerializeField] float arrowSpeed;

    float deg;

    private void Awake()
    {
        
    }

    void Update()
    {
        SetVector();
    }

    void SetVector()
    {
        deg += Time.deltaTime * arrowSpeed;
        var rag = Mathf.Deg2Rad * (deg);
        Debug.Log(rag);
        var x = arrowR * Mathf.Sin(rag);
        var y = arrowR * Mathf.Cos(rag);
        vectorArrow.transform.position = transform.position + new Vector3(x, y);
        vectorArrow.transform.rotation = Quaternion.Euler(0, 0, deg * -1);

        if (Input.GetKey(KeyCode.A)) Debug.Log(333); deg -= Time.deltaTime * arrowSpeed;
        if (Input.GetKey(KeyCode.D)) deg += Time.deltaTime * arrowSpeed;
    }

    void SetPower()
    {

    }
}
