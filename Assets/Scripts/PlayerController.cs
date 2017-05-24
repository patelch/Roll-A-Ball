﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private int count;

	public Text countText;
	public Text winText;
	public float speed;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		count = 0;

		SetCountText ();
		winText.text = "";
	}

	// UpdateUpdate for physics code
	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);

		rb.AddForce (speed * movement);
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("Pick Up")) {
			count += 1;
			SetCountText ();

			other.gameObject.SetActive (false);
		}
	
	}

	void SetCountText() {
		countText.text = "Count: " + count.ToString ();

		if (count >= 12) {
			winText.text = "You Win!";
		}
	}
}
