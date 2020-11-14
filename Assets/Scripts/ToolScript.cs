using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolScript : MonoBehaviour {

	// Use this for initialization
	float z,y;
	void Start () {
		z = transform.position.z - Camera.main.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		y = Input.mousePosition.y;
		Vector3 pos = new Vector3 (Input.mousePosition.x, y, z);
		transform.position = Camera.main.ScreenToWorldPoint (pos);
	}
}
