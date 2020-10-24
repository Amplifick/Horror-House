using UnityEngine;

public class RaycastManager : MonoBehaviour {

	[Header ("Cursor")]

	public bool lockCursor = true;

	[Header ("Raycast")]

	public LayerMask layerMask = -1;
	public Transform currentTarget;

	private bool lockState;
	private Transform player;

	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {

		if (lockCursor && !lockState) {

			lockState = true;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else if (!lockCursor && lockState) {

			lockState = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	void LateUpdate () {

		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit;

		// If the ray touches a transform...

		if (Physics.Raycast (ray, out hit, Mathf.Infinity, layerMask.value)) {

			// If the target has a 'Door' component...

			if (hit.collider.transform.GetComponent<Door> () != null) {

				// If the distance between the target and the player is short enough...

				float distance = Vector3.Distance (player.position, hit.collider.transform.position);

				if (distance <= hit.collider.transform.GetComponent<Door> ().interactionDistance) {

					// If the target is not busy...

					if (!hit.collider.transform.GetComponent<Door> ().busy) {

						currentTarget = hit.collider.transform;
						currentTarget.GetComponent<Door> ().UIPrompt.GetComponent<CanvasGroup> ().alpha = 1f;
					}

					// If the target is busy...

					else {

						ResetTarget ();
					}
				}

				// If the distance between the target and the player is too high...

				else {

					ResetTarget ();
				}
			}

			// If the target does not have a 'Door' component...

			else {

				ResetTarget ();
			}
		}

		// If the ray does not touch anything...

		else {

			ResetTarget ();
		}
	}

	private void ResetTarget () {

		if (currentTarget != null) {

			currentTarget.GetComponent<Door> ().UIPrompt.GetComponent<CanvasGroup> ().alpha = 0f;
			currentTarget = null;
		}
	}
}