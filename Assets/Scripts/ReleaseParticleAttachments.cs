using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Obi;

public class ReleaseParticleAttachments : MonoBehaviour
{
    #region
    //-----------Variables-----------
    public ObiParticleAttachment leftAttach;
    public ObiParticleAttachment rightAttach;

    private PlayerControls playerControls;
    private InputAction release;

    //ThrowPlayer Variables
    float fatMult = 1;
    bool throwed = false;

    [SerializeField]
    GameObject ragdollMesh;
    [SerializeField]
    GameObject animatedMesh;

    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Rigidbody ragdollSystem;

    private Vector3 firstPosition;

    public Vector3 throwDirection;
    public float throwPower = 0.5f;
    //-----------Variables-----------
    #endregion

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        release = playerControls.Mouse.Release;
        release.Enable();
        release.performed += ReleasePlayer;
        release.performed += ThrowPlayer;
    }

    private void OnDisable()
    {
        release.Disable();
    }

    private void ReleasePlayer(InputAction.CallbackContext context)
    {
        leftAttach.enabled = false;
        rightAttach.enabled = false;
    }


    //Throwing Player
    private void ThrowPlayer(InputAction.CallbackContext context)
    {
        fatMult = 1 + skinnedMeshRenderer.GetBlendShapeWeight(0) / 100;
        throwed = true;
        ragdollMesh.SetActive(true);
        animatedMesh.SetActive(false);

        ragdollSystem.AddForce(throwDirection * Vector3.Distance(transform.position, firstPosition) * throwPower * fatMult, ForceMode.Impulse);

        release.performed -= ThrowPlayer;
    }
}
