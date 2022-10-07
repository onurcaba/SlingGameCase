using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManagerForwardDistantPoint : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject pivotObject;
    public GameObject targetObject;

    Quaternion staticQuaternian;

    public GameObject go;
    public GameObject go2;
    public Vector3 targetPos;

    public Vector3 newRotation;

    // Start is called before the first frame update
    void Start()
    {
        staticQuaternian = targetObject.transform.rotation;

    }

    private void Update()
    {
        //targetObject.transform.RotateAround(pivotObject.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        targetObject.transform.RotateAround(pivotObject.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        targetObject.transform.rotation = staticQuaternian;

    }

    private void DoTweenForward()
    {
        Debug.Log(go.transform.forward);
        targetPos = go.transform.position + go.transform.forward * 3;
        go.transform.DOMove(targetPos, 2f).OnComplete(() => Debug.Log(go.transform.forward));
    }
}
