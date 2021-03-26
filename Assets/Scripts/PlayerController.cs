using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
	public float speed;
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
		//Code to make Run Animation
		float horizontal = Input.GetAxisRaw("Horizontal");
		MoveCharacter(horizontal);
		PlayMovementAnimation(horizontal);
	}

	//Function to make Player Movement
	private void MoveCharacter(float horizontal) 
	{
		Vector3 position = transform.position;
		position.x += horizontal * speed * Time.deltaTime;
		transform.position = position;
	}

	private void PlayMovementAnimation(float horizontal) 
	{
		animator.SetFloat("Speed", Mathf.Abs(horizontal));
		Vector3 Scale = transform.localScale;
		if (horizontal < 0)
		{
			Scale.x = -1f * Mathf.Abs(Scale.x);
			
		}
		else if (horizontal > 0)
		{
			Scale.x = Mathf.Abs(Scale.x);
			
		}
		transform.localScale = Scale;

		//Code to make Crouch animation
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{

			animator.SetBool("Crouch", true);
		}
		else if (Input.GetKeyUp(KeyCode.LeftControl))
		{

			animator.SetBool("Crouch", false);
		}

		//Code to make Jump animation
		float jump = Input.GetAxisRaw("Vertical");
		if (jump > 0)
		{
			animator.SetBool("Jump", true);
		}
		else if (jump < 0)
		{
			animator.SetBool("Jump", false);
		}
	}
		
		
   
}
