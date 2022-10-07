using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class OdinTestClass : MonoBehaviour
{
    public enum Options
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public Options options;

    [ShowIf("options", Options.Monday)]
    public float timeOfDay;

    [ShowIf("options", Options.Tuesday)]
    public float dayOfWeek;


}
