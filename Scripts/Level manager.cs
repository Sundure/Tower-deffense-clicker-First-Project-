using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public static Level_Manager main;

    public Transform Start_Point;
    public Transform[] Path;

    private void Awake()
    {
        main = this;
    }
}
