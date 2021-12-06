using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager
{
    private static SystemManager _instance;
    public static SystemManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private int _stage;
    public int Stage
    {
        get
        {
            if(_stage == 0)
            {
                _stage = PlayerPrefs.GetInt("stage",1);
            }
            return _stage;

        }
        set
        {
            _stage = value;
            PlayerPrefs.SetInt("stage", value);
        }
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnLoad()
    {
        _instance = new SystemManager();
    }

    public SystemManager()
    {

    }
}
