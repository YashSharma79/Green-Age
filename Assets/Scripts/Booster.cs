using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour {
	public float MinForce;
	public float MaxForce;
	public float minX, maxX;
	public float minY, maxY;
	public float DirectionChangeInterval;
	private float directionChangeInterval;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		directionChangeInterval = DirectionChangeInterval;
		rb = GetComponent<Rigidbody> ();
		push ();
	}
	
	// Update is called once per frame
	void Update () {
	
		directionChangeInterval = Time.deltaTime;
		if (directionChangeInterval < 0) {
			push ();
			directionChangeInterval = DirectionChangeInterval;
		}
	}

	void push()
	{
		float force = Random.Range (MinForce, MaxForce);
		float x = Random.Range (minX, maxX);
		float y = Random.Range (minY, maxY);

		rb.AddForce (force * new Vector3 (x,y,0f));
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Blue"){
			Debug.Log (other.gameObject.tag + " is here");
			BacteriaScript bs = other.gameObject.GetComponent<BacteriaScript> ();
			//bs.radius = 1;
		}

		if(other.gameObject.tag == "Green"){
			Debug.Log (other.gameObject.tag + " is here");
			Destroy (other.gameObject);
		}

		if(other.gameObject.tag == "Black"){
			Debug.Log (other.gameObject.tag + " is here");
			Destroy (gameObject);
		}
	
	}
}

