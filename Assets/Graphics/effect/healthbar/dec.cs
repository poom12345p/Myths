using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dec : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void decr()
	{
		GameObject.Find("EventSystem").GetComponent<health>().nowHealth -= 5f;
	}
}
