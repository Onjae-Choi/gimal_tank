using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public GameObject cannon;
    public Transform firePos;
    private AudioClip fireSfx = null;
    private AudioSource sfx = null;
    private void Awake()
    {
        cannon = (GameObject)Resources.Load("Cannon"); //포탄 프리팹 리소스폴더에서 불러오기
        fireSfx = Resources.Load<AudioClip>("CannonFire"); // 사운드 파일 리소스 폴더에서 불러오기
        sfx = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0)) //마우스 왼쪽 버튼을 누르면 포탄 발사
        {
            Fire();
        }
    }
    void Fire()
    {
        sfx.PlayOneShot(fireSfx, 1.0f); //발사 사운드 실행
        Instantiate(cannon, firePos.position, firePos.rotation); //포탄 생성
    }
}
