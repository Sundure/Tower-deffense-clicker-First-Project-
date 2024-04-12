using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panelscritp : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    public void Panel_Check()
    {
        if (Panel != null)
        {
            if (Panel.activeSelf)
            {
                Panel.SetActive(false);
            }
            else
            {
                Panel.SetActive(true);
            }
        }
    }
    public bool Is_Panel_Active
    {
        get { return Panel.activeSelf;}
    }
}
