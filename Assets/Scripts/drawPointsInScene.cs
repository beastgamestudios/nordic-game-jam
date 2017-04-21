using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class drawPointsInScene : MonoBehaviour {

	private Vector3[] wayPoints;
	// Use this for initialization
	void Start () {
		wayPoints = getWayPointPositions();
	}

	void OnDrawGizmosSelected() {
		foreach (Vector3 point in wayPoints) {
			Gizmos.DrawSphere(point, 0.1f);
		}
	}
	
	public Vector3[] getWayPointPositions() {
		Transform[] wayPointObjects = GetComponentsInChildren<Transform>();
		Vector3[] pathWayPoints = new Vector3[wayPointObjects.Length];
		for (int i = 0; i < wayPointObjects.Length; i++) {
			pathWayPoints[i] = wayPointObjects[i].transform.position;
		}
		return pathWayPoints;
	}
}
