﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBomb : EnemyBrick
{
    [SerializeField]
    private Vector2 damageArea;
    public Vector2 DamageArea { get => damageArea; set => damageArea = value; }

    [SerializeField]
    private LayerMask whatIsDestroyableBrick;
    public LayerMask WhatIsDestroyableBrick { get => whatIsDestroyableBrick; set => whatIsDestroyableBrick = value; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        if (isRandomColor)
            SetColor(SortRandomColor());
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void Explode()
    {
        CastDamageOnArea();
        DestroyObject();
    }

    public void CastDamageOnArea()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, damageArea.x, WhatIsDestroyableBrick);

        if (colliders != null && colliders.Length > 0)
        {
            foreach (Collider2D col in colliders)
            {
                col.gameObject.GetComponent<DestroyableBrick>().HandleDamage(1);
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, damageArea.x);
    }
#endif
}
