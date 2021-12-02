using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [HideInInspector] public bool usedKnife, falseKnife;
    CuttingBoard cuttingBoard;
    Knife launchedKnife;
    float knifeSpeed;
    Vector3 spinningAngle;
    float boucing;
    private void FixedUpdate()
    {
        transform.position += new Vector3(boucing, knifeSpeed);
        transform.Rotate(spinningAngle);
        if (falseKnife)
        {
        }

        if (!usedKnife)
        {
            if (Input.GetMouseButtonDown(0))
            {
                knifeSpeed = 1;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cuttingBoard = collision.GetComponent<CuttingBoard>();
        launchedKnife = collision.GetComponent<Knife>();

        
        if (cuttingBoard)
        {
            if (falseKnife)
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
            if (launchedKnife.falseKnife)
            {
                return;
            }
            if (launchedKnife.usedKnife)
            {
                return;
            }
            else
            {
                launchedKnife.falseKnife = true;
                if (transform.position.x < launchedKnife.transform.position.x)
                {
                    launchedKnife.boucing = 1;
                    launchedKnife.spinningAngle.z = -30;
                    launchedKnife.knifeSpeed = -1;
                }
                else if (transform.position.x > launchedKnife.transform.position.x)
                {
                    launchedKnife.boucing = -1;
                    launchedKnife.spinningAngle.z = 30;
                    launchedKnife.knifeSpeed = -1;
                }
                else
                {
                    launchedKnife.spinningAngle.z = 30;
                    launchedKnife.knifeSpeed = -1;
                }
            }
        }
    }
}
