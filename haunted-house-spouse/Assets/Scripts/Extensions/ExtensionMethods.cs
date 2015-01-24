using UnityEngine;
using System.Collections;

public static class ExtensionMethods {

	public static T GetScript<T> (this Transform transform) where T : class {
		return transform.GetComponent(typeof (T)) as T;
	}

	public static T GetScript<T> (this GameObject gameObject) where T : class {
		return gameObject.GetComponent (typeof (T)) as T;
	}
}
