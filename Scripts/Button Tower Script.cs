using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void On_Click()
    {
        Click_Ivent();
    }

    private void Click_Ivent()
    {
        int Money_Value = Money._Money;
        if (Money_Value > 0)
        {
            Money_Value =- 10;
        }
    }
}
