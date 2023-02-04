using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ColdNoodleInputManager : MonoBehaviour
{
    private AudioSource _touchAudioSource;
    public AudioSource _comboAudioSource;

    private bool nowisRight;
    // Start is called before the first frame update
    void Start()
    {
        _touchAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            tryLeftRight(false);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            tryLeftRight(true);
        }
    }

    public void left()
    {
        tryLeftRight(false);
    }

    public void right()
    {
        tryLeftRight(true);
    }
    public void tryLeftRight(bool inputIsRight)
    {
        if (ColdNoodleUIManager.Instance.leftBtn.interactable && ColdNoodleUIManager.Instance.rightBtn.interactable)
        {
            ColdNoodleGameManager.Instance.TimeCheck();
            // 왼쪽버튼이면 false 
            ColdNoodleGameManager.Instance.curChicken = ColdNoodleGameManager.Instance.DequeueChicken();
            Debug.Log($"시도 성공 : {ColdNoodleGameManager.Instance.curChicken.TryGetComponent(out ColdNoodleBasic basic)}");
            Debug.Log($"basic : {basic}");
            if (basic.isRight == inputIsRight)
            {
                ColdNoodleGameManager.Instance.PlusCombo();
                _touchAudioSource.Play();
                if (ColdNoodleGameManager.Instance.combo % 20 == 0)
                {
                    _comboAudioSource.Play();
                }
            }
            else
            {
                ColdNoodleGameManager.Instance.FailCombo(); // 여기서 GameOver 확인
            }
            // 1. 젤 아래 왼쪽, 오른쪽 보냄
            // 2. 두 번째칸부터 있는, queue에 있는 치킨 한 칸씩 아래로 옮김
            // 3. 아래로 옯기고 6번째 치킨추가
            basic.MoveLeftRight(inputIsRight);
            Debug.Log(ColdNoodleGameManager.Instance.queue.Count());
            for (int i =0 ; i < ColdNoodleGameManager.Instance.queue.Count(); i++) // Count == 5
            { //3->2 4->3 5->4
                //Basic의 Move()를 사용하기 위해서 꺼냄... 
                // queue에 있는 치킨에 접근해서 Move 다음 현재 존재하는 인덱스 필요
                ColdNoodleGameManager.Instance.curChicken = ColdNoodleGameManager.Instance.DequeueChicken();
                ColdNoodleGameManager.Instance.curChicken.TryGetComponent(out ColdNoodleBasic moveBasic);
                moveBasic.MoveNext(i+2); //i가 처음 8이고 [7]로 이동해야함 
                // 다시 넣음
                ColdNoodleGameManager.Instance.queue.Enqueue(ColdNoodleGameManager.Instance.curChicken);
            }
            ColdNoodleGameManager.Instance.EnqueueRandomChicken();
        }
    }
}
