using UnityEngine;
using System.Collections;

public class scrolling : MonoBehaviour {

	public bool Scrolling, parallax;
	public float backgroundSize;
	public float parallaxSpeed;
	public float viewZone;
	private Transform cameraTransform;
	private Transform[] layers;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;
	public void Start()
	{
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;
		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
			layers [i] = transform.GetChild (i);

		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}

	public void Update()
	{
		if (parallax) {
			float deltaX = cameraTransform.position.x - lastCameraX;
			transform.position += Vector3.right * (deltaX * parallaxSpeed);
		}
		lastCameraX = cameraTransform.position.x ;

		if (Scrolling) {
			if (cameraTransform.position.x - viewZone < (layers [leftIndex].transform.position.x))
				scrollLeft ();
			if (cameraTransform.position.x + viewZone > (layers [rightIndex].transform.position.x))
				scrollRight ();
		}
	}

	private void scrollLeft()
	{
		layers [rightIndex].position = new Vector3 (layers [leftIndex].position.x - backgroundSize,layers [leftIndex].position.y,layers [leftIndex].position.z);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0)
			rightIndex = layers.Length - 1;
	}

	private void scrollRight(){
		layers [leftIndex].position = new Vector3(layers [rightIndex].position.x + backgroundSize,layers [rightIndex].position.y,layers [rightIndex].position.z);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length)
			leftIndex = 0;
	}
}
