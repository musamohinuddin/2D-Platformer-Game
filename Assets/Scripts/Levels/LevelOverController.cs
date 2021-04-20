using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    
    //public int buildIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Completed");
            SoundManager.Instance.Play(Sounds.LevelComplete);
            //SceneManager.LoadScene(buildIndex);
            LevelManager.Instance.MarkCurrentLevelComplete();
        } 
    
    }

    
}

