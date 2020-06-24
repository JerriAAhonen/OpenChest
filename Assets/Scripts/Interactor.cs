using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
	public float interactionRange = 2f;
	public Image normalReticle;
	public Image interactionRectile;
	
	private Camera cam;
	private InteractiveObject interactiveObject;
	private RaycastHit hit;

	private bool currentlyWithinInteractionRange;
	
	void Start()
	{
		cam = Camera.main;
		normalReticle.gameObject.SetActive(true);
		interactionRectile.gameObject.SetActive(false);
	}
	
    void Update()
    {
		Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactionRange);
		
		if (hit.transform)
			ToggleRectile(true);
		else
			ToggleRectile(false);

		if (Input.GetButtonDown("Fire1"))
	    {
		    Debug.Log("Clicked");
		    if (hit.transform)
		    {
			    Debug.Log(hit.transform.name);
			    
			    interactiveObject = hit.transform.GetComponent<InteractiveObject>();
			    if (interactiveObject != null)
			    {
				    interactiveObject.PerformAction();
				    interactiveObject = null;
			    }
		    }
	    }
    }

    private void ToggleRectile(bool canInteract)
    {
	    if (canInteract && !currentlyWithinInteractionRange)
	    {
		    normalReticle.gameObject.SetActive(false);
			interactionRectile.gameObject.SetActive(true);
			currentlyWithinInteractionRange = true;
	    }
	    else if (!canInteract && currentlyWithinInteractionRange)
	    {
		    normalReticle.gameObject.SetActive(true);
		    interactionRectile.gameObject.SetActive(false);
		    currentlyWithinInteractionRange = false;
	    }
    }
}
