using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour {

	public enum StateEnum { Opened, Closed }
	public StateEnum state;
	public float interactionDistance;
	public Transform pivot;
	public float openedAngle;
	public float closedAngle;
	public AudioClip openingSound;
	public AudioClip closingSound;
	public Transform UIPrompt;
	public  bool isLocked;
	private Animator animator;
	public AudioClip clip;
	public AudioSource source;

	private RaycastManager raycastManager;
	[HideInInspector] public bool busy = false;

	void Start () {

		raycastManager = GameObject.Find ("_Managers").GetComponent<RaycastManager> ();
		isLocked = false;
		animator = GetComponent<Animator>();
	}

	void Update () {

		// If the current target is THIS transform...

		if (raycastManager.currentTarget == transform && Input.GetKeyDown (KeyCode.E) && !busy && isLocked==false) {

			// If the door is closed, we open it

			if (state == StateEnum.Closed) {

				StartCoroutine ("Opening");
			}

			// If the door is opened, we close it

			else if (state == StateEnum.Opened) {

				StartCoroutine ("Closing");
			}
		} else if (raycastManager.currentTarget == transform && Input.GetKeyDown(KeyCode.E) && !busy && isLocked == true)
		{
			animator.SetTrigger("doorTryOpen");
			source.PlayOneShot(clip);
		}
	}

	private IEnumerator Opening () {

		busy = true;

		// If the 'Opening Sound' field is not empty, a sound is played right before the door rotation

		if (openingSound != null) GetComponent<AudioSource> ().PlayOneShot (openingSound);

		float duration = 0.8f;
		float elapsedTime = 0f;

		Quaternion startRot = pivot.localRotation;
		Quaternion endRot = Quaternion.Euler (0, openedAngle, 0);

		// Rotation of the door

		while (elapsedTime < duration) {

			elapsedTime += Time.deltaTime;
			pivot.localRotation = Quaternion.Slerp (startRot, endRot, (elapsedTime / duration));
			yield return null;
		}

		// The UI prompt is updated

		UIPrompt.GetComponent<Text> ().text = "Press [E] to close";

		state = StateEnum.Opened;
		busy = false;
	}

	public IEnumerator Closing () {

		busy = true;

		float duration = 0.8f;
		float elapsedTime = 0f;

		Quaternion startRot = pivot.localRotation;
		Quaternion endRot = Quaternion.Euler (0, closedAngle, 0);

		// Rotation of the door

		while (elapsedTime < duration) {

			elapsedTime += Time.deltaTime;
			pivot.localRotation = Quaternion.Slerp (startRot, endRot, (elapsedTime / duration));
			yield return null;
		}

		// If the 'Closing Sound' field is not empty, a sound is played right after the door rotation

		if (closingSound != null) GetComponent<AudioSource> ().PlayOneShot (closingSound);

		// The UI prompt is updated

		UIPrompt.GetComponent<Text> ().text = "Press [E] to open";

		state = StateEnum.Closed;
		busy = false;
	}
}
