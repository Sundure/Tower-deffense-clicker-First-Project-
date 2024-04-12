using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPModel : MonoBehaviour
{
    [SerializeField] private int Enemy_HP;
    private int Cursor_Damage = 1;
    private int Take_Damage;
    public Money _Money;

    private void Start()
    {
        Collider2D _Collider = gameObject.AddComponent<BoxCollider2D>();
        _Collider.isTrigger = true;
    }

    private void OnMouseDown()
    {
        CursorDamage();
    }
    private void CursorDamage()
    {
        Take_Damage = Cursor_Damage;
        Enemy_HP -= Take_Damage;
        if (Enemy_HP <= 0)
        {
            Money._Money++;
            Destroy(gameObject);
        }
    }
}
