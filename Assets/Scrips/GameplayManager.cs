using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;
    [SerializeField] FalsePopup falsePopup;
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
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UIManager.instance.CreatingKnife();
    }
    private void Update()
    {

    }

    public void OnWin()
    {
        SystemManager.Instance.Stage++;
        CreateBoard();
        UIManager.instance.CreatingKnife();
        Board.transform.position += new Vector3(5, 0);
    }

    public void OnLose()
    {
        falsePopup.gameObject.SetActive(true);
    }
    public void OnContinue()
    {
        if (Board.numberKnife > 0)
        {
            Instantiate(Resources.Load("Knife"));
        }
    }
    void CreateBoard()
    {
        if (Resources.Load("Maps/Map" + SystemManager.Instance.Stage) == null)
        {
            SystemManager.Instance.Stage = 1;
        }
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
