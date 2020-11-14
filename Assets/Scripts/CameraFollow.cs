using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothing = 10f;
	public float upOffset;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		// Create a postion the camera is aiming for based on the offset from the target.
		//
		Vector3 targetCamPos = new Vector3(target.position.x + offset.x,(target.position.y * upOffset) + offset.y,target.position.z + offset.z);
		// Smoothly interpolate between the camera's current position and it's target position.
		transform.position = Vector3.Lerp (transform.position,targetCamPos,smoothing * Time.deltaTime);
	}
}
