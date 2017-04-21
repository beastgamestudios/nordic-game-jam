using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPath : MonoBehaviour {
	public float moveSpeed;
	public GameObject path;
	private Transform[] wayPointObjects;
	private Vector3[] wayPoints;
	private Vector3 currentDirection;
	private int currentWayPoint = 0;
	// Use this for initialization
	void Start () {
		wayPointObjects = path.GetComponentInChildren<drawPointsInScene>().getWayPointObjects();
		wayPoints = path.GetComponentInChildren<drawPointsInScene>().getWayPointPositions(wayPointObjects);
		setStartPosition();
		getNextDirection(currentWayPoint + 1);
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += currentDirection*moveSpeed*Time.deltaTime;
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other == wayPointObjects[currentWayPoint].GetComponent<Collider2D>()) {
			if (other.bounds.Contains(transform.position)) {
				getNextDirection(currentWayPoint + 1);
			}
		}
	}

	void setStartPosition() {
		transform.position = wayPoints[0];
	}

	void getNextDirection(int nextWayPoint) {
		if (nextWayPoint < wayPoints.Length) {
			currentDirection = (wayPoints[nextWayPoint] - transform.position).normalized;
			currentWayPoint += 1;
		} else {
			currentDirection = (wayPoints[0] - wayPoints[nextWayPoint - 1]).normalized;
			currentWayPoint = 0;
		}
	}
}
