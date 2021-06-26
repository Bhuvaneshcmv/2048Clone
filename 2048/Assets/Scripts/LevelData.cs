using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level data", menuName = "Create Level data")]
public class LevelData : ScriptableObject
{
    public List<int> initialValuesSet = new List<int>();
    public int slotsRowCount;
    public int slotsColumnCount;

    public List<int> GetInitialTileValues(int valuesCount)
    {
        List<int> initialValues = new List<int>(valuesCount);
        initialValues = RandomList.shuffleAndGenerateRandom(initialValuesSet, valuesCount);
        return initialValues;
    }

    public List<int> GetInitialSlotIndices(int slotsToFill)
    {
        int totalSlots = slotsRowCount * slotsColumnCount;
        List<int> initialSlots = new List<int>(slotsToFill);
        initialSlots = RandomList.GetRandomNumbers(slotsToFill, totalSlots);
        return initialSlots;
    }
    
}
