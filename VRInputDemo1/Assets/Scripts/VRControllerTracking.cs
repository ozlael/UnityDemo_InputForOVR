using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class VRControllerTracking : MonoBehaviour {

	[SerializeField] VRNode whichNode;

	Vector3 offsetPos;
	Quaternion offsetRot;
	Vector3 basePos;
	VRNode handNode;

	// Use this for initialization
	void Start () {

		if (VRSettings.enabled == false) {
			Destroy (this);
		}

		offsetPos = Camera.main.transform.position;
		offsetRot = Camera.main.transform.rotation;
		basePos = Quaternion.Inverse (offsetRot) * offsetPos;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = basePos + InputTracking.GetLocalPosition (whichNode);
		pos = offsetRot * pos;
		Quaternion rot = offsetRot * InputTracking.GetLocalRotation (whichNode);
		transform.SetPositionAndRotation (pos, rot);
	}
}
