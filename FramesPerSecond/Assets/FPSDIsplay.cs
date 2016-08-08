using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FPSCounter))]
public class FPSDIsplay : MonoBehaviour {

	public Text highestFPSLabel, averageFPSLabel, lowestFPSLabel;

	FPSCounter fpsCounter;

	void Awake () {
		fpsCounter = GetComponent<FPSCounter> ();
	}

	void Update () {
		highestFPSLabel.text = Mathf.Clamp(fpsCounter.HighestFPS, 0, 99).ToString ();
		averageFPSLabel.text = Mathf.Clamp(fpsCounter.AverageFPS, 0, 99).ToString ();
		lowestFPSLabel.text = Mathf.Clamp(fpsCounter.LowestFPS, 0, 99).ToString ();
	}

}
