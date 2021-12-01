using TMPro;
using UnityEngine;

public class NumberTile : MonoBehaviour
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
