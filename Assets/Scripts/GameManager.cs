using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool record = true;
	public MyReplay ball;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

//		if (CrossPlatformInputManager.GetButton("Fire1")){
//			record = false;
//		} else {
//			record = true;
//		}

	}

	public void Record() {
		record = true;
	}

	public void Playback() {
		record = false;
	}
}
