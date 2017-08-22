using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwordControl : MonoBehaviour {

	[SerializeField] GameObject blade;
	[SerializeField] string inputNameToActiveBlade;
	[SerializeField] string inputNameToChargeBlade;
	[SerializeField] Material dissolveMaterialPrefab;
	[SerializeField] float chargePower;
	Material bladeMtrl;
	Material dissolveMaterial;
	Renderer bladeRenderer;
	float dissolveRef = 0;

	// Use this for initialization
	void Start () {
		if (blade) {
			bladeRenderer = blade.GetComponent<Renderer> ();
			bladeMtrl = bladeRenderer.GetComponent<Renderer> ().material;
			dissolveMaterial = Instantiate (dissolveMaterialPrefab) as Material;
			bladeRenderer.material = dissolveMaterial;
			dissolveRef = 0;
			//blade.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {

		UpdateDissolve ();
		UpdateCharge ();
	}

	void UpdateDissolve() {
		if (blade && Input.GetAxisRaw (inputNameToActiveBlade) > 0.1f) {
			if (dissolveRef < 1) {
				dissolveRef += Time.deltaTime;
				bladeRenderer.material.SetFloat ("_NoiseRef", dissolveRef);
				if (dissolveRef >= 1) {
					dissolveRef = 1;
					bladeRenderer.material = bladeMtrl;
				}
			}
		} else {
			if (dissolveRef == 1) {
				bladeRenderer.material = dissolveMaterial;
			} 
			if (dissolveRef > 0) {
				dissolveRef -= Time.deltaTime;
				bladeRenderer.material.SetFloat ("_NoiseRef", dissolveRef);
				if (dissolveRef <= 0) {
					dissolveRef = 0;
				}
			}
		}
	}

	void UpdateCharge() {
		if (blade && Input.GetAxisRaw (inputNameToChargeBlade) > 0.1f) {
			bladeMtrl.SetColor ("_EmissionColor", Color.red * chargePower);
		} else {
			bladeMtrl.SetColor ("_EmissionColor", Color.black);
		}
	}
}
