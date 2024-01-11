using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;

    public float coolTime = 0.25f; //������ �ð�
    public float weaponRange = 5000f;
    public float hitForce = 100f;
    float nextFire;

	public Transform gunEnd;

    WaitForSeconds duration = new WaitForSeconds(0.07f); //������
	public Transform player; //ī�޶�

	LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

	void Update()
	{
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + coolTime;

            StartCoroutine(BulltetEffect());

            Vector3 rayOrigin = gunEnd.position;

            RaycastHit hit;

            lineRenderer.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, player.forward, out hit, weaponRange))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
					lineRenderer.SetPosition(1, hit.point);
				}
            }
            else
            {
                lineRenderer.SetPosition(1, rayOrigin + (player.forward * weaponRange));
            }
        }
	}

	IEnumerator BulltetEffect()
    {
        lineRenderer.enabled = true;
        yield return duration;
		lineRenderer.enabled = false;
	}
}