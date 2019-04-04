using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

/* Controls the player. Here we chose our "focus" and where to move. */

public class PlayerController : MonoBehaviour
{

    public delegate void OnFocusChanged(Interactable newFocus);
    public OnFocusChanged onFocusChangedCallback;

    public Interactable focus;  // Our current focus: Item, Enemy etc.

    public LayerMask movementMask;      // The ground
    public LayerMask interactionMask;   // Everything we can interact with

    Camera cam;             // Reference to our camera

    // Get references
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // If we press left mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Shoot out a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If we hit
            if (Physics.Raycast(ray, out hit, 100f, movementMask))
            {

                SetFocus(null);
            }
        }

        // If we press right mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Shoot out a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If we hit
            if (Physics.Raycast(ray, out hit, 100f, interactionMask))
            {
                SetFocus(hit.collider.GetComponent<Interactable>());
            }
        }

    }

    // Set our focus to a new focus
    void SetFocus(Interactable newFocus)
    {
        if (onFocusChangedCallback != null)
            onFocusChangedCallback.Invoke(newFocus);

        // If our focus has changed
        if (focus != newFocus && focus != null)
        {
            // Let our previous focus know that it's no longer being focused
            focus.OnDefocused();
        }

        // Set our focus to what we hit
        // If it's not an interactable, simply set it to null
        focus = newFocus;

        if (focus != null)
        {
            // Let our focus know that it's being focused
            focus.OnFocused(transform);
        }

    }

}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClicker : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("Interracted");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 5f))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                Interact();
            }
        }
    }
}*/
