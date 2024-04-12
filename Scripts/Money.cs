using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static int _Money;
    public Text _Money_Text;
    private void Update()
    {
        _Money_Text.text = _Money.ToString();
    }
}

