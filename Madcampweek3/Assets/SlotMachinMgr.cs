using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachinMgr : MonoBehaviour
{
    public GameObject[] SlotSkillObject;
    public Button[] Slot;

    public Sprite[] SkillSprite;

    [System.Serializable]
    public class DisplayItemSlot
    {
        public List<Image> SlotSprite = new List<Image> ( );
    }
    public DisplayItemSlot[] DisplayItemSlots;

    public Image DisplayResultImage;

    public List<int> StartList = new List<int> ( );
    public List<int> ResultIndexList = new List<int> ( );
    int ItemCnt = 3;
    int[] answer = { 2, 3, 1 };
     int randomIndex;
    [SerializeField] public PlayerMove playerMove;
    // Start is called before the first frame update
    void Start ( )
    {
        for ( int i = 0 ; i < ItemCnt; i++ )
        {
            StartList.Add ( i );
        }

            for ( int j = 0 ; j < ItemCnt; j++ )
            {
                Slot[0].interactable = false;
                randomIndex = playerMove.skill;
                //randomIndex = Random.Range ( 0, StartList.Count );
                ResultIndexList.Add ( StartList[randomIndex] );
                DisplayItemSlots[0].SlotSprite[j].sprite = SkillSprite[StartList[randomIndex]];

                if ( j == 0 )
                {
                    DisplayItemSlots[0].SlotSprite[ItemCnt].sprite = SkillSprite[StartList[randomIndex]];
                }
                StartList.RemoveAt ( randomIndex );
            }

            StartCoroutine ( StartSlot ( 0 ) );
    }
    
    IEnumerator StartSlot ( int SlotIndex )
    {
        for ( int i = 0 ; i < ( ItemCnt * ( 6 + SlotIndex * 4 ) + answer[SlotIndex] ) * 2 ; i++ )
        {
            SlotSkillObject[SlotIndex].transform.localPosition -= new Vector3 ( 0, 50f, 0 );
            if ( SlotSkillObject[SlotIndex].transform.localPosition.y < 50f )
            {
                SlotSkillObject[SlotIndex].transform.localPosition += new Vector3 ( 0, 300f, 0 );
            }
            yield return new WaitForSeconds ( 0.02f );
        }
        Slot[0].interactable = true;
        // playerMove.gameManager.skill = randomIndex%3;
        // playerMove.skill = randomIndex%3;
    }

    public void ClickBtn ( int index )
    {
        DisplayResultImage.sprite = SkillSprite[ResultIndexList[index]];
    }
}