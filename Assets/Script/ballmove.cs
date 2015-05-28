using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections;

public class ballmove : MonoBehaviour 
{
	public float ballSpeed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count = 12;
	private float timer;
	private Vector3 initialPos;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		setCountText ();
		winText.text = "";
		timer = 0;
		initialPos = transform.position;
	}

	void setCountText()
	{
		countText.text = "Missing> " + count.ToString() + " | Timer: " + timer.ToString("F2") + 
			"\n(R) to restart!";
		if (count <= 0) {
			winText.text = "You did it in: " + timer.ToString("F2");
		}
	}

	void Update() {
		timer += Time.deltaTime;
		if (count > 0) {
			setCountText ();
		}
		
		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevelName);
		}
	}

	void FixedUpdate() 
	{
		float moveHor = Input.GetAxis ("Horizontal");
		float moveVer = Input.GetAxis ("Vertical"); 	

		Vector3 v3 = new Vector3 (moveHor, 0.0f, moveVer);
		rb.AddForce (v3 * ballSpeed);

		//rb.transform.Translate (Input.acceleration.x, 0, -Input.acceleration.z);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count--;
			setCountText();
		}
	}
}
