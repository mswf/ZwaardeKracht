using UnityEngine;
using System.Collections;

public class BoxGlow : MonoBehaviour
{

	private Rigidbody rigidBody;
	private Light light;
	private float previousIntensity;

	private Material material;

	protected void Awake()
	{
		rigidBody = GetComponent<Rigidbody>();
		light = GetComponent<Light>();

		material = GetComponent<MeshRenderer>().material;
	}

	void FixedUpdate()
	{
		float intensity = 0f;

		intensity += rigidBody.angularVelocity.magnitude;
		intensity += rigidBody.velocity.magnitude;

		intensity = Mathf.Max(previousIntensity, intensity);

		light.intensity = intensity * 0.2f;

		var color = light.color;

		float H, S, V;

		Color.RGBToHSV(light.color, out H, out S, out V);
		V = intensity*0.04f;

		material.SetColor("_EmissionColor", Color.HSVToRGB(H, S, V));

		previousIntensity = intensity*0.9f;

	}
	
}
