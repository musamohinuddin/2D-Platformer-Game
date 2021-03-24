using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Awake()
	{
		Debug.Log("Player controller awake");
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collision: " + collision.gameObject.name);
	}
	
	
	
	
	
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
