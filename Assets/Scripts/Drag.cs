using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour
{  
	private bool mousePressed;
	public GameObject Target;
	public Vector3 screenSpace;
	public Vector3 offset;
	BacteriaScript bs;
	Vector3 curPosition;
	// Use this for initialization
	void Start(){
		bs = Target.GetComponent<BacteriaScript> ();	
		curPosition = this.transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		//Casts a ray when the mouse is pressed
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hitInfo;
			if (Target == GetClickedObject (out hitInfo)) {
				mousePressed = true;
				screenSpace = Camera.main.WorldToScreenPoint (Target.transform.position);
				offset = Target.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));

			}
		}
			
		if (Input.GetMouseButtonUp (0)) {
			mousePressed = false;
		}

		//calculate the position while dragging
		if (mousePressed) {
			//keep track of the mouse position

			Vector3 curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

			//convert the screen mouse position to world point and adjust with offset
			curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;

			//update the position of the object in the world
			Target.transform.position = curPosition;
		//	bs.centre = curPosition;
		}
	}

	//return the object which is clicked
	GameObject GetClickedObject (out RaycastHit hit)
	{
		GameObject target = null;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray.origin, ray.direction * 10, out hit)) {
			target = hit.collider.gameObject;
		}

		return target;
	}
}