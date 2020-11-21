using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public CharacterManager chrMan;
    public GameObject BattlePanel, EnemyButton;
    public Text Log;
    public EnemySO[] EnemyArray = new EnemySO[3];
    private Enemy currentEnemy;
    public void StartBattle()
    {
        currentEnemy = new Enemy(EnemyArray[0]);
        CurrentEnemy();
        BattlePanel.SetActive(true);
        EnemyButton.GetComponentInChildren<Text>().text = currentEnemy.Name;
    }
    public void CurrentEnemy()
    {
        currentEnemy.Assignment(EnemyArray[Random.Range(0, EnemyArray.Length)]);
    }
    public void AttackPlayer()
    {
        currentEnemy.HP -= chrMan.CurrentDamage + 
            (chrMan.CurrentWeapon != null ? CalculateDamage(chrMan.CurrentWeapon) : 0);
        if (currentEnemy.HP > 0) AttackEnemy();
        else
        {
            chrMan.XP += currentEnemy.XP;
            DropHandler.instance.ShowDrop(CalculateDrop());
            EndBattle();
        }
        UpdateLog();
    }
    private void AttackEnemy()
    {
        chrMan.HP -= CalculateDamage(currentEnemy);
        if (chrMan.HP < 0) LostBattle();
        UpdateLog();
    }
    private void UpdateLog()
    {
        Log.text += "Action\n";
    }
    private int CalculateDamage(Weapon weapon)
    {
        return Random.Range(weapon.DamageMin, weapon.DamageMax + 1);
    }
    private int CalculateDamage(Enemy enemy)
    {
        return Random.Range(enemy.DamageMin, enemy.DamageMax + 1);
    }
    private List<Item> CalculateDrop()
    {
        List<Item> Drop = new List<Item> { };
        for (int i = 0; i < currentEnemy.ItemArray.Length; i++)
        {
            if (Random.Range(0f, 1f) < currentEnemy.ItemChances[i])
            {
                Drop.Add(currentEnemy.ItemArray[i]);
            }
        }
        return Drop;
    }
    private void LostBattle()
    {
        BattlePanel.SetActive(false);
        Log.text = null;
    }
    private void EndBattle()
    {
        BattlePanel.SetActive(false);
        Log.text = null;
    }
}
