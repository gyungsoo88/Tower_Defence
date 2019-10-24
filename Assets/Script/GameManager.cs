using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float explosion_time = 0;
    float lasercannon_time = 0;
    float time = 0;
    public static GameManager instance;
    public GameObject large;
    public GameObject medium;
    public GameObject small;

    // Start is called before the first frame update
    public AudioClip LaserCannon;
    public AudioClip LaserCooling;
    public AudioClip explosion1;
    public AudioClip laser_projectile1;
    public int stage = 1;
    public int energy;
    public int core_hp = 100;
    public int turret_mode =1;
    public bool wave_on = false;
    public bool wave_spawn = true;
    public int main_weapon_upgrade = 0;
    public int penguin_upgrade = 0;
    public int sheep_upgrade = 0;
    public int duck_upgrade = 0;
    public int mole_upgrade = 0;
    public bool laser_on = false;
    public GameObject sheep;
    public GameObject duck;
    public GameObject mole;
    public GameObject penguin;



    public TextMeshProUGUI energy_info;
    public TextMeshProUGUI core_info;
    public TextMeshProUGUI Center_info;
    public TextMeshProUGUI stage_info;
    public TextMeshProUGUI equipment_info;
    public TextMeshProUGUI upgrade_info;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        energy =1000;
        core_hp = 100;
        turret_mode = 1;
        stage = 1;
        wave_on = false;
       
    }
    void Update()
    {
        if (wave_on&&!wave_spawn)
        {
            time += Time.deltaTime;
            if (time > 6)
            {
                time = 0;
                check_for_wave_end();
            }
        }

        explosion_time += Time.deltaTime;
        if (explosion_time>1)
        {
            explosion_time = 1;
        }
        lasercannon_time += Time.deltaTime;
        if (lasercannon_time > 1)
        {
            lasercannon_time = 1;
        }

    }

    void check_for_wave_end()
    {
        GameObject enemy;
        enemy = GameObject.FindWithTag("smallone");
        if (enemy!=null)
        {
            return;
        }
        enemy = GameObject.FindWithTag("Bigone");
        if (enemy != null)
        {
            return;
        }
        enemy = GameObject.FindWithTag("Hugeone");
        if (enemy != null)
        {
            return;
        }
        ++stage;
        wave_on = false;
        Center_info.enabled = true;
        stage_info.text = "Wave " + stage;
        energy += 3000;
        energy_info.text = "Energy Point: " + energy;


    }


    public void lasercannon_sound()
    {
        GetComponent<AudioSource>().PlayOneShot(LaserCannon, 0.3f);

    }
    public void laserCooling_sound()
    {
        GetComponent<AudioSource>().PlayOneShot(LaserCooling, 0.3f);

    }
    public void explosion1_sound()
    {
        if (explosion_time > 0.6f)
        {
            GetComponent<AudioSource>().PlayOneShot(explosion1, 0.3f);
            explosion_time -= 0.6f;
        }

    }
    public void laser_projectile1_sound()
    {
        if (lasercannon_time > 0.6f)
        {
            GetComponent<AudioSource>().PlayOneShot(laser_projectile1, 0.3f);
            lasercannon_time -= 0.6f;
        }

    }
}
