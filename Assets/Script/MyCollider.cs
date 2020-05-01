using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class MyCollider : MonoBehaviour
{
    private const float MIN_MOVE_DISTANCE = 0.001f;

    [NonSerialized]
    public new Rigidbody2D rigidbody2D;

    private ContactFilter2D contactFilter2D;

    private readonly List<RaycastHit2D> raycastHit2Ds = new List<RaycastHit2D>();

    private readonly List<RaycastHit2D> tanRaycastHit2Ds = new List<RaycastHit2D>();

    public LayerMask layerMask;

    //[NonSerialized]
    //public Vector2 velocity;

    //public float Speed = 0f;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (rigidbody2D == null)
        {
            rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        }

        rigidbody2D.hideFlags = HideFlags.NotEditable;
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        rigidbody2D.simulated = true;
        rigidbody2D.useFullKinematicContacts = false;
        rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rigidbody2D.sleepMode = RigidbodySleepMode2D.NeverSleep;
        rigidbody2D.interpolation = RigidbodyInterpolation2D.Interpolate;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigidbody2D.gravityScale = 0;

        contactFilter2D = new ContactFilter2D
        {
            useLayerMask = true,
            useTriggers = false,
            layerMask = layerMask
        };
    }

    private void OnValidate()
    {
        contactFilter2D.layerMask = layerMask;
    }



    public void MoveAs(Vector2 deltaPosition)
    {
        if (deltaPosition == Vector2.zero)
        {
            return;
        }

        Vector2 updateDeltaPosition = Vector2.zero;

        float speedDistance = deltaPosition.magnitude;
        Vector2 speedDirection = deltaPosition.normalized;

        if (speedDistance <= MIN_MOVE_DISTANCE)
        {
            speedDistance = MIN_MOVE_DISTANCE;
        }

        rigidbody2D.Cast(speedDirection, contactFilter2D, raycastHit2Ds, speedDistance);

        Vector2 finalDirection = speedDirection;
        float finalDistance = speedDistance;

        foreach (var hit in raycastHit2Ds)
        {
            //
            float moveDistance = hit.distance;

            //法线方向
            Debug.DrawLine(hit.point, hit.point + hit.normal, Color.white);
            //速度方向
            //Debug.DrawLine(hit.point, hit.point + speedDirection, Color.yellow);

            float DotDistance = Vector2.Dot(hit.normal, speedDirection);

            //夹角小于90
            if (DotDistance > 0)
            {
                moveDistance = DotDistance;
            }
            else // 夹角大于等于90
            {
                //获取法线方向
                Vector2 tanDirection = new Vector2(hit.normal.y, -hit.normal.x);
                //法线与速度点积
                float tanDot = Vector2.Dot(tanDirection, speedDirection);

                //点积小于0
                if (tanDot < 0)
                {
                    //取反
                    tanDirection = -tanDirection;
                    tanDot = -tanDot;
                }

                //确保tandot 与 speedDistance 不为零
                float tanDistance = tanDot * speedDistance;
                Debug.Log(tanDistance);
                //xuyaoyidong
                if (tanDistance != 0)
                {
                    //法线方向碰撞检测
                    rigidbody2D.Cast(tanDirection, contactFilter2D, tanRaycastHit2Ds, tanDistance);

                    foreach (var tanHit in tanRaycastHit2Ds)
                    {
                        Debug.DrawLine(tanHit.point, tanHit.point + tanDirection, Color.magenta);

                        if (Vector2.Dot(tanHit.normal, tanDirection) >= 0)
                            continue;

                        if (tanHit.distance < tanDistance)
                            tanDistance = tanHit.distance;
                    }

                    updateDeltaPosition += tanDirection * tanDistance;

                }

            }

            if (moveDistance < finalDistance)
            {
                finalDistance = moveDistance;
            }
        }

        updateDeltaPosition += finalDirection * finalDistance;

        rigidbody2D.position += updateDeltaPosition;

    }
}