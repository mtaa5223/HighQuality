using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;

    [SerializeField] private Transform parent;

    [System.Serializable]
    private class ObjectInfo
    {
        // 오브젝트 이름
        public string objectName;
        // 오브젝트
        public GameObject prefab;
        // 몇개를 생성 해놓을지
        public int count;
    }

    [SerializeField] private ObjectInfo[] objectInfos = null;

    private string objectName;

    private Dictionary<string, IObjectPool<GameObject>>
        objectPoolDic = new Dictionary<string, IObjectPool<GameObject>>();

    private Dictionary<string, GameObject> poolGoDic = new Dictionary<string, GameObject>();

    void Start()
    {
        Application.Quit();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Init();
    }

    private void Init()
    {
        for (int idx = 0; idx < objectInfos.Length; ++idx)
        {
            IObjectPool<GameObject> pool = new ObjectPool<GameObject>(CreatPooledItem, OnTakeFromPool, OnReturnedToPool,
            OnDestroyPoolObject, true, objectInfos[idx].count, objectInfos[idx].count);

            if (poolGoDic.ContainsKey(objectInfos[idx].objectName))
            {
                return;
            }

            poolGoDic.Add(objectInfos[idx].objectName, objectInfos[idx].prefab);
            objectPoolDic.Add(objectInfos[idx].objectName, pool);

            // 미리 오브젝트 생성 해놓기
            for (int i = 0; i < objectInfos[idx].count; ++i)
            {
                objectName = objectInfos[idx].objectName;
                PoolAble poolAbleGo = CreatPooledItem().GetComponent<PoolAble>();
                poolAbleGo.Pool.Release(poolAbleGo.gameObject);
            }
        }
    }

    // 생성
    private GameObject CreatPooledItem()
    {
        GameObject poolGo = Instantiate(poolGoDic[objectName]);
        poolGo.GetComponent<PoolAble>().Pool = objectPoolDic[objectName];
        poolGo.transform.parent = parent;
        return poolGo;
    }

    // 사용
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
    }

    // 변환
    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    // 삭제
    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }

    public GameObject GetGo(string goName)
    {
        objectName = goName;

        if (poolGoDic.ContainsKey(goName) == false)
        {
            return null;
        }

        return objectPoolDic[goName].Get();
    }
}