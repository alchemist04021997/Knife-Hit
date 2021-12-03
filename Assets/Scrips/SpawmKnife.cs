using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmKnife : MonoBehaviour
{
    Knife knife;
    GameObject nextKnife;
    private void Start()
    {
        nextKnife = (GameObject)Instantiate(Resources.Load("Knife"));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        knife = collision.GetComponent<Knife>();
        if (knife)
        {
            if (!knife.missedKnife)
            {
                GameManager.Instance.numberKnife--;
                UIManager.instance.ChangeKnifeColorToBlack(GameManager.Instance.numberKnife);
                if (GameManager.Instance.numberKnife > 0)
                {
                    nextKnife = (GameObject)Instantiate(Resources.Load("Knife"));
                }
            }
        }
    }
}
