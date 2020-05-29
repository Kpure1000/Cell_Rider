using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ShootSimple : MonoBehaviour
{
    public BulletAsset bulletAsset;


    //public class Bullet_test
    //{

    //}


    GameObject bulletObject;

    const int BulletMaxNum = 20;

    private void Start()
    {
        Debug.Log("TryGetBullet");
        bulletObject = bulletAsset.GetBullet("Bullet_BlackWing");
        timeBack = GetComponent<PlayerTimeBack>();
    }

    List<GameObject> Bullets = new List<GameObject>();

    private float currenttime;

    public float ShootDelay;

    public float BulletSpeed;

    public Rect BulletRange;

    private bool isShoot;

    PlayerTimeBack timeBack;


    public void Update()
    {
        ShootCheck();
        if (!Input.GetKey(KeyCode.LeftControl) && !timeBack.isBacking)
        {
            ShootUpdate();

        }
    }

    private void ShootCheck()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isShoot = true;
        }
        else
        {
            isShoot = false;
        }
    }

    private void ShootUpdate()
    {
        currenttime += Time.deltaTime;
        if (currenttime >= ShootDelay && isShoot == true)
        {
            currenttime = 0;
            if (Bullets.Count < BulletMaxNum)
            {
                //  Create new bulletObject
                Bullets.Add(ObjectsManager.instance.GetObj(bulletObject));

                //MUST SET OBJ AFTER GETOBJ!!!
                Bullets[Bullets.Count - 1].GetComponent<BulletSimple>().Shoot(transform.position + new Vector3(0, 0.5f, 0));
            }
        }

        //Update Each Bullet
        for (int i = 0;i < Bullets.Count;i++)
        {
            if(Bullets[i].GetComponent<BulletSimple>().isFly==false)
            {
                ObjectsManager.instance.RecycleObj(Bullets[i]);

                Bullets.RemoveAt(i);
            }
        }
    }
}
