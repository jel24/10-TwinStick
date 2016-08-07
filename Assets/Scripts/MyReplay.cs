using UnityEngine;
using System.Collections;

public class MyReplay : MonoBehaviour {

	private const int bufferFrames = 1000;
	private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
	private Rigidbody rigidBody;

	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		print(rigidBody);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (gameManager.record) {
			Record ();
		} else {
			PlayBack();
		}
	}

	void Record ()
	{
		rigidBody.isKinematic = false;
		int frame = Time.frameCount % bufferFrames;
		print ("Writing frame " + frame);
		keyFrames[frame] = new MyKeyFrame(Time.time, rigidBody.position, rigidBody.rotation);
	}

	void PlayBack ()
	{
		if (Time.frameCount < bufferFrames) {
			int frame = Time.frameCount % bufferFrames;
		} else {
			int frame = Time.frameCount % bufferFrames;
		}
		rigidBody.isKinematic = true;

		print ("Reading frame " + frame);
		transform.position = keyFrames[frame].position;
		transform.rotation = keyFrames[frame].rotation;
	}
}

/// <summary>
/// A sturcute for storing time, rotation, and position of an object for replay.
/// </summary>
public class MyKeyFrame {

	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	public MyKeyFrame (float time, Vector3 pos, Quaternion rot)
	{
		this.frameTime = time;
		this.position = pos;
		this.rotation = rot;
	}

}