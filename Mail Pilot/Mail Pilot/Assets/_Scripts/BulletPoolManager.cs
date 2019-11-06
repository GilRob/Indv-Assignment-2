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
            GameObject temp;
            temp = Instantiate(bullet, new Vector2(0, 0), Quaternion.identity);
            temp.SetActive(false);
            bulletPool.Enqueue(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        GameObject curBullet;

        curBullet = bulletPool.Dequeue();

        curBullet.SetActive(true);

        return curBullet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.SetActive(false);

        bulletPool.Enqueue(bullet);
    }
}
