using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour 
{
	public bool isPressed;
	public GameObject objectToExecute;
	public Material pressedTexture;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			Debug.Log ("Press");
			Press();
		}
	}
	
	public void Press()
	{
		renderer.material = pressedTexture;
		if(objectToExecute != null)
			objectToExecute.SendMessage("Execute");	
	}
}
