using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {

	/*public Vector3 Velocity = new Vector3(1,1,0);

	[Range(0, 10)] 
	public float RotateSpeed;
	[Range(0, 10)]
	public float Radius;

	private Vector3 _centre;
	private float _angle;

	void Start()
	{
		_centre = transform.position;
	}

	void Update()
	{     
		_centre += Velocity * Time.deltaTime;

		_angle += RotateSpeed * Time.deltaTime;

		Vector3 offset = new Vector3(Mathf.Sin(_angle) * Radius, Mathf.Cos(_angle) * Radius,0) ;

		transform.position = _centre + offset;
	}*/
	public float RotateSpeed;
	public float Radius;
	public Vector3 _centre;
	private float _angle;

	private void Start()
	{
		_centre = transform.position;
	}

	private void Update()
	{
		Debug.Log (_centre);
		_angle += RotateSpeed * Time.deltaTime;

		Vector3 offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle),0) * Radius;
		transform.position = _centre + offset;
	}
		
}