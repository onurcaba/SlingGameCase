using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttach : MonoBehaviour
{
    [SerializeField]
    GameObject playerObject;

    private float smoothValue = 0.01f;
    private Vector3 smoothPosition;

    public Vector3 ofset = new Vector3(0, 5.0f, -6.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        smoothPosition = Vector3.Lerp(Camera.main.transform.position, playerObject.transform.position + ofset, smoothValue * Vector3.Distance(Camera.main.transform.position, playerObject.transform.position));

        Camera.main.transform.position = smoothPosition;
    }
}
