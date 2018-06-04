using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Integer : MonoBehaviour {

	public double integer;
	public Text text;
	// Use this for initialization
	void Start () {
		integer = 0;
	}
	
	public void AddPointOne()
	{
		integer += 0.1;
		text.text = integer.ToString();
	}
	
	public void SubtractPointOne()
	{
		integer -= 0.1;
		text.text = integer.ToString();
	}

	public void AddOne()
	{
		integer += 1;
		text.text = integer.ToString();
	}

	public void SubtractOne()
	{
		integer -= 1;
		text.text = integer.ToString();
	}
}
