using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public float smoothSpd = 0.125f;
	public Vector3 offset;

	void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpd * Time.deltaTime);
		transform.position = smoothedPosition;
	}
}
