using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

	class MouseButton {

		IClickable clicked = null;
		IClickable dragged = null;
		bool left = true;
		bool mouseDown = false;
		Vector2 mousePosition = new Vector2 (0, 0);
		Vector2 startDragPosition = new Vector2 (0, 0);
		bool dragging = false;
		float dragThreshold = 10;

		public MouseButton (bool left) {
			this.left = left;
		}

		public void HandleMouseDown () {
			UpdateMousePosition ();
			if (!mouseDown) {
				mouseDown = true;
				clicked = GetMouseOver ();
				UpdateStartDragPosition ();
				RaiseClick ();
			} else if (!dragging) {
				CheckDrag ();
			} else if (dragging) {
				dragged = GetMouseOver ();
				RaiseDrag ();
			}
		}

		public void HandleMouseUp () {
			if (mouseDown) {
				mouseDown = false;
				dragging = false;
				RaiseRelease ();				
			}
		}

		void UpdateMousePosition () {
			mousePosition = Input.mousePosition;
		}

		void UpdateStartDragPosition () {
			startDragPosition = mousePosition;
		}

		IClickable GetMouseOver () {
			Ray ray = Camera.main.ScreenPointToRay (mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				return hit.transform.GetScript<IClickable>();
			} else {
				return null;
			}
		}
		
		void CheckDrag () {
			if (Vector2.Distance (startDragPosition, mousePosition) > dragThreshold) {
				dragging = true;
			}
		}

		void RaiseClick () {
			if (clicked != null) {
				clicked.Click (left);
			}
		}

		void RaiseDrag () {
			if (dragged != null) {
				dragged.Drag (left, new Vector3 (0, 0, 0));
			}
		}

		void RaiseRelease () {
			if (clicked != null) {
				clicked.Release (left);	
			}
		}
	}

	public static Vector3 MousePosition {
		get { 
			Vector2 mp = Input.mousePosition;
			return Camera.main.ScreenToWorldPoint (new Vector3 (mp.x, mp.y, Camera.main.nearClipPlane));
		}
	}

	MouseButton leftButton = new MouseButton (true);
	MouseButton rightButton = new MouseButton (false);

	void LateUpdate () {
		if (Input.GetMouseButton (0)) {
			leftButton.HandleMouseDown ();
		}
		if (Input.GetMouseButton (1)) {
			rightButton.HandleMouseDown ();
		}
		if (!Input.GetMouseButton (0)) {
			leftButton.HandleMouseUp ();
		}
		if (!Input.GetMouseButton (1)) {
			rightButton.HandleMouseUp ();
		}
	}
}
