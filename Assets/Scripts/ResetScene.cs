using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public float forceValue = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<Rigidbody>().AddForce(new Vector3(0, forceValue, 0));
            StartCoroutine(SceneLoader(other));
        }
    }

    IEnumerator SceneLoader(Collider other)
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("RaycastScene 1");

    }
}
