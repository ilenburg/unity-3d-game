using UnityEngine;
using System.Collections;

public class Storm : MonoBehaviour {

	public Light thunder;
	public Light bolt;
	public AudioSource []bangs;
	float idleTime;
	float randTime;
	float randFlash;
	bool flash;
	int count;
	

	void Start () {
		idleTime = 0;
		randTime = Random.Range(2.0f,20.0f);
		randFlash = Random.Range(0.2f,0.6f);
		count = 0;
		flash = false;
	}


	void Update () {
		idleTime += Time.deltaTime;
		if (!flash)
		{
			if (idleTime > randTime)
			{
				flash = true;
				bangs[count].Play();
				count = (count + 1) % 2;
				idleTime = 0;
				randTime = Random.Range(2.0f,20.0f);
				randFlash = Random.Range(0.2f,0.6f);
			}
		}
		else
		{
			if (idleTime > randFlash)
			{
				thunder.enabled = false;
				bolt.enabled = false;
				flash = false;
			}

			else 
			{
				if (Random.value > 0.4) thunder.enabled = true;
				else thunder.enabled = false;
				
				if (Random.value > 0.4) bolt.enabled = true;
				else bolt.enabled = false;
			}

		}
	}
}
