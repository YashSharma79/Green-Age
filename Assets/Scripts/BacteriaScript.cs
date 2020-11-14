using UnityEngine;
using System.Collections;

public class BacteriaScript : MonoBehaviour {
	public float minRotationSpeed;
	public float maxRotationSpeed;
	public float minMovementSpeed;
	public float maxMovementSpeed;

	private float rotationSpeed = 60.0f; // Degrees per second
	private float movementSpeed = 2.0f; // Units per second;

	private Transform target;
	private Quaternion qTo;
	Vector3 dist;
	float posX,posY;
	GameObject Target;
	public Vector3 screenSpace;
	public bool createCloud;
	float timer;
	float angle;
	public float radius;
	public float speed;
	bool movable;
	public float minRadius,maxRadius;
	private SphereCollider myColl;
	private Rigidbody myRB;
	public Vector3 centre;
	public float speedToCloud;
	void Awake() {
		target = GameObject.Find("Cloud").transform;    
		rotationSpeed = Random.Range (minRotationSpeed, maxRotationSpeed);
		movementSpeed = Random.Range (minMovementSpeed, maxMovementSpeed);
		movable = true;
		radius = Random.Range (minRadius,maxRadius);
		myColl = this.GetComponent<SphereCollider> ();
		myRB = this.GetComponent<Rigidbody> ();
		//centre = this.transform.position;
	}

	void Update() {
		timer += Time.deltaTime;
		if (movable && !createCloud) {
			angle = timer;
			//Vector3 offset = new Vector3 (Mathf.Sin (angle) * radius,(Mathf.Cos (angle) * radius),0f);
			//this.transform.position = centre + offset;
			transform.position = new Vector3 (transform.position.x + Mathf.Sin (angle) * radius,transform.position.y + (Mathf.Cos (angle) * radius),0f);
		}

		/*float angle = Mathf.Atan2 (Random.Range(10f,30f),Random.Range(-2f,2f)) * Mathf.rad2Deg;
			qTo = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, qTo, rotationSpeed * Time.deltaTime);
			transform.Translate (Vector3.right * movementSpeed * Time.deltaTime);*/

		if (createCloud)
			formCloud ();
	}

	void formCloud(){
		if (movable) {
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position,speedToCloud);
			//Debug.Log (this.gameObject.name +" is attacking");
		}
	}
		
	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == gameObject.tag)
			this.movable = false;

		if (other.gameObject.layer == 8) {
			this.myRB.isKinematic = false;
			this.myColl.isTrigger = false;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == gameObject.tag)
			this.movable = true;

		if (other.gameObject.layer == 8) {
			this.myRB.isKinematic = true;
			this.myColl.isTrigger = true;

		}
	}
}