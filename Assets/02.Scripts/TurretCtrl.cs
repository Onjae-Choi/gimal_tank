using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCtrl : MonoBehaviour
{
    private Transform tr;
    private RaycastHit hit; // ray와 지면이 맞은 위치를 저장하기 위한 변수
    public float rotSpeed = 5.0f; //터렛의 회전속도
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        //메인 카메라를 마우스 커서의 위치로 캐스팅되는 레이를 생성
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //생성된 Ray를 Scene 뷰에 녹색 광선으로 표현
        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.green);
        //8번째 레이어(TERRAIN)와 레이가 부딪혔다면
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
        {
            //Ray에 맞은 위치를 로컬좌표로 변환
            Vector3 relative = tr.InverseTransformPoint(hit.point);
            //역탄젠트 함수로 두 점 간 각도를 게산
            float angle = Mathf.Atan2(relative.x, relative.z) * Mathf.Rad2Deg;
            //rotSpeed 변수에 지정된 속도로 회전
            tr.Rotate(0, angle * Time.deltaTime * rotSpeed, 0);
        }
    }
}
