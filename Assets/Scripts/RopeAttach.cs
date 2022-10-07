using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using Obi;


public class RopeAttach : MonoBehaviour
{

    private PlayerControls playerControls;
    private InputAction release;
    private bool released;

    [SerializeField]
    private GameObject characterRopeAttachPoint;
    [SerializeField]
    private GameObject RopeAttachPoint;

    //[SerializeField]
    //private ObiParticleAttachment attachment;

    private void Update()
    {
        if (!released)
        {
            RopeAttachPoint.transform.position = characterRopeAttachPoint.transform.position;
        }

    }

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        //attachment.target = characterRopeAttachPoint.transform;
        release = playerControls.Mouse.Release;
        release.Enable();
        release.performed += ReleasePlayer;
    }

    private void OnDisable()
    {
        release.Disable();
    }

    private void ReleasePlayer(InputAction.CallbackContext context)
    {
        //released = true;
        //Debug.Log("Released");
        //attachment.target = null;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ReleaseCollider"))
        {
            Debug.Log(gameObject.name);
            released = true;
        }

    }

}
