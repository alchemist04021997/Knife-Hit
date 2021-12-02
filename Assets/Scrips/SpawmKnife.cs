using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmKnife : MonoBehaviour
{
    Knife knife;
    GameObject nextKnife;
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        knife = collision.GetComponent<Knife>();
        if (knife)
        {
            if(!knife.falseKnife)
                nextKnife = (GameObject)Instantiate(Resources.Load("Knife"));
        }
    }
}
