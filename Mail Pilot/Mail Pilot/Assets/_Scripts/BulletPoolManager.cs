using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;

    //TODO: create a structure to contain a collection of bullets
    private Queue<GameObject> bulletPool;

    public int queueSize;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>(queueSize);
        // TODO: add a series of bullets to the Bullet Pool
        for (int i = 0; i < queueSize; i++)
        {
            //Create temp object
            GameObject temp;
            //Instanstion a bullet
            temp = Instantiate(bullet, new Vector2(0, 0), Quaternion.identity);
            //Deactivate bullet
            temp.SetActive(false);
            //Add to queue
            bulletPool.Enqueue(temp);
        }
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        //Create temp object
        GameObject curBullet;

        //Set the object to be the first object in the queue and dequeue
        curBullet = bulletPool.Dequeue();

        //Enable the object
        curBullet.SetActive(true);

        return curBullet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        //Disable the object
        bullet.SetActive(false);

        //Add object to queue
        bulletPool.Enqueue(bullet);
    }
}
