using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    //public int buildIndex;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(Restart);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Restart()
    {
        Debug.Log("Reloading Scene...");
        //SceneManager.GetSceneByBuildIndex(buildIndex);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }      
}
