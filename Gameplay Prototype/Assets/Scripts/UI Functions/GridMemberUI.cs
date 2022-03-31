/**
// File Name :         GridMemberUI.cs
// Author :            Sam Dwyer
// Creation Date :     October, 2021
//
// Brief Description : Handles member UI in map
**/
using UnityEngine;
using UnityEngine.UI;

public class GridMemberUI : MonoBehaviour
{
    private Image memberHat1;
    private Text memberName1;
    private Slider memberHealth1;
    private Slider memberXP1;
    private Text memberLevel1;
    private Image memberHat2;
    private Text memberName2;
    private Slider memberHealth2;
    private Slider memberXP2;
    private Text memberLevel2;
    private Image memberHat3;
    private Text memberName3;
    private Slider memberHealth3;
    private Slider memberXP3;
    private Text memberLevel3;
    public GameObject partyMemberUI1;
    public GameObject partyMemberUI2;
    public GameObject partyMemberUI3;

    private bool partyMember2 = false;
    private bool partyMember3 = false;

    // Start is called before the first frame update
    void Start()
    {

        if (Party.party.Length == 2 || Party.party.Length == 1)
        {
            Destroy(partyMemberUI3);
        }

        if (Party.party.Length == 1)
        {
            Destroy(partyMemberUI2);
        }

        memberHat1 = partyMemberUI1.transform.GetChild(2).GetComponent<Image>();
        memberName1 = partyMemberUI1.transform.GetChild(3).GetComponent<Text>();
        memberHealth1 = partyMemberUI1.transform.GetChild(4).GetComponent<Slider>();
        memberXP1 = partyMemberUI1.transform.GetChild(5).GetComponent<Slider>();
        memberLevel1 = partyMemberUI1.transform.GetChild(6).GetComponent<Text>();

        if (partyMemberUI2.activeInHierarchy)
        {
            partyMember2 = true;
            memberHat2 = partyMemberUI2.transform.GetChild(2).GetComponent<Image>();
            memberName2 = partyMemberUI2.transform.GetChild(3).GetComponent<Text>();
            memberHealth2 = partyMemberUI2.transform.GetChild(4).GetComponent<Slider>();
            memberXP2 = partyMemberUI2.transform.GetChild(5).GetComponent<Slider>();
            memberLevel2 = partyMemberUI2.transform.GetChild(6).GetComponent<Text>();
        }

        if (partyMemberUI3.activeInHierarchy)
        {
            partyMember3 = true;
            memberHat3 = partyMemberUI3.transform.GetChild(2).GetComponent<Image>();
            memberName3 = partyMemberUI3.transform.GetChild(3).GetComponent<Text>();
            memberHealth3 = partyMemberUI3.transform.GetChild(4).GetComponent<Slider>();
            memberXP3 = partyMemberUI3.transform.GetChild(5).GetComponent<Slider>();
            memberLevel3 = partyMemberUI3.transform.GetChild(6).GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Party.party.Length == 2 || Party.party.Length == 1)
        {
            Destroy(partyMemberUI3);
        }

        if (Party.party.Length == 1)
        {
            Destroy(partyMemberUI2);
        }

        memberHat1.sprite = Party.party[0].hat;
        memberName1.text = Party.party[0].cName;
        memberHealth1.maxValue = Party.party[0].maxhp;
        memberHealth1.value = Party.party[0].hp;
        memberXP1.maxValue = Party.party[0].level * GameManager.XPtoLevel;
        memberXP1.value = Party.party[0].xp;
        memberLevel1.text = "LV:" + Party.party[0].level;

        if (partyMember2 && Party.party.Length >= 2)
        {
            memberHat2.sprite = Party.party[1].hat;
            memberName2.text = Party.party[1].cName;
            memberHealth2.maxValue = Party.party[1].maxhp;
            memberHealth2.value = Party.party[1].hp;
            memberXP2.maxValue = Party.party[1].level * GameManager.XPtoLevel;
            memberXP2.value = Party.party[1].xp;
            memberLevel2.text = "LV:" + Party.party[1].level;
        }

        if (partyMember3 && Party.party.Length == 3)
        {
            memberHat3.sprite = Party.party[2].hat;
            memberName3.text = Party.party[2].cName;
            memberHealth3.maxValue = Party.party[2].maxhp;
            memberHealth3.value = Party.party[2].hp;
            memberXP3.maxValue = Party.party[2].level * GameManager.XPtoLevel;
            memberXP3.value = Party.party[2].xp;
            memberLevel3.text = "LV:" + Party.party[2].level;
        }
    }
}
