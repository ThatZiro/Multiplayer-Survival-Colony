using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public float interactionDistance;
    public LayerMask whatIsInteractable;

    public Transform cameraTransform;

    public Interactable interaction;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    private void Update()
    {
        interaction = null;
        RaycastHit hit;
        if(Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactionDistance, whatIsInteractable))
        {
            interaction = hit.collider.gameObject.GetComponentInParent<Interactable>();
        }
        
        if(interaction && Input.GetKeyDown(KeyCode.E))
        {
            interaction.Interact();
        }
    }
}
