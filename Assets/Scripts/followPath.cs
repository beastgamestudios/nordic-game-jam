using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPath : MonoBehaviour {
	public float moveSpeed;
	public GameObject path;
	private Vector3[] wayPoints;
	private Vector3 currentDirection;
	private int currentWayPoint = 0;
	// Use this for initialization
	void Start () {
		getWayPointPositions();
		getNextDirection(currentWayPoint);
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += currentDirection*moveSpeed*Time.deltaTime;
		if (transform.position.x > wayPoints[currentWayPoint].x) {
			currentWayPoint += 1;
			getNextDirection(currentWayPoint);
		}
	}

	void getWayPointPositions() {
		Transform[] wayPointObjects = path.GetComponentsInChildren<Transform>();
		wayPoints = new Vector3[wayPointObjects.Length];
		int i = 0;
		i = (i < wayPointObjects.Length) ? i++ : 0;
		wayPoints[i] = wayPointObjects[i].transform.position;
	}

	void getNextDirection(int nextWayPoint) {
		currentDirection = (wayPoints[nextWayPoint] - transform.position).normalized;
	}
}
