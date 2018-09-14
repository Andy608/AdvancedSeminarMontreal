using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetInViewport : MonoBehaviour 
{
	public GameObject targetObject;
	public float followSpeed = 10.0f;
	public float edgePadding = 1.0f;
	
	//The offset from where the camera is to the target.
    public Vector3 offset = new Vector3(0, 0, -10);

	private void Update()
	{
		if (IsTargetByEdge())
		{
			MoveCamera();
		}
	}

	private bool IsTargetByEdge()
	{
		float verticalHeight = Camera.main.orthographicSize;
		float horizontalHeight = verticalHeight * Screen.width / Screen.height;

		Vector3 difference = targetObject.transform.position - transform.position;

		if (difference.x < -horizontalHeight + edgePadding || difference.y < -verticalHeight + edgePadding || 
			difference.x > horizontalHeight - edgePadding || difference.y > verticalHeight - edgePadding)
		{
			return true;
		}
		
		return false;
	}

	private void MoveCamera()
	{
		transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position + offset, followSpeed * Time.deltaTime);
	}
}
