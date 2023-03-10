using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFo : MonoBehaviour
{
	[SerializeField]private GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start()
	{
		
		offset = transform.position - player.transform.position;
		transform.position = player.transform.position + offset;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		transform.position = player.transform.position + offset;
	}
}
