using UnityEngine;
using System.Collections;

public class EffectSelfDestruct : MonoBehaviour {
	
	//Attach this script to your particle effect if you want it to autodestruct after playing.

	void Start () {
		ParticleSystem p = (ParticleSystem)gameObject.GetComponent("ParticleSystem");
		//Get the Duration Value from the Particle System Component and destroy the particle after the duration
	 	Destroy(gameObject,p.duration); 
	}
	
}
