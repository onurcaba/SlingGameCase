using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePosition3D : MonoBehaviour
{
    Rigidbody rb;

    private Vector3 firstPosition;

    public Vector3 throwDirection;
    public float throwPower = 0.5f;

    private PlayerControls playerControls;
    private InputAction release;

    [SerializeField] private Camera mainCamera;
    public float smoothValue = 0.1f;
    private Vector3 smoothPosition;

    float fatMult = 1;
    bool throwed = false;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    [SerializeField]
    GameObject ragdollMesh;
    [SerializeField]
    GameObject animatedMesh;

    public Rigidbody ragdollSystem;

    private void Awake()
    {
        firstPosition = transform.position;
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        release = playerControls.Mouse.Release;
        release.Enable();
        release.performed += ThrowPlayer;
    }


    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        //ray = mainCamera.ScreenPointToRay(Touchscreen.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit raycastHit) && !throwed)
        {
            //transform.position = raycastHit.point;
            smoothPosition = Vector3.Lerp(transform.position, raycastHit.point, smoothValue) ;
            transform.position = smoothPosition;
        }
    }

    private void ThrowPlayer(InputAction.CallbackContext context)
    {
        fatMult = 1 + skinnedMeshRenderer.GetBlendShapeWeight(0)/100;
        throwed = true;
        //rb.AddForce(throwDirection * Vector3.Distance(transform.position, firstPosition) * throwPower * fatMult, ForceMode.Impulse);
        ragdollMesh.SetActive(true);
        animatedMesh.SetActive(false);

        ragdollSystem.AddForce(throwDirection * Vector3.Distance(transform.position, firstPosition) * throwPower * fatMult, ForceMode.Impulse);
        //rb.useGravity = true;

        //rb.constraints = RigidbodyConstraints.None;

    }
}
