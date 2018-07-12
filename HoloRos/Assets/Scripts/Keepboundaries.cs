using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keepboundaries : MonoBehaviour {

	private Transform obj;
	//private Rigidbody body;
	private Vector3 prevPos;

	// Use this for initialization
	void Start () {
		//body = GetComponent<Rigidbody>();
		obj = this.transform.parent;
		prevPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		float x = Mathf.Pow(this.transform.position.x - obj.position.x, 2);
		float y = Mathf.Pow(this.transform.position.y - obj.position.y, 2);
		float z = Mathf.Pow(this.transform.position.z - obj.position.z, 2);

		float end = Mathf.Sqrt(x + y + z);
		if (end > 1)
		{
			//body.velocity = Vector3.zero;
			this.transform.position = prevPos;

		}
		else
		{
			prevPos = this.transform.position;
		}
	}
}
