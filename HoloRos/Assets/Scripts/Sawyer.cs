using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sawyer : MonoBehaviour 
{
	private string[] SawyerData;
	private string Payload;
	private string MaxReach;
	private string TaskRepeatability;
	private string ToolSpeed;
	private string DOF;
	private string OperatingTemp;
	private string JointRanges;
	private string RobotWeight;
	private string PowerRequirements;
	private string BoxIO;
	private string Communication;
	private string IPClass;
	private string CollaborativeStandards;
	private string EndOfArmIO;
	
	public Text[] UIElements;

	// Use this for initialization
	void Start () 
	{
		SawyerData = new string[14];
		this.SawyerData[0] = "4KG";
		this.SawyerData[1] = "1260MM";
		this.SawyerData[2] = "0.1MM";
		this.SawyerData[3] = "1,5M/s";	
		this.SawyerData[4] = "7";
		this.SawyerData[5] = "0-40°C";
		this.SawyerData[6] = "J0-J3: 350°, J4-J5: 340°, J6:540°";
		this.SawyerData[7] = "19KG";
		this.SawyerData[8] = "100-240V";
		this.SawyerData[9] = "8 digital in, 8 digital out";
		this.SawyerData[10] = "Modbus TCP, TCP/IP";
		this.SawyerData[11] = "IP54";
		this.SawyerData[12] = "ISO 10218-1:2011";
		this.SawyerData[13] = "4 digital in, 4 digital out, 2 analog in, 24V 2A, Clicksmart plate";
	}
	
	public void FillUI()
	{
		for(int i = 0; i < UIElements.Length; i++)
		{
			UIElements[i].text = SawyerData[i];
		}
		
	}
}
