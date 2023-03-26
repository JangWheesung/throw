using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowItem : MonoBehaviour
{
    void Update()
    {
        Collider2D range = Physics2D.OverlapCircle(transform.position, 1, LayerMask.GetMask("Ball"));
        if (range)
        {
            gameObject.SetActive(false);
        }
    }
}
