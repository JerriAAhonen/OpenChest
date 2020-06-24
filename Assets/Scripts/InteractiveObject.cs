using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Playables;
using Debug = UnityEngine.Debug;

public class InteractiveObject : MonoBehaviour
{
	public PlayableDirector director;

	public void PerformAction()
    {
	    if (director != null)
	    {
		    // TODO: Do animation stuff
		    // TODO: Do particleSystem stuff
		    Debug.Log($"Interacted with : {gameObject}", this);
		    director.Play();
	    }
	    else
	    {
		    Debug.LogError("Didn't find an animator!");
	    }
    }
}
