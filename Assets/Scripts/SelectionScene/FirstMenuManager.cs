using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstMenuManager : MonoBehaviour
{
    public Text ClassText, RaceText, FaithText, ZodiacText;
    public GameObject FirstPage, SecondPage, DropDownPrefab;
    private CharacterManager character;
    private DataScript dataScript;
    private void Start()
    {
        dataScript = GetComponent<DataScript>();
        ChooseCharacter();
    }
    private void ChooseCharacter()
    {
        character = GetComponent<CharacterManager>();
        int x;

        List<string> classes = new List<string>() { "Warrior", "Mage", "Rogue", "Ranger" };
        List<string> races = new List<string>() { "Human", "Elf", "Goblin" };
        List<string> faiths = new List<string>()
        { "Cokhi", "Wafosm", "Lovrado", "Communion of the Elements", "Sect of the Seven Divines",
            "Oracle of the Chosen" };
        List<string> zodiacs = new List<string>()
        { "Tail", "Lierta", "Laro", "Makkou", "Vao", "Tululee" };

        for (int i = 1; i < 5; i++)
        {
            var obj = Instantiate(DropDownPrefab);
            x = i % 2 == 0 ? -1 : 1;
            obj.transform.localPosition = new Vector2(-220 * x, -310f);
            Dropdown objDrop = obj.GetComponent<Dropdown>();
            objDrop.ClearOptions();
            switch (i)
            {
                case 1:
                    obj.transform.SetParent(FirstPage.transform, false);
                    objDrop.AddOptions(classes);
                    objDrop.onValueChanged.AddListener(delegate
                    { ChangeCharacterClass(objDrop.options[objDrop.value].text); });
                    break;
                case 2:
                    obj.transform.SetParent(FirstPage.transform, false);
                    objDrop.AddOptions(races);
                    objDrop.onValueChanged.AddListener(delegate
                    { ChangeCharacterRace(objDrop.options[objDrop.value].text); });
                    break;
                case 3:
                    obj.transform.SetParent(SecondPage.transform, false);
                    objDrop.AddOptions(faiths);
                    objDrop.onValueChanged.AddListener(delegate
                    { ChangeCharacterFaith(objDrop.options[objDrop.value].text); });
                    break;
                case 4:
                    obj.transform.SetParent(SecondPage.transform, false);
                    objDrop.AddOptions(zodiacs);
                    objDrop.onValueChanged.AddListener(delegate
                    { ChangeCharacterZodiac(objDrop.options[objDrop.value].text); });
                    break;
            }
        }

        ClassText.text =
                    "Warrior - powerful melee character, which deal basically physical damage." +
                    "Main stats: strength, vitality";
        RaceText.text = "Human - capable of much, balanced stats.";
        FaithText.text = "Cokhi - ancient patron of nature and freedom.";
        ZodiacText.text = "Still empty, Awaiting for u...";
    }
    private void ChangeCharacterClass(string value)
    {
        character.Class = value;
        switch (value)
        {
            case "Warrior":
                ClassText.text =
                    "Warrior - powerful melee character, which deal basically physical damage." +
                    "\nMain stats: strength, vitality";
                break;
            case "Mage":
                ClassText.text =
                    "Mage - powerful magical character, which deal basically magical damage." +
                    "\nMain stats: wisdom, intelligence";
                break;
            case "Rogue":
                ClassText.text =
                    "Rogue - sneaky melee character, which deal basically physical damage." +
                    "\nMain stats: dexterity, agility";
                break;
            case "Ranger":
                ClassText.text =
                    "Ranger - powerful ranged character, which deal basically physical damage on range." +
                    "\nMain stats: dexterity, agility";
                break;
        }
    }
    private void ChangeCharacterRace(string value)
    {
        character.Race = value;
        switch (value)
        {
            case "Human":
                RaceText.text = "Human - capable of much, balanced stats.";
                break;
            case "Elf":
                RaceText.text = "Elf - capable of magic and shooting, dexterity and wisdom increased.";
                break;
            case "Goblin":
                RaceText.text = "Goblin - capable of sneaky-tricky, agility increased.";
                break;
        }
    }
    private void ChangeCharacterFaith(string value)
    {
        character.Faith = value;
        switch(value)
        {
            case "Cokhi":
                FaithText.text = "Cokhi - ancient patron of nature and freedom.";
            break;
            case "Wafosm":
                FaithText.text = "Wafosm - path of sorcerers and magicians.";
            break;
            case "Lovrado":
                FaithText.text = "Lovrado - The path of noble and worthy warriors.";
            break;
            case "Communion of the Elements":
                FaithText.text = "CE - communion of elemental mages.";
            break;
            case "Sect of the Seven Divines":
                FaithText.text = "SSD - Sect of seven immortal beings.";
            break;
            case "Oracle of the Chosen":
                FaithText.text = "OC - Deity of the chosen, creating destinies.";
            break;
        }
    }
    private void ChangeCharacterZodiac(string value)
    {
        character.Zodiac = value;
    }
    public void LoadGame()
    {
        StartCoroutine(wait());
    }
    private IEnumerator wait()
    {
        dataScript.SaveData();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
