using UnityEngine;
using System.Collections;

public class digging : MonoBehaviour {

	//public GameObject dig;
	int obj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButtonDown(0))
		{
		//	Instantiate (dig,new Vector3(transform.position.x,-2.8f,-3f),transform.rotation);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				Destroy(hit.collider.gameObject);
				//print("Destroyed at " + Input.mousePosition);
			}  
		}
			
	}
}