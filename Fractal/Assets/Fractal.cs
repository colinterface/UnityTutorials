using UnityEngine;
using System.Collections;
using System.IO.Ports;


public class Fractal : MonoBehaviour {

	public Mesh mesh;
	public Material material;
	public int maxDepth;
	public float childScale;
	public float spawnProbability;
	public float maxRotationSpeed;
	public float minRotationSpeed;

	SerialPort stream = new SerialPort("/dev/tty.usbmodem1411", 9600, Parity.None, 8, StopBits.One);

	private int depth;

	private static Vector3[] childDirections = {
		Vector3.up,
		Vector3.right,
		Vector3.left,
		Vector3.forward,
		Vector3.back,
	};

	private static Quaternion[] childOrientations = {
		Quaternion.identity,
		Quaternion.Euler(0f, 0f, -90f),
		Quaternion.Euler(0f, 0f, 90f),
		Quaternion.Euler(90f, 0f, 0f),
		Quaternion.Euler(-90f, 0f, 0f),
	};

	private Material[] materials;

	private float rotationSpeed;

	// Use this for initialization
	void Start () {
		stream.ReadTimeout = 1;
		stream.Open();

		if (materials == null) {
			InitializeMaterials ();
		}
		gameObject.AddComponent<MeshFilter> ().mesh = mesh;
		gameObject.AddComponent<MeshRenderer> ().material = materials[depth];
		rotationSpeed = Random.Range (minRotationSpeed, maxRotationSpeed);
			
		if (depth < maxDepth) {
			StartCoroutine (CreateChildren ());
		}
	}

	IEnumerator CreateChildren () {
		for (int i = 0; i < childDirections.Length; i++) {
			if (Random.value < spawnProbability) {
				yield return new WaitForSeconds (Random.Range (0.1f, 0.2f));
				new GameObject ("Fractal Child")
					.AddComponent<Fractal> ()
					.Initialize (this, childDirections [i], childOrientations [i]);
			}
		}
	}

	void Initialize (Fractal parent, Vector3 direction, Quaternion orientation) {
		mesh = parent.mesh;
		materials = parent.materials;
		maxDepth = parent.maxDepth;
		depth = parent.depth + 1;
		childScale = parent.childScale;
		spawnProbability = parent.spawnProbability;
		maxRotationSpeed = parent.rotationSpeed;

		transform.parent = parent.transform;
		transform.localScale = Vector3.one * childScale;
		transform.localPosition = direction * (0.5f + 0.5f * childScale);
		transform.localRotation = orientation;
	}

	void InitializeMaterials () {
		materials = new Material[maxDepth + 1];
		for (int i = 0; i <= maxDepth; i++) {
			materials [i] = new Material (material);
			materials [i].color = Color.Lerp (Color.black, Color.white, (float)i / maxDepth);
		}
	}
	
	// Update is called once per frame
	void Update () {
//		transform.Rotate (0f, (rotationSpeed * depth + 10) * Time.deltaTime, 0f);
//		transform.Rotate (0f, 10f * Time.deltaTime, 0f);

		try {
			print(stream.ReadLine());
		}
		catch(System.Exception) {

		}
				
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		transform.Rotate (0f, rotation, 0f);

	
	}
}
