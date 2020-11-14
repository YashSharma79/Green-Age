/*using UnityEngine;
using System.Collections;

public class Float : MonoBehaviour {
	float waterLevel = 4;
	float floatHeight = 2;
	float bounceDamp = 0.05;
	Vector3 buoyancyCenterOffset;

	float forceFactor;
	Vector3 actionPoint;
	Vector3 upLift;

	void Update () {
		actionPoint = transform.position + transform.TransformDirection(buoyancyCenterOffset);
		forceFactor = 1f - ( (actionPoint.y - waterLevel ) / floatHeight );

		if(forceFactor > 0f){
			upLift = -physics.gravity * (forceFactor - rigidbody.velocity.y * bounceDamp);
		}

		rigidbody.AddForceAtposition(uplift,actionpoint);

	}

}*/