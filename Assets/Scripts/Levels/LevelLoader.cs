using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;


    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        if(LevelName == "LobbyScene")
        {
            SceneManager.LoadScene(LevelName);
        }
        else
        {
            LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
            switch (levelStatus)
            {
                case LevelStatus.Locked:
                    Debug.Log("Can't play this level till you unlock it");
                    SoundManager.Instance.Play(Sounds.ButtonClick);
                    break;
                case LevelStatus.Unlocked:
                    SceneManager.LoadScene(LevelName);
                    SoundManager.Instance.Play(Sounds.ButtonClick);
                    break;
                case LevelStatus.Completed:
                    SceneManager.LoadScene(LevelName);
                    SoundManager.Instance.Play(Sounds.ButtonClick);
                    break;
            }
        }


        
    }
}
