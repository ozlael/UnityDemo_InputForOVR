using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class AdjustTransformFoVRController : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// Between Oculus and Vive has different feeling of grabbing.
		string[] names = Input.GetJoystickNames ();
		foreach (string str in names) {
			if (str.Contains ("Oculus")) {
				transform.Rotate (new Vector3 (-45, 0, 0));
				break;
			}
		}
	}

}
