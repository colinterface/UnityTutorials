using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	public float rotationSpeed = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * (rotationSpeed * Time.deltaTime));
	}
}
