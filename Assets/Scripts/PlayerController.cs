using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float runSpeed;
	public float walkSpeed;
	Rigidbody playerRB;
	Animator anim;
	BacteriaManager spawner;
	Vector3 movement;
	bool facingRight;
	public float speed = 10.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	//for jumping2
	bool grounded = true;
	Collider[] groundCollisions;
	float groundCheckRadius = 1.5f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;
	bool done;
	private Vector3 moveDirection = Vector3.zero;
	CharacterController controller;
	private float m_StepCycle;
	private float m_NextStep;
	public AudioClip m_JumpSound;           // the sound played when character leaves the ground.
	public AudioClip m_LandSound;           // the sound played when character touches back on ground.
	private AudioSource m_AudioSource;
	private bool jumped;
	// Use this for initialization
	void Start () {
		anim = GetComponentInParent<Animator> ();
		//playerRB = GetComponent<Rigidbody> ();
		facingRight = true;
		controller = GetComponent<CharacterController> ();
		m_AudioSource = GetComponent<AudioSource>();
		GameObject bacteria = GameObject.Find ("Bacteria");
		//spawner = bacteria.GetComponent<BacteriaManager> ();
		//spawner.spawnCount = 1;
		//spawner.nowCount = 0;
	}

	void FixedUpdate()
	{
		/*if (Input.GetAxis ("Jump") > 0) {
			grounded = false;
			playerRB.AddForce (new Vector3 (0, jumpHeight, 0));
			anim.SetBool ("grounded",false);
		} 

		groundCollisions = Physics.OverlapSphere (groundCheck.position,groundCheckRadius,groundLayer);

		if (groundCollisions.Length > 0 )
			grounded = true;
		else
			grounded = false;
						
		anim.SetBool ("grounded", grounded);
		anim.SetFloat ("verticalSpeed",20);*/
		float moveH = 0,run = 0;
		if (controller.isGrounded) {
			moveH = Input.GetAxis ("Horizontal");
			moveDirection = new Vector3 (0, 0, moveH);
			moveDirection = transform.TransformDirection (moveDirection);
			run = (Input.GetAxisRaw ("Fire3"));
			if (run > 0)
				moveDirection *= runSpeed;
			else
				moveDirection *= speed;
			
			if (Input.GetButton ("Jump")) {
				moveDirection.y = jumpSpeed;
				anim.SetBool ("grounded",false);
				anim.SetFloat ("verticalSpeed",moveDirection.y);
				PlayJumpSound ();
				grounded = false;
				jumped = true;
			}
		}
		//else
		//	anim.SetBool ("grounded", true);
		anim.SetFloat ("speed",Mathf.Abs(moveH));
		anim.SetFloat ("wantTorun", run);
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	
		anim.SetBool ("grounded",controller.isGrounded);
		if (jumped && controller.isGrounded) {
			PlayLandingSound ();
			jumped = false;
		}
		anim.SetFloat ("verticalSpeed",moveDirection.y);

		//anim.SetBool("grounded",false);
		/*float moveH = Input.GetAxisRaw ("Horizontal");
		anim.SetFloat ("speed",Mathf.Abs(moveH));

		float wantTorun = Input.GetAxisRaw("Fire3");
		anim.SetFloat ("wantTorun", wantTorun);

		anim.SetBool ("grounded",grounded);
		*/
		if (moveH > 0 && !facingRight)
			flip ();
		else if (moveH < 0 && facingRight)
			flip ();
	}

	/*void Move(float h,float v)
	{
		movement.Set (h,v,0f);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRB.MovePosition (transform.position + movement);

	}

	void Animating(float h,float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.Play ("PlayerRun",walking);
	}*/

	void flip(){
		facingRight = !facingRight;
		Vector3 playerScale = transform.localScale;
		playerScale.z *= -1;
		transform.localScale = playerScale;
	}

	private void PlayJumpSound()
	{
		m_AudioSource.clip = m_JumpSound;
		m_AudioSource.Play();
	}
		
	private void PlayLandingSound()
	{
		m_AudioSource.clip = m_LandSound;
		m_AudioSource.Play();
		//m_NextStep = m_StepCycle + .5f;
	}

}