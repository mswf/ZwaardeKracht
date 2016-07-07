using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class GraviSword : MonoBehaviour
{

	public Transform swordPivot;

	public float currentRotation = 0f;
	public float rotateSensitivity = 1f;

	public void Start()
	{
		currentRotation = 180f;
	}

	public void UpdateInput(RigidbodyFirstPersonController controller, Vector2 input)
	{
		var rotateInput = CrossPlatformInputManager.GetAxis("Mouse Y")*rotateSensitivity;

		currentRotation += rotateInput;

		swordPivot.localRotation = Quaternion.Euler(0, 0, currentRotation);

		var newGravity = swordPivot.up * 9.81f;

		DebugExtension.DebugArrow(Vector3.zero, newGravity, Color.yellow, Time.fixedDeltaTime, false);

		Physics.gravity = newGravity;
	}

}
