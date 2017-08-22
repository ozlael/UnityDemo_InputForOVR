using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class VRControllerTracking : MonoBehaviour {

	[SerializeField] VRNode whichNode = VRNode.LeftHand;

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
		// Without this code, you have to make sure the main camera starts from pos:0 rot:0. 
		// This code works well for Oculus. But, Not works for Vive. I have to check it.
		//Vector3 pos = basePos + InputTracking.GetLocalPosition (whichNode);
		//pos = offsetRot * pos;
		//Quaternion rot = offsetRot * InputTracking.GetLocalRotation (whichNode);

		// At this moment, Make sure the main camera start from 0,0,0
		transform.SetPositionAndRotation (InputTracking.GetLocalPosition (whichNode), InputTracking.GetLocalRotation (whichNode));
	}
}
