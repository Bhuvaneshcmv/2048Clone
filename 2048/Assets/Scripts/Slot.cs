using UnityEngine;

public class Slot : MonoBehaviour
{
    public int index { get; set;}
    private Tile tileWithin;

    public void PlaceTile(Tile tile)
    {
        tile.transform.position = transform.position;
        tile.transform.SetParent(transform);
        tileWithin = tile;
    }

    public Tile RemoveTile()
    {
        Tile tempTile = tileWithin;
        tileWithin.transform.SetParent(null);
        tileWithin = null;
        return tempTile;
    }

    public Tile GetTileWithin()
    {
        return tileWithin;
    }

    public Tile CreateTile(GameObject tile,int tileVal)
    {
        var tileGO = Instantiate(tile, transform);
        Tile numberTile = tileGO.GetComponent<Tile>();
        numberTile.SetValue(tileVal);
        return numberTile;
    }

}
