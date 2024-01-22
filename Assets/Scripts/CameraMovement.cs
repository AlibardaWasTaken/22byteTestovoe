using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 _offset;

	void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + _offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		transform.LookAt(target);
	}
}