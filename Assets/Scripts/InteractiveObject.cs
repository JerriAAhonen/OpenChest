using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Playables;
using Debug = UnityEngine.Debug;

public class InteractiveObject : MonoBehaviour
{
	public PlayableDirector director;
	public List<ParticleSystem> particleSystems;

	public void PerformAction()
    {
	    if (director != null)
	    {
		    // TODO: Do animation stuff
		    // TODO: Do particleSystem stuff
		    Debug.Log($"Interacted with : {gameObject}", this);
		    director.Play();
		    if (particleSystems.Count > 0)
		    {
			    foreach (var system in particleSystems)
			    {
				    system.Play();
			    }
		    }
	    }
	    else
	    {
		    Debug.LogError("Didn't find an animator!");
	    }
    }
}
