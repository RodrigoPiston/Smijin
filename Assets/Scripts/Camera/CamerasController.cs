using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
	[SerializeField] GameObject[] cameras;

	void Start()
	{
		enableCamera(0, true);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F1))
		{
			enableCamera(0, true);
			enableCamera(1, false);
		}

		if (Input.GetKeyDown(KeyCode.F2))
		{
			enableCamera(0, false);
			enableCamera(1, true);
			
		}

	}

	void enableCamera(int posicion, bool status)
	{
		cameras[posicion].SetActive(status);
	}
}
