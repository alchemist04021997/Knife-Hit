using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    Knife knife;
    private void Start()
    {

    }
    private void FixedUpdate()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        knife = collision.collider.GetComponent<Knife>();
        if (knife)
        {

        }
    }
}
