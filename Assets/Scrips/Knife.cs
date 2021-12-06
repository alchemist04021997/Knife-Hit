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
    float gravity;
    public bool IsUseGravity
    {
        get
        {
            return gravity > 0;
        }
        set
        {
            gravity = value ? -0.01f : 0;
        }
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(boucing, knifeSpeed);
        knifeSpeed += gravity;
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
                knifeSpeed = 0;
                transform.position = new Vector3(0, -1.5f) + cuttingBoard.transform.position;
                transform.SetParent(cuttingBoard.transform.parent);
                usedKnife = true;
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
                launchedKnife.IsUseGravity = true;
                if (transform.position.x < launchedKnife.transform.position.x)
                {
                    launchedKnife.boucing = 0.1f;
                    launchedKnife.spinningAngle.z = -30;
                    launchedKnife.knifeSpeed = -0.1f;
                }
                else if (transform.position.x > launchedKnife.transform.position.x)
                {
                    launchedKnife.boucing = -0.1f;
                    launchedKnife.spinningAngle.z = 30;
                    launchedKnife.knifeSpeed = -0.1f;
                }
                else
                {
                    launchedKnife.spinningAngle.z = 30;
                    launchedKnife.knifeSpeed = -0.2f;
                }
            }
        }
    }
}
