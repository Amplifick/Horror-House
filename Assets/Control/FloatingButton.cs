using UnityEngine;
using System.Collections;

public class FloatingButton : MonoBehaviour {

	public Transform positionTransform;
	public float distanceVisibility;

	private bool onSight = false;

	private Canvas mainCanvas;
	private float scaleFactor;

	private Coroutine fading;
	private bool visibilityState = false;

	void Start () {

		mainCanvas = GameObject.Find ("UICanvas").GetComponent<Canvas> ();
		scaleFactor = mainCanvas.scaleFactor;
	}

	void LateUpdate () {

		// First, we check if the floating icon is in the player's field of view

		Vector3 heading = positionTransform.position - Camera.main.transform.position;
		if (Vector3.Dot (Camera.main.transform.forward, heading) > 0) onSight = true;
		else onSight = false;

		// Then, we check the distance between the player and the floating icon

		float distance = Vector3.Distance (Camera.main.transform.position, positionTransform.position);

		// The final position of the floating icon is based on the canvas scale factor

		Vector2 screenPos = Camera.main.WorldToScreenPoint (positionTransform.position);
		Vector2 finalPosition = new Vector2 (screenPos.x / scaleFactor, screenPos.y / scaleFactor);
		transform.GetComponent<RectTransform> ().anchoredPosition = finalPosition;

		// If the floating icon is in the player's field of view...

		if (onSight) {

			// If the distance between the player and the floating icon is OK...

			if ((distance <= distanceVisibility)) {

				// If the floating icon is not visible yet...

				if (!visibilityState) {

					// The floating icon fades in

					if (fading != null) StopCoroutine (fading);
					fading = StartCoroutine (FadeButton (true));
					visibilityState = true;
				}
			}

			// If the distance between the player and the floating icon is too high...

			else {

				// If the floating icon is still visible...

				if (visibilityState) {

					// The floating icon fades out

					if (fading != null) StopCoroutine (fading);
					fading = StartCoroutine (FadeButton (false));
					visibilityState = false;
				}
			}
		}

		// If the floating icon is NOT in the player's field of view...

		else {

			// If the floating icon is still visible...

			if (visibilityState) {

				// The floating icon disappears immediately

				if (fading != null) StopCoroutine (fading);
				transform.GetComponent<CanvasGroup> ().alpha = 0f;
				visibilityState = false;
			}
		}
	}

	private IEnumerator FadeButton (bool show) {

		float duration = 0.2f;
		float elapsedTime = 0f;

		float startAlpha = transform.GetComponent<CanvasGroup> ().alpha;

		while (elapsedTime < duration) {

			elapsedTime += Time.deltaTime;

			if (show) transform.GetComponent<CanvasGroup> ().alpha = Mathf.Lerp (startAlpha, 1f, (elapsedTime / duration));
			else transform.GetComponent<CanvasGroup> ().alpha = Mathf.Lerp (startAlpha, 0f, (elapsedTime / duration));

			yield return null;
		}
	}
}