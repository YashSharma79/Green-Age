using UnityEngine;
using System.Collections;

public class VerticalMove : MonoBehaviour {

	private Vector3 source;
	private Vector3 destination;

	private Vector3 nextPos;
	public float speed;

	public Transform k2;
	private float step;

	// Use this for initialization
	void Start () {
		source = this.transform.position;
		destination = new Vector3(this.transform.position.x,k2.transform.position.y,this.transform.position.z);
		nextPos = destination;
		step = speed * Time.deltaTime;
	}

	// Update is called once per frame
	void Update () {
		//this.transform.position = Vector3.MoveTowards (this.transform.position, nextPos,step);

		this.transform.position = Vector3.Lerp (this.transform.position,nextPos,0.1f);
		if (Vector3.Distance (this.transform.position, nextPos) <= 0.1) {
			ChangeDestination ();
		}
	}
		
	void ChangeDestination ()
	{
		nextPos = ( nextPos != source ? source : destination);
	}
}
