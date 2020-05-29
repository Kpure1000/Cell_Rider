using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "NewBulletAsset", menuName = "New Bullet Asset")]
public class BulletAsset : ScriptableObject
{
    /// <summary>
    /// bullet asset list element class
    /// </summary>
    [Serializable]
    public class BulletAssetObject
    {
        public string Name; //  name
        public GameObject bulletObject; //  Prefab Object of bullet
    }
    /// <summary>
    /// Bullet Prefab List
    /// </summary>
    public List<BulletAssetObject> bulletAssetObjects = new List<BulletAssetObject>();
    /// <summary>
    /// Get bullet object in this pool
    /// </summary>
    public Dictionary<string, GameObject> bulletPool = new Dictionary<string, GameObject>();
    /// <summary>
    /// Get Bullet Object from bulletPool
    /// </summary>
    /// <param name="bulletName">Name of Bullet</param>
    /// <returns>GameObject</returns>
    public GameObject GetBullet(string bulletName)
    {
        if (bulletPool.ContainsKey(bulletName))
        {
            return bulletPool[bulletName];
        }
        return null;
    }

    private void OnEnable()
    {
        //Init bulletPool from Bullet Prefab List
        foreach (var item in bulletAssetObjects)
        {
            bulletPool[item.Name] = item.bulletObject;
        }
    }


}
