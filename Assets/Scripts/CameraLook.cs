using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
	Vector2 rotation = Vector2.zero;
	public float speed = 3;

    private void Start()
    {
		Application.targetFrameRate = 60;
	}

    void Update()
	{
		rotation.y += Input.GetAxis("Mouse X");
		rotation.x += -Input.GetAxis("Mouse Y");
		transform.eulerAngles = (Vector2)rotation * speed;
	
	}
}
