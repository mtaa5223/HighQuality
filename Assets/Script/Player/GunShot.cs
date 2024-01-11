using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GunShot : MonoBehaviour
{
    float coolTime = 0;

    [SerializeField] Transform firePos;
    [SerializeField] Transform player;
    [SerializeField] Animator animator;

    private AudioSource Audio;
    [SerializeField] Image ammoGage;

    public int count = 0;
    int ammo = 8;

    [SerializeField] Player playerScript;
    public bool reLoad = false;

    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        coolTime += Time.deltaTime;
        if (Input.GetMouseButton(0) && coolTime >= 0.2f && !reLoad && !playerScript.isExecuting)
        {
            if (ammo > 0)
            {
                animator.SetTrigger("Shot");

                Audio.Play();

                //ÃÑ¾Ë ¼ÒÈ¯
                var _bullet = ObjectPoolManager.Instance.GetGo("Bullet");
                _bullet.transform.position = firePos.position;
                _bullet.GetComponent<Shot>().firePos = firePos;
                _bullet.GetComponent<Shot>().player = player;

                //ºû ¼ÒÈ¯
                var _muzzleFlash = ObjectPoolManager.Instance.GetGo("MuzzleFlash");
                _muzzleFlash.transform.position = firePos.position;
                _muzzleFlash.transform.eulerAngles = firePos.eulerAngles;
                _muzzleFlash.GetComponent<MuzzleFlash>().firePos = firePos;

                //Ä«¸Þ¶ó Èçµé¸®±â
                var _cameraShake = ObjectPoolManager.Instance.GetGo("CameraShake");

                ammo--;
                coolTime = 0;
            }
        }

        if ((ammo <= 0 || Input.GetKeyDown(KeyCode.R)) && !reLoad && !playerScript.isExecuting)
        {
            StartCoroutine(ReLoadAmmo());
        }
        ammoGage.fillAmount = ammo * 0.125f;
    }

    IEnumerator ReLoadAmmo()
    {
        reLoad = true;
        if (GameManager.instance.playerHp > 0)
        {
            animator.SetTrigger("Reload");
            yield return new WaitForSeconds(0.5f);
            while (ammo < 8)
            {
                yield return new WaitForSeconds(0.01f);
                ammo++;
            }
            reLoad = false;
        }
    }
}