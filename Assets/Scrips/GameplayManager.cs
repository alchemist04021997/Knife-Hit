using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    private MovingBoard _board;
    public MovingBoard Board 
    { 
        get
        {
            if(!_board)
            {
                CreateBoard();
            }
            return _board;
        }
    }
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
    }
    private void Update()
    {

    }

    public void OnWin()
    {
        SystemManager.Instance.Stage++;
        CreateBoard();
        Board.transform.position += new Vector3(5, 0);
    }

    public void OnLose()
    {

    }

    void CreateBoard()
    {
        _board = ((GameObject)Instantiate(Resources.Load("Maps/Map" + SystemManager.Instance.Stage))).GetComponent<MovingBoard>();
    }
}

[System.Serializable]
public struct ControlBoard
{
    public float time;
    public float accelerationOfAcceleration;
    [Range(0, 1)]
    public float maxAccelerationOfAcceleration;
}
