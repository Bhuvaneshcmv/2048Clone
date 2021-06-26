using System.Collections.Generic;
using Random = UnityEngine.Random;

public static class RandomList
{
    public static List<T> shuffleAndGenerateRandom<T>(List<T> objectList, int len)
    {
        List<T> outputList = new List<T>();
        for (int i = 0; i < len; i++)
        {
            int randomIndex = Random.Range(0,  objectList.Count);
            outputList.Add(objectList[randomIndex]);
        }

        return outputList;
    }
    public static List<T> ShuffleAndGenerateUniqueRandom<T>(List<T> objectList, int len)
    {
        /*List<T> copyOfObjectlist = new List<T>();
        foreach ( T t in objectList )
        {
            copyOfObjectlist.Add(t);
        }*/
        List<T> outputList = new List<T>(len);
        for (int i = 0; i < len; i++)
        {
            int randomIndex = Random.Range(0,  objectList.Count);
            outputList.Add(objectList[randomIndex]);
            objectList.RemoveAt(randomIndex); //copyOfObjectlist.RemoveAt(randomIndex);
        }
        return outputList;
    }
    
    public static List<int> GetRandomNumbers(int len, int maxValue, int minValue = 0)
    {
        List<int> allNumbers = new List<int>();
        for (int i = minValue; i < maxValue; i++)
        {
            allNumbers.Add(i);
        }
        List<int> randomNumbers = new List<int>(len);
        randomNumbers = ShuffleAndGenerateUniqueRandom(allNumbers, len);
        return randomNumbers;
    }
}
