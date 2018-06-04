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
	
	public void Add()
	{
		integer += 0.1;
		text.text = integer.ToString();
	}
	
	public void Subtract()
	{
		integer -= 0.1;
		text.text = integer.ToString();
	}
}
