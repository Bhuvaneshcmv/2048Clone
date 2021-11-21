using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberTile : MonoBehaviour
{
    public int value;

    [SerializeField] private TextMeshProUGUI _tileValue;
    [SerializeField] private Image _image;

    public void Init(TileType type)
    {
        value = type.value;
        _image.color = type.color;
        _tileValue.text = type.value.ToString();
    }

    /*
    public int GetValue()
    {
        return value;
    }*/

  /*  public void SetValue(int val)
    {
        value = val;
        tileValue.text = val.ToString();
    }*/
}
