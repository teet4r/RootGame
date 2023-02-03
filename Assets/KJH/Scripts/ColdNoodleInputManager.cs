using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdNoodleInputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            tryLeftRight(false);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            tryLeftRight(true);
        }
    }

    void tryLeftRight(bool inputIsRight)
    {
        ColdNoodleGameManager.Instance.DequeueChicken().TryGetComponent(out ColdNoodleBasic basic);
        Debug.Log($"basic : {basic}");
        if (basic.isRight == inputIsRight)
        {
            Debug.Log("combo 증가!");
            ColdNoodleGameManager.Instance.PlusCombo();
        }
        else
        {
            Debug.Log("GameOver()");
        }
        // GameManager.Instance.Queue의 isRight 와 inputIsRight 비교,
        // 같으면 GameManager.Instance.PlusCombo() 다르면 GameMaager.Instance.GameOver
        // GameManager.Instance.Queue.Basic.Move( inputIsRight )  
    }
}
