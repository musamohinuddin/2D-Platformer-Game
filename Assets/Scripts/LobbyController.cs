using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button button;
    //public int buildIndex;
    public GameObject LevelSelection;

    // Start is called before the first frame update
    private void Awake()
    {
        button.onClick.AddListener(PlayGame);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    private void PlayGame()
    {
        LevelSelection.SetActive(true);
    }
}
