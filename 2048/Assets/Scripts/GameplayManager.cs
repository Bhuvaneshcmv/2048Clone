using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private Slot _slot;
    [SerializeField] private List<Slot> _slots = new List<Slot>();
    [SerializeField] private GameObject _slotsParent;
    [SerializeField] private GameObject slotsRow;

    [SerializeField]
    private int slotsRowCount;

    [SerializeField] private int slotsColumnCount;
    // Start is called before the first frame update
    void Start()
    {
        CreatingSlots();
    }

    void CreatingSlots()
    {
        GameObject tempRow;
        for (int i = 0; i < slotsRowCount; i++)
        { 
            tempRow = Instantiate(slotsRow, _slotsParent.transform);
            for (int j = 0; j < slotsColumnCount; j++)
            {
                Instantiate(_slot, tempRow.transform);
            }
        }
    }
}