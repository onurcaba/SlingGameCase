using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlimFatControl : MonoBehaviour
{
    public SkinnedMeshRenderer mesh;
    float fat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            fat = other.GetComponent<FruitPickup>().fatValue;
            mesh.SetBlendShapeWeight(0, mesh.GetBlendShapeWeight(0) + fat);
            //gameObject.transform.localScale = gameObject.transform.localScale + new Vector3(fat / 100, fat / 100, fat / 100);
            gameObject.transform.DOScale(gameObject.transform.localScale + new Vector3(fat / 100, fat / 100, fat / 100), 0.5f);

            other.gameObject.SetActive(false);
        }
    }
}
