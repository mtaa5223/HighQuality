using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    int hp;

    public void LosePlayerHp(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            //»ç¸Á
        }
    }
}