using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] private float tileObjectSize = 1;
    private float tileDespawnDistance = -20;
    private bool shouldSpawnGround = true;

    [SerializeField] private BackgroundLayoutManager myReturnPoolReference;

    void Update()
    {
        transform.position += -transform.up * Time.deltaTime * speed;

        if (transform.position.y <= tileObjectSize && shouldSpawnGround)
        {
            myReturnPoolReference.SpawnTile();
            shouldSpawnGround = false;
        }
        if (transform.position.y <= tileDespawnDistance)
        {
            myReturnPoolReference.backgroundTiles.ReturnObject(this);
            shouldSpawnGround = true;
        }
    }

    public static void TurnOn(BackgroundTile tile)
    {
        tile.gameObject.SetActive(true);
    }

    public static void TurnOff(BackgroundTile tile)
    {
        tile.gameObject.SetActive(false);
    }

    public BackgroundTile SetMyPoolReference(BackgroundLayoutManager reference)
    {
        myReturnPoolReference = reference;

        return this;
    }
}
