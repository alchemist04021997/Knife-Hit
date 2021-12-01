using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    Knife knife;
    Vector3 spinningAngle, originalPos;
    public float spinningSpeed;
    private void Start()
    {
        originalPos = transform.position;
    }
    private void FixedUpdate()
    {
        spinningAngle.z = spinningSpeed;
        transform.Rotate(spinningAngle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        knife = collision.collider.GetComponent<Knife>();
        if (knife)
        {
            StartCoroutine(Boucing());
            knife.knifeSpeed = 0;
            knife.transform.SetParent(this.transform);
        }
    }
    IEnumerator Boucing()
    {
        while (true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 5 * Time.deltaTime);
            if (transform.position.y - originalPos.y > 0.3f)
            {
                break;
            }
            yield return null;
        }
        while (true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 5 * Time.deltaTime);
            if (transform.position.y < originalPos.y)
            {
                transform.position = originalPos;
                break;
            }
            yield return null;
        }
    }
}
