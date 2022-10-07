using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePosition2D : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void OnEnable()
    {
        //mousePosition = playerControls.Player.
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPosition.z = 0f;
        transform.position = mouseWorldPosition;
    }
}
