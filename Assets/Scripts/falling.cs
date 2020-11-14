using UnityEngine;
using System.Collections;

public class falling : MonoBehaviour {

	bool isFalling = false;
	float downSpeed = 0.1f;
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player") {
			Debug.Log ("Player is here");
			isFalling = true;
		//	GameObject p = gameObject.transform.parent;
//			Destroy (p, 10);		
		}
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (isFalling) 
		{
			downSpeed += Time.deltaTime/15;
			transform.parent.position = new Vector3 (transform.parent.position.x,transform.parent.position.y - downSpeed, transform.parent.position.z);
		
		}
	}
}
