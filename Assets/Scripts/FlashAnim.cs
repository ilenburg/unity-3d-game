using UnityEngine;
using System.Collections;

public class FlashAnim : MonoBehaviour {

	CharacterController control;
	Animation anim;
	Vector3 speed;
	AudioSource []steps;
	float dist;
	bool done;

	void Start()
	{
		control = GetComponent<CharacterController>();
		anim = GetComponentInChildren<Animation>();
		speed = control.velocity;
		steps = GetComponents<AudioSource>();
		done = false;
	}

	void Update () 
	{
		if (control.velocity != speed)
		{
			anim["FlashBounce"].speed = control.velocity.magnitude / 3;
			if (anim["FlashBounce"].time > 1 && !done)
			{
				done = true;
				steps[Random.Range (0,2)].Play();
			}
			if (anim["FlashBounce"].time > 2)
			{
				steps[Random.Range (0,2)].Play();
				done = false;
				anim["FlashBounce"].time = 0;
			}
		}
		speed = control.velocity;
	}
}
