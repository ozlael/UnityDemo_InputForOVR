using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecenterVRInput : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		UnityEngine.VR.InputTracking.Recenter ();
	}

}
