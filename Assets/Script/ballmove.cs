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

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		setCountText ();
		winText.text = "";
	}

	void setCountText()
	{
		countText.text = "Faltam> " + count.ToString();
		if (count <= 0) {
			winText.text = "Conseguiste em: " + Time.time.ToString();
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
