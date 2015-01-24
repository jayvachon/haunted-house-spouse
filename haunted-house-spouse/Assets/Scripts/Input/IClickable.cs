using UnityEngine;
using System.Collections;

public interface IClickable {
	void Click (bool left);
	void Drag (bool left, Vector3 mousePosition);
	void Release (bool left);
}
