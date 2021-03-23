using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{

    private static ObjectPoolingManager instance;
    public static ObjectPoolingManager Instance { get { return instance; } }

    public GameObject bulletPrefab;

    private int test = 0;
    public int bulletAmount = 20;

    private List<GameObject> bullets;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        this.bullets = new List<GameObject>(bulletAmount);

        for (int i = 0; i < bulletAmount; i++) {

            GameObject prefabInstance = Instantiate(bulletPrefab);
            prefabInstance.transform.SetParent(transform);

            prefabInstance.SetActive(false);

            this.bullets.Add(prefabInstance);

        }
    }

    public GameObject getBullet ()
    {
        
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
                

            }
        }
        
        GameObject prefabInstance = Instantiate(bulletPrefab);
        prefabInstance.transform.SetParent(transform);
        this.bullets.Add(prefabInstance);

        return prefabInstance;
        
       
    }
}
