using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform arrowPoint;
    [SerializeField] private GameObject[] arrows;
    private float cooldownTimer = Mathf.Infinity;

    private void Attack()
    {
        cooldownTimer = 0;

        arrows[FindArrows()].transform.position = arrowPoint.position;
        arrows[FindArrows()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }
    private int FindArrows()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left);

        if (cooldownTimer > attackCooldown)
            Attack();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && cooldownTimer >= attackCooldown)
            Attack();
    }

}
