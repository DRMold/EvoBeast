﻿using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	public float speed = 1f;
	private Vector3 newPosition;

	// Use this for initialization
	void Start ()
	{ newPosition = transform.position; }
	
	// Update is called once per frame
	void Update ()
	{ 
		if (this.gameObject)
		{
			newPosition.x += Time.deltaTime * speed;
			transform.position = newPosition;
		}
	}
}
