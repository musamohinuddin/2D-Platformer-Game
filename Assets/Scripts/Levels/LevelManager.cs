using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string[] Levels;

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

    private void Start()
    {
        if(GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        //set level status to complete
        SetLevelStatus(currentScene.name, LevelStatus.Completed);

        //Unlock next level
        int currentSceneIndex = Array.FindIndex(Levels, Levels => Levels == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
            SceneManager.LoadScene(6);
        } else
        {
            Debug.Log("Congrats you have completed all levels.");
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
