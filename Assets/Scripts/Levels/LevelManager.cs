using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public LevelStatus GetLevelStatus(string Level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(Level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string Level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(Level, (int)levelStatus);
    }
}
