using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [HideInInspector] public bool usedKnife, missedKnife;
    CuttingBoard cuttingBoard;
    Knife launchedKnife;
    float knifeSpeed;
    Vector3 spinningAngle;
    float boucing;
    private void FixedUpdate()
    {
        transform.position += new Vector3(boucing, knifeSpeed);
        transform.Rotate(spinningAngle);
    }

    private void Update()
    {
        if (!usedKnife)
        {
            if (!missedKnife)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    knifeSpeed = 1;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cuttingBoard = collision.GetComponent<CuttingBoard>();
        launchedKnife = collision.GetComponent<Knife>();

        
        if (cuttingBoard)
        {
            if (missedKnife)
            {
                return;
            }
            else
            {
                if (cuttingBoard.transform.position.y - transform.position.y <= 1.75f)
                {
                    knifeSpeed = 0;
                    transform.SetParent(cuttingBoard.transform.parent);
                    usedKnife = true;
                }
            }
        }
        if (launchedKnife)
        {
            if (launchedKnife.missedKnife)
            {
                return;
            }
            if (launchedKnife.usedKnife)
            {
                return;
            }
            else
            {
                launchedKnife.missedKnife = true;
                if (transform.position.x < launchedKnife.transform.position.x)
                {
                    launchedKnife.boucing = 0.2f;
                    launchedKnife.spinningAngle.z = -30;
                    launchedKnife.knifeSpeed = -0.2f;
                }
                else if (transform.position.x > launchedKnife.transform.position.x)
                {
                    launchedKnife.boucing = -0.2f;
                    launchedKnife.spinningAngle.z = 30;
                    launchedKnife.knifeSpeed = -0.2f;
                }
                else
                {
                    launchedKnife.spinningAngle.z = 30;
                    launchedKnife.knifeSpeed = -0.3f;
                }
            }
        }
    }
}
