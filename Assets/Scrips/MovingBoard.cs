using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBoard : MonoBehaviour
{
    public int numberKnife;
    public float spinningSpeed, accelerationSpeed;
    [Range(0, 50)]
    public float maxSpeed;
    public ControlBoard[] controlBoards;
    int controlBoardsCount = 0;
    float time;
    Knife knife;
    public bool onWinStage;
    bool moveLeft = true;

    Vector3 spinningAngle, originalPos;
    private void Start()
    {
        Instantiate(Resources.Load("Knife"));
        originalPos = new Vector3(0, 2);
        time = Time.time;
    }
    private void FixedUpdate()
    {
        if (moveLeft)
        {
            transform.position += new Vector3(-1, 0);
            if (transform.position.x <= 0)
            {
                moveLeft = false;
                transform.position = new Vector3(0, transform.position.y);
            }
        }
        if (onWinStage)
        {
            Destroy(gameObject, 1);
            transform.position += new Vector3(-1, 0);
        }
        if (controlBoards.Length > 0)
        {
            if (controlBoardsCount >= controlBoards.Length)
            {
                controlBoardsCount = 0;
            }
            accelerationSpeed += controlBoards[controlBoardsCount].accelerationOfAcceleration;
            if (accelerationSpeed >= controlBoards[controlBoardsCount].maxAccelerationOfAcceleration)
            {
                accelerationSpeed = controlBoards[controlBoardsCount].maxAccelerationOfAcceleration;
            }
            else if (-accelerationSpeed >= controlBoards[controlBoardsCount].maxAccelerationOfAcceleration)
            {
                accelerationSpeed = -controlBoards[controlBoardsCount].maxAccelerationOfAcceleration;
            }
            if (Time.time - time > controlBoards[controlBoardsCount].time)
            {
                controlBoardsCount++;
                time = Time.time;
            }
        }

        spinningAngle.z = spinningSpeed;
        spinningSpeed += accelerationSpeed;
        transform.Rotate(spinningAngle);
        if (spinningSpeed >= maxSpeed)
        {
            spinningSpeed = maxSpeed;
        }
        else if (-spinningSpeed >= maxSpeed) 
        {
            spinningSpeed = -maxSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        knife = collision.GetComponent<Knife>();
        if (knife)
        {
            if (!knife.missedKnife)
            {
                GameplayManager.Instance.Board.numberKnife--;
                UIManager.instance.ChangeKnifeColorToBlack(GameplayManager.Instance.Board.numberKnife);
                if (GameplayManager.Instance.Board.numberKnife > 0)
                {
                    Instantiate(Resources.Load("Knife"));
                }
                else
                {
                    GameplayManager.Instance.OnWin();
                    onWinStage = true;
                }
            }
            if (!onWinStage)
            {
                StartCoroutine(Boucing());
            }
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
