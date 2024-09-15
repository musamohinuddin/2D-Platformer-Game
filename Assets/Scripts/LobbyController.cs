using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button button;
    public int buildIndex;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnButtonClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        Debug.Log("Button Clicked");
        //SceneManager.GetSceneByBuildIndex(buildIndex);
        SceneManager.LoadScene(buildIndex);
    }
}
