using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Knife launchedKnife;
    public float knifeSpeed;
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, knifeSpeed);
        if (Input.GetMouseButtonDown(0))
        {
            knifeSpeed = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        launchedKnife = collision.collider.GetComponent<Knife>();
        if (launchedKnife)
        {

        }
    }
}
