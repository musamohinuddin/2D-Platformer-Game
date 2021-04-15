using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
	private void Awake()
	{
		Debug.Log("Player controller awake");
	}
	
	
	  
     
	
	//private void OnCollisionEnter2D(Collision2D collision)
	//{
	//	Debug.Log("Collision: " + collision.gameObject.name);
	//}
		
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float speed =Input.GetAxisRaw("Horizontal");
		animator.SetFloat("Speed", Mathf.Abs(speed));
		Vector3 Scale = transform.localScale;
		if(speed < 0)
		{
			Scale.x = -1f * Mathf.Abs(Scale.x);
		} else if(speed > 0)
		{
			Scale.x = Mathf.Abs(Scale.x);
		}
		transform.localScale=Scale;
			
		//Code to make Crouch animation
		if(Input.GetKeyDown(KeyCode.LeftControl))
		{
			 //crouch = true;
             animator.SetBool("Crouch", true);
		} else if(Input.GetKeyUp(KeyCode.LeftControl)) 
		{
			//crouch = false;
             animator.SetBool("Crouch", false);
		}
	
		//Code to make Jump animation
		float jump =Input.GetAxisRaw("Vertical");
		if(jump > 0) 
		{
			animator.SetBool("Jump", true);
		} else if(jump < 0) 
		{
			animator.SetBool("Jump", false);
		}
		
    }
}
