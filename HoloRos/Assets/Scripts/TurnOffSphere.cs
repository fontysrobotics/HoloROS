using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class TurnOffSphere : MonoBehaviour {

	public GameObject UR5;
	public GameObject Point;
	public GameObject TurnOff;
	public GameObject MoveArm;
	public GameObject canvas;
	public GameObject camera;

	public void TurnOffStuff()
	{

		UR5.GetComponent<HandDraggable>().enabled = false;
		Point.GetComponent<HandDraggable>().enabled = true;

		TurnOff.SetActive(false);
		MoveArm.SetActive(true);


		Vector3 pos = UR5.transform.position;

		pos.y = pos.y + 1.5f;

		canvas.transform.position = pos;
		
		Vector3 v = new Vector3();
		v.x = 0;
		v.y = 0;
		v.z = 0;

		//Vector3 v2 = Vector3.RotateTowards(canvas.transform.position, camera.transform.position, 3.14f, 0);
		
		//v.y = Mathf.Rad2Deg * v2.y + canvas.transform.rotation.eulerAngles.y;
		Quaternion q = new Quaternion();
		q.eulerAngles = v;

		canvas.transform.rotation = q;
	}

}
