using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour {

	public float scrollZone = 100;
	public float speed = 5;

	public float xMin = 40;
	public float xMax = 200;
	public float zMax = 230;
	public float zMin = 20;
	public float yMax = 10;
	public float yMin = 0;

	private Vector3 desiredPosition;
	// Use this for initialization
	void Start () {
		
		//desiredPosition.Set (5, 40, 5);
		desiredPosition = transform.position;	
	}
	
	// Update is called once per frame
	private void Update () {
		float x = 0, y = 0, z = 0;
		float speed = scrollZone * Time.deltaTime;
		if (Input.mousePosition.x < scrollZone)
			x -= speed;
		else if (Input.mousePosition.x > Screen.width - scrollZone)
			x += speed;
		if (Input.mousePosition.y < scrollZone)
			z -= speed;
		else if (Input.mousePosition.y > Screen.height - scrollZone)
			z += speed;

		y += Input.GetAxis ("Mouse ScrollWheel"); 

		Vector3 move = new Vector3 (x, y, z) + desiredPosition; 
		move.x = Mathf.Clamp (move.x, xMin, xMax);
		move.z = Mathf.Clamp (move.z, zMin, zMax);
		move.y = Mathf.Clamp (move.y, yMin, yMax);
		desiredPosition = move;
		transform.position = Vector3.Lerp(transform.position,desiredPosition,0.2f);
	
}
}