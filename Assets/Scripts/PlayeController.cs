using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayeController : MonoBehaviour {

	public Text scoreText;
	public Text winText;
	private int score;
	public float speed = 20;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		score = 0;
		SetCountText();
		winText.text = "";
		
	}
	
	// Update is called once per frame
	void Update () {
		var moveHirizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		var movement = new Vector3(moveHirizontal, 0 , moveVertical);

		rb.AddForce(movement * speed);
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			score++;
			SetCountText();
		}

	}
	
	void SetCountText() {
		scoreText.text = "Count : " + score.ToString();
		if(score >= 12){
			winText.text = "You Win.";
		}
	}
}
