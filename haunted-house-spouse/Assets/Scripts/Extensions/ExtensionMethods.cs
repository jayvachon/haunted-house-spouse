using UnityEngine;
using System.Collections;

public static class ExtensionMethods {

	public static T GetScript<T> (this Transform transform) where T : class {
		return transform.GetComponent(typeof (T)) as T;
	}

	public static T GetScript<T> (this GameObject gameObject) where T : class {
		return gameObject.GetComponent (typeof (T)) as T;
	}

	public static T[] AppendArray<T> (T[] array, T newValue) {
		
		int newLength = array.Length + 1;
		T[] newArray = new T[newLength];
		for (int i = 0; i < array.Length; i ++) {
			newArray[i] = array[i];
		}
		newArray[newLength - 1] = newValue;
		
		return newArray;
	}
}
