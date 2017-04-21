using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class drawPointsInScene : MonoBehaviour {

	private Transform[] wayPointObjects;
	private Vector3[] wayPoints;

	void OnDrawGizmos() {
		wayPointObjects = getWayPointObjects();
		wayPoints = getWayPointPositions(wayPointObjects);
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
	
	public Transform[] getWayPointObjects() {
		Transform[] wayPointObjects = GetComponentsInChildren<Transform>();
		return wayPointObjects;
	}

	public Vector3[] getWayPointPositions(Transform[] wayPointObj) {
		Vector3[] pathWayPoints = new Vector3[wayPointObj.Length];
		for (int i = 0; i < pathWayPoints.Length; i++) {
			pathWayPoints[i] = wayPointObj[i].transform.position;
		}
		return pathWayPoints;
	}
}
