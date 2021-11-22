using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDDOL : MonoBehaviour
{
    public GameObject TitleUI;

    void Awake()
    {
        DontDestroyOnLoad(TitleUI);
    }
}
