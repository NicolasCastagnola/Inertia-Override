using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundLayoutManager : MonoBehaviour
{
    public List<BackgroundTile> tiles;

    [SerializeField] private float _offset = 0f;
    [SerializeField] int initialSpawn;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] BackgroundTile startingVisibleTile;

    public ObjectPool<BackgroundTile> backgroundTiles;

    private void Start()
    {
        backgroundTiles = new ObjectPool<BackgroundTile>(Factory, BackgroundTile.TurnOn, BackgroundTile.TurnOff, initialSpawn);
    }
    public BackgroundTile Factory()
    {
        BackgroundTile randomTileFromList = tiles.ElementAt(Random.Range(0, tiles.Count)).SetMyPoolReference(this);

        return Instantiate(randomTileFromList, transform);
    }
    public void SpawnTile()
    {
        var randomSelectedTile = backgroundTiles.GetObject();
        randomSelectedTile.transform.position = spawnPoint.transform.position;
        randomSelectedTile.transform.forward = spawnPoint.transform.forward;
    }
}
