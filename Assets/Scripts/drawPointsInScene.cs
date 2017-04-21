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

	void OnDrawGizmos() {
		//draw points of key nodes on way point
		for (int i = 0; i < wayPoints.Length; i++) {
			Gizmos.DrawIcon(wayPoints[i], "wayPointIcon.png", true);
			//draw lines between nodes
			if (i == wayPoints.Length - 1) {
				Gizmos.DrawLine(wayPoints[i], wayPoints[0]);
			} else {
				Gizmos.DrawLine(wayPoints[i], wayPoints[i + 1] );
			}
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
