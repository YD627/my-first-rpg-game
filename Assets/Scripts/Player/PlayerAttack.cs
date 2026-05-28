using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // 当前装备的武器
    public Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (weapon != null)
            {
                weapon.Attack();
            }
        }
    }
    // 装备武器
    private void LoadWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }
    // 卸载武器
    private void UnLoadWeapon()
    {
        this.weapon = null;
    }
}
