using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDown  : MonoBehaviour
{
    public GameObject Enemy;
    public Material[] mat = new Material[2];
    int Count = 0;

    private bool BulletAttack = false;
    private MonsterAi Ai1;

    int i = 0;


    void Start()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {

            Count++;
            Debug.Log(Count);

            if (Count % 3 == 0)
            {
                Debug.Log(Count);
                Debug.Log("기절");
                i = ++i % 2;
                
            
            if(Count > 3){
                return;
            }
                BulletAttack = true;
                
                gameObject.GetComponent<MeshRenderer>().material = mat[i];
            

                }


            }
        }
        void Update(){
            if(BulletAttack && Input.GetKeyDown(KeyCode.E)){
                Destroy(Enemy);
                Debug.Log("처형");
                BulletAttack = false;
            }
        }
    }   



















