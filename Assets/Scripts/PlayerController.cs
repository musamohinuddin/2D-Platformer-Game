using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public Animator animator;
	public float speed;
	public float jump;
	public int buildIndex;

	private Rigidbody2D rb2d;
	private BoxCollider2D PlayerCollider;
	private bool isGrounded = true;
	

	private void Awake()
	{
		Debug.Log("Player controller awake");
		rb2d = gameObject.GetComponent<Rigidbody2D>();		
		PlayerCollider = gameObject.GetComponent<BoxCollider2D>();
		
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
		// Get horizontal value
		float horizontal = Input.GetAxisRaw("Horizontal");
		// Get vertical value
		float vertical = Input.GetAxisRaw("Vertical");

		MoveCharacter(horizontal, vertical);
		PlayMovementAnimation(horizontal, vertical);

		
	}

	//Function to make Player Movement
	private void MoveCharacter(float horizontal, float vertical) 
	{
		//move player horizontally
		Vector3 position = transform.position;
		position.x += horizontal * speed * Time.deltaTime;
		transform.position = position;

		//checking if player felldown
		if (position.y < -7.5)
        {
			SceneManager.LoadScene(buildIndex);
		}

		//move player vertically
		if (vertical > 0) 
		{
			rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
		}
	}

	private void PlayMovementAnimation(float horizontal, float vertical) 
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
		float colliderSizex = PlayerCollider.size.x;
		float colliderSizey = PlayerCollider.size.y;
		float colliderOffsetx = PlayerCollider.offset.x;
		float colliderOffsety = PlayerCollider.offset.y;
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			animator.SetBool("Crouch", true);			
			PlayerCollider.size = new Vector2(colliderSizex, colliderSizey/2);
			PlayerCollider.offset = new Vector2(colliderOffsetx, colliderOffsety/2);			
		}
		else if (Input.GetKeyUp(KeyCode.LeftControl))
		{
			animator.SetBool("Crouch", false);
			PlayerCollider.size = new Vector2(colliderSizex, colliderSizey * 2);
			PlayerCollider.offset = new Vector2(colliderOffsetx, colliderOffsety * 2);

		}		

		//Code to make Jump animation		
		
			if (vertical > 0 && isGrounded == true)
			{ 				
				animator.SetBool("Jump", true);
			}	
			else if(isGrounded == false)
			{
				animator.SetBool("Jump", false);
			}
	}

	void OnCollisionEnter2D(Collision2D Collision)
	{
		
		if (Collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;
			Debug.Log("Collision Entered");
		}


	}

	//consider when character is jumping .. it will exit collision.
	void OnCollisionExit2D(Collision2D Collision)
	{
		if (Collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = false;
			Debug.Log("Collision exit");
		}
	}



}
