using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour {

	public Transform hours, minutes, seconds;

	private const float
		hoursToDegrees = 360f / 12f,
		minutesToDegrees = 360f / 60f,
		secondsToDegrees = 360f / 60f;

	
	// Update is called once per frame
	void Update () {
		TimeSpan time = DateTime.Now.TimeOfDay;
		hours.localRotation = 
			Quaternion.Euler (0f, 0f, (float)time.TotalHours * -hoursToDegrees);
		minutes.localRotation = 
			Quaternion.Euler (0f, 0f, (float)time.TotalMinutes * -minutesToDegrees);
		seconds.localRotation = 
			Quaternion.Euler (0f, 0f, (float)time.TotalSeconds * -secondsToDegrees);

	}
}
