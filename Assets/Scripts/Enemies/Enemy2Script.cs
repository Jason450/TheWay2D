﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    [Header("Other Scripts")]
    public PlayerScript player;
    [Header("Stats")]
    public float speed;
    public int damage = 1;
    [Header("Physics")]
    public Transform enemy;
    private Vector2 enemyPos;

    void Start()
    {
        enemyPos = new Vector2(15, enemy.position.y);
    }

    void Update()
    {
        speed += 0.1f * Time.deltaTime;
        enemyPos.x -= speed * Time.deltaTime;
        enemy.position = new Vector3(enemyPos.x, enemyPos.y, 0);

        if (enemyPos.x <= -10)
        {
            enemyPos.x = Random.Range(10, 15);
            Debug.Log(enemyPos.x);
        }

        if(speed >= 15) speed = 15;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.RecieveDamage(damage);
        Reset();
    }

    public void Reset()
    {
        enemyPos = new Vector2(20, enemy.position.y);
    }
}