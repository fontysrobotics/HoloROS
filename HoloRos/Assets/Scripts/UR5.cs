using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UR5 : MonoBehaviour 
{
	private string[] UR5Data;
	
	public Text[] UIElements;

	// Use this for initialization
	void Start () 
	{
		UR5Data = new string[14];
		this.UR5Data[0] = "5KG";
		this.UR5Data[1] = "850MM";
		this.UR5Data[2] = "0.1MM";
		this.UR5Data[3] = "1M/s";
		this.UR5Data[4] = "6";
		this.UR5Data[5] = "0-50°C";
		this.UR5Data[6] = "360°";
		this.UR5Data[7] = "18.4KG";
		this.UR5Data[8] = "100-240V";
		this.UR5Data[9] = "16 digital in, 16 digital out, 2 analog in, 2 analog out";
		this.UR5Data[10] = "Modbus TCP, TCP/IP";
		this.UR5Data[11] = "IP54";
		this.UR5Data[12] = "ISO 13849:2008,  ISO 10218-1:2011";
		this.UR5Data[13] = "2 digital in, 2 digital out, 2 analog in, 12V/24V 600 mA";
	}
	
	public void FillUI()
	{
		for(int i = 0; i < UIElements.Length; i++)
		{
			UIElements[i].text = UR5Data[i];
		}
		
	}
}
