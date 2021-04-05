using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class PlayerController : MonoBehaviour
{
	public Animator animator;
	public float speed;
	public float jumpForce;
	public int buildIndex;
	public ScoreController scoreController;

	private Rigidbody2D rb2d;
	private BoxCollider2D PlayerCollider;
	bool isGrounded;
	public Transform GroundCheck;
	public LayerMask groundlayer;
	float delay = 2;

	private void Awake()
	{
		Debug.Log("Player controller awake");
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		PlayerCollider = gameObject.GetComponent<BoxCollider2D>();

	}

	// Start is called before the first frame update
	void Start()
	{
		
	}

	public void PickUpKey()
	{
		Debug.Log("Player picked up the Key");
		scoreController.IncreaseScore(10);
	}

	public void KillPlayer()
    {
		Debug.Log("player killed by enemy");
		//Destroy(gameObject);
		//Add player Death animation;
		animator.SetBool("Death", true);
		StartCoroutine(LoadLevelAfterDelay(delay));
		//Reload();
	}

	private IEnumerator LoadLevelAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(0);
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

	}

	private void PlayMovementAnimation(float horizontal, float vertical)
	{
		RunAnimation(horizontal);

		CrouchAnimation();

		JumpAnimation(vertical);
	}

	private void RunAnimation(float horizontal)
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
	}

	private void CrouchAnimation()
	{
		//Code to make Crouch animation
		float colliderSizex = PlayerCollider.size.x;
		float colliderSizey = PlayerCollider.size.y;
		float colliderOffsetx = PlayerCollider.offset.x;
		float colliderOffsety = PlayerCollider.offset.y;

		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			animator.SetBool("Crouch", true);
			PlayerCollider.size = new Vector2(colliderSizex, colliderSizey / 2);
			PlayerCollider.offset = new Vector2(colliderOffsetx, colliderOffsety / 2);
		}
		else if (Input.GetKeyUp(KeyCode.LeftControl))
		{
			animator.SetBool("Crouch", false);
			PlayerCollider.size = new Vector2(colliderSizex, colliderSizey * 2);
			PlayerCollider.offset = new Vector2(colliderOffsetx, colliderOffsety * 2);

		}
	}

	private void JumpAnimation(float vertical)
	{
		if (vertical > 0)
		{
			isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundlayer);
			if (isGrounded)
			{

				Jump();
				animator.SetBool("Jump", true);
				Debug.Log(isGrounded);
			}
			else
            {
				NoJump();
				animator.SetBool("Jump", true);
			}
		}
		else
		{
			NoJump();
			animator.SetBool("Jump", false);
		}
	}

	void Jump()
	{
		float colliderSizex = PlayerCollider.size.x;
		float colliderSizey = PlayerCollider.size.y;
		float colliderOffsetx = PlayerCollider.offset.x;
		float colliderOffsety = PlayerCollider.offset.y;

		//PlayerCollider.size = new Vector2(colliderSizex, colliderSizey / 2);
		//PlayerCollider.offset = new Vector2(colliderOffsetx, colliderOffsety / 2);


		rb2d.velocity = Vector2.up * jumpForce;
		
		//Debug.Log("jump done.");
	}

	void NoJump()
    {
		float colliderSizex = PlayerCollider.size.x;
		float colliderSizey = PlayerCollider.size.y;
		float colliderOffsetx = PlayerCollider.offset.x;
		float colliderOffsety = PlayerCollider.offset.y;

		//PlayerCollider.size = new Vector2(colliderSizex, colliderSizey * 2);
		//PlayerCollider.offset = new Vector2(colliderOffsetx, colliderOffsety * 2);

		//rb2d.velocity = Vector2.down * (1);
		
	}

	/*
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

	*/

}