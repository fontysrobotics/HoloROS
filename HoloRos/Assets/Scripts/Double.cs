using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Double : MonoBehaviour {

	public double d;
	public Text text;

	void Start () {
		d = 0;
	}
	
	public void AddPointOne()
	{
		d += 0.1;
		text.text = d.ToString();
	}
	
	public void SubtractPointOne()
	{
		d -= 0.1;
		text.text = d.ToString();
	}

	public void AddOne()
	{
		d += 1;
		text.text = d.ToString();
	}

	public void SubtractOne()
	{
		d -= 1;
		text.text = d.ToString();
	}
}
