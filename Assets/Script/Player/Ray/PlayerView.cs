using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public float viewRadius; //�þ� ���� ������
    [Range(0, 360)]
    public float viewAngle; //�þ� ���� ����
    public float meshResolution; //���ø� ����


    public LayerMask targetMask, obstacleMask; //Ÿ�� ����ũ, ��ֹ� ����ũ

    public List<Transform> visibleTarget = new List<Transform>(); //Ÿ�� ����ũ�� ray hit�� tranform�� ���� �ϴ� ����Ʈ

    void Start()
    {
        StartCoroutine(FindTargetDelay(0.1f)); //�ڷ�ƾ ����
    }

    IEnumerator FindTargetDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay); //delay�� ��ٸ���
            FindVisibleTarget();
        }
    }

    void FindVisibleTarget()
    {
        visibleTarget.Clear(); //����Ʈ �ʱ�ȭ
        Collider[] targetsViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsViewRadius.Length; ++i)
        {
            Transform target = targetsViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) //�þ� ���� �ȿ��ִ°�
            {
                float dstToTarget = Vector3.Distance(transform.position, target.transform.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)) //���� �������°�
                {
                    visibleTarget.Add(target);
                    targetsViewRadius[i].GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    targetsViewRadius[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else
            {
                targetsViewRadius[i].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    public Vector3 DirFromAngle(float angleDegrees, bool anglelsGlobal)
    {
        if (!anglelsGlobal)
        {
            angleDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Cos((-angleDegrees + 90) * Mathf.Deg2Rad), 0, Mathf.Sin((-angleDegrees + 90) * Mathf.Deg2Rad));
    }

	public struct ViewCastInfo
	{
		public bool hit;
		public Vector3 point;
		public float dst;
		public float angle;

		public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle)
		{
			hit = _hit;
			point = _point;
			dst = _dst;
			angle = _angle;
		}
    }

    ViewCastInfo ViewCast(float globalAngle)
    {
        Vector3 dir = DirFromAngle(globalAngle, true);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, viewRadius, obstacleMask))
        {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else
        {
            return new ViewCastInfo(false, transform.position + dir * viewRadius, viewRadius, globalAngle);
        }
    }
}