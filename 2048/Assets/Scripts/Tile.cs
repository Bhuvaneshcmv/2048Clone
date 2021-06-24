using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int value;
    [SerializeField] private TextMeshProUGUI tileValue;

    public int GetValue()
    {
        return value;
    }

    public void SetValue(int val)
    {
        value = val;
        tileValue.text = val.ToString();
    }
}
