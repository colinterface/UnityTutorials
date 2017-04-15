using UnityEngine;
using System.Collections;

public class SpawnThing : MonoBehaviour {

	public GameObject thing;
	public float timeBetweenSpawns;

	public Rigidbody Body { get; private set; }
	void Awake () {
		Body = GetComponent<Rigidbody>();
		InvokeRepeating ("Spawn", 0f, timeBetweenSpawns);
	}
		
	
	void Spawn () {
		GameObject thingInstance = Instantiate(thing);
	}
}
