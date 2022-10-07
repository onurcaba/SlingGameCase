using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager inst;

    private void Awake()
    {
        inst = this;
    }
}
