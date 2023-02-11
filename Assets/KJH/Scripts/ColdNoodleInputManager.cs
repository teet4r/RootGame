using System.Linq;
using UnityEngine;

public class ColdNoodleInputManager : MonoBehaviour, ICustomUpdate
{
    void OnEnable()
    {
        RegisterCustomUpdate();
    }
    public void CustomUpdate()
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
    void OnDisable()
    {
        DeregisterCustomUpdate();
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
            ColdNoodleGameManager.Instance.curChicken = ColdNoodleGameManager.Instance.DequeueChicken();
            if (ColdNoodleGameManager.Instance.curChicken.TryGetComponent(out ColdNoodleBasic basic))
            {
                if (basic.isRight == inputIsRight)
                {
                    ColdNoodleGameManager.Instance.PlusCombo();
                    SoundManager.Instance.SfxAudio.Play(Sfx.ChickenButton);
                    if (ColdNoodleGameManager.Instance.combo % 20 == 0)
                    {
                        SoundManager.Instance.SfxAudio.Play(Sfx.ChickenCombo);
                    }
                }
                else
                    ColdNoodleGameManager.Instance.FailCombo(); // 여기서 GameOver 확인
            }
            ColdNoodleGameManager.Instance.TimeCheck();
            // 1. 젤 아래 왼쪽, 오른쪽 보냄
            // 2. 두 번째칸부터 있는, queue에 있는 치킨 한 칸씩 아래로 옮김
            // 3. 아래로 옯기고 6번째 치킨추가
            basic.MoveLeftRight(inputIsRight);
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



    public void RegisterCustomUpdate()
    {
        CustomUpdateManager.Instance.RegisterCustomUpdate(this);
    }
    public void DeregisterCustomUpdate()
    {
        CustomUpdateManager.Instance.DeregisterCustomUpdate(this);
    }
}
