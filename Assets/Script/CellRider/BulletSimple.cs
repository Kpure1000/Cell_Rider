using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletSimple : MonoBehaviour
{

    public float FlySpeed;

    public Rect LifeRange;

    public bool isFly = false;

    TimeBackSimple timeBack;

    private void Start()
    {
        timeBack = GetComponent<TimeBackSimple>();
    }

    private void Update()
    {
        if (isFly && !timeBack.isTimeBacking)
        {
            ShootUpdate();
        }
    }

    public void Shoot(Vector2 startPosition)
    {
        transform.position = startPosition;
        isFly = true;
    }

    public void ShootUpdate()
    {
        if(LifeRange.Contains(new Vector2( transform.position.x,transform.position.y)))
        {
            transform.position += new Vector3(0f, FlySpeed * Time.deltaTime, 0f);
        }
        else
        {
            Stop();
        }
    }

    public void Stop()
    {
        timeBack.objectStates.Clear();
        isFly = false;
    }
}

