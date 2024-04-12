using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemyspeed : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Atributes")]
    [SerializeField] private float MoveSpeed = 1f;

    private Transform Target;
    private int Path_Index = 0;

    private void Start()
    {
        Target = Level_Manager.main.Path[0];
    }
    private void Update()
    {
        if (Vector2.Distance(Target.position, transform.position) <= 0.1f)
        {
            Path_Index++;

            if (Path_Index == Level_Manager.main.Path.Length)
            {
                EnemySpawner.On_Enemy_Destroyd.Invoke();
                Destroy(gameObject);
                return;

            }
            else
            {
                Target = Level_Manager.main.Path[Path_Index];
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 Direction = (Target.position - transform.position).normalized;

        rb.velocity = Direction * MoveSpeed;
    }
}
