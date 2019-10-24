using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour {
    float speed = 0;
    float lasertime = 0;
    public GameObject[] tower= new GameObject[4];
    public GameObject[] preview_tower = new GameObject[4];
    bool transform1 = false;
    bool transform2 = true;
    bool immobility = false;
    public AudioClip LaserCharging;
    public GameObject effect2;
    GameObject close_tower;
    bool trigger = true;
    bool walking_rolling = false;
    int tower_index = 0;
    GameObject effect;
    GameObject tower_preview;
    int upgradecost;

    float time_loop = 0;
    float turret_loop = 0;
	Animator anim;
    GameObject tower_tobuild;
    int upgrade_menu = 0;


    public float minX = -360.0f;
    public float maxX = 360.0f;
    float sensX = 10f;
    float rotationX = 0.0f;

    // Use this for initialization
    void Awake()
	{
        Cursor.visible = false;
        anim = gameObject.GetComponentInChildren<Animator>();
        sensX = 60f;
        tower_tobuild = tower[0];
    }

    void Update()
    {
        transformation();
        CheckKey();

            rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
            transform.localEulerAngles = new Vector3(0, rotationX, 0);

    }


    void transformation()
    {
        if ((time_loop>1.5f)&&(!transform1))
        {
            speed = 5000;
            time_loop = 0;
            transform1 = true;
            immobility = false;
            walking_rolling = false;
        }
        else if (!transform1)
        {
            immobility = true;
            time_loop += Time.deltaTime;
            speed = 0;
        }
        if ((time_loop > 1f) && (!transform2))
        {
            speed = 5000;
            time_loop = 0;
            GetComponent<Rigidbody>().drag = 0.3f;
            transform2 = true;
            immobility =false;
            walking_rolling = true;

        }
        else if (!transform2)
        {
            immobility = true ;
            time_loop += Time.deltaTime;
            speed = 0;
        }
    }


    void CheckKey()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (upgrade_menu ==0)
            {
                GameManager.instance.upgrade_info.text = "1 : Main Weapon Upgrade\n" + "2 : Penguin Upgrade\n" + "3 : Sheep Upgrade\n" +"4 : Duck Upgrade\n"+ "5 : Mole Upgrade\n"+"E : back";
                upgrade_menu = 10;
            }
            else
            {
                GameManager.instance.upgrade_info.text = "E : Upgrade Equipments";
                upgrade_menu = 0;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (upgrade_menu == 10)
            {
                if (GameManager.instance.main_weapon_upgrade < 3)
                {
                    upgrade_menu = 1;
                    upgradecost = (GameManager.instance.main_weapon_upgrade + 1) * 4000;

                    GameManager.instance.upgrade_info.text = "Main weapon Damage+ : " + upgradecost + " energy" + "\n 1 : buy \n E : go back to menu";
                }
                else if (GameManager.instance.sheep_upgrade > 2)
                {
                    GameManager.instance.upgrade_info.text = "Reached Maximum Upgrade!" + "\n E : go back to menu";
                    upgrade_menu = 20;
                }
            }
            else if (upgrade_menu==1)
            {
                if (GameManager.instance.energy >= upgradecost&&GameManager.instance.main_weapon_upgrade<3)
                {
                    GameManager.instance.upgrade_info.text = "Main Weapon Upgrade Complete!" + "\n E : go back to menu";

                    GameManager.instance.energy -= upgradecost;
                    GameManager.instance.energy_info.text = ("Energy Point : " + GameManager.instance.energy);
                    ++GameManager.instance.main_weapon_upgrade;
                    if (GameManager.instance.main_weapon_upgrade == 1)
                    {
                        GetComponentInChildren<VolumetricLines.VolumetricLineBehavior>().LineColor = Color.green;
                    }
                    else if (GameManager.instance.main_weapon_upgrade == 2)
                    {
                        GetComponentInChildren<VolumetricLines.VolumetricLineBehavior>().LineColor = Color.yellow;
                    }
                    else if (GameManager.instance.main_weapon_upgrade == 3)
                    {
                        GetComponentInChildren<VolumetricLines.VolumetricLineBehavior>().LineColor = Color.white;
                    }
                    upgrade_menu = 20;
                }
                else if(GameManager.instance.main_weapon_upgrade>2)
                {
                    GameManager.instance.upgrade_info.text = "Reached Maximum Upgrade!" + "\n E : go back to menu";
                    upgrade_menu = 20;
                }
                else
                {
                    GameManager.instance.upgrade_info.text = "Not enough Energy!" + "\n E : go back to menu";
                    upgrade_menu = 20;
                }

            }
            else if (upgrade_menu == 2)
            {
                if (GameManager.instance.energy >= upgradecost)
                {
                    GameManager.instance.upgrade_info.text = "Penguin Tower Upgrade Complete!" + "\n E : go back to menu";
                    GameManager.instance.energy -= upgradecost;
                    GameManager.instance.energy_info.text = ("Energy Point : " + GameManager.instance.energy);
                    ++GameManager.instance.penguin_upgrade;
                    upgrade_menu = 20;
                }
                else if (GameManager.instance.penguin_upgrade > 2)
                {
                    GameManager.instance.upgrade_info.text = "Reached Maximum Upgrade!" + "\n E : go back to menu";
                    upgrade_menu = 20;
                }
                else
                {
                    GameManager.instance.upgrade_info.text = "Not enough Energy!" + "\n E : go back to menu";
                    upgrade_menu = 20;
                }
                
            }
            else if (upgrade_menu == 3)
            {
                if (GameManager.instance.energy >= upgradecost)
                {
                    GameManager.instance.upgrade_info.text = "Sheep Tower Upgrade Complete!" + "\n E : go back to menu";
                    GameManager.instance.energy -= upgradecost;
                    GameManager.instance.energy_info.text = ("Energy Point : " + GameManager.instance.energy);
                    ++GameManager.instance.sheep_upgrade;
                    upgrade_menu = 20;
                }
                else if (GameManager.instance.sheep_upgrade > 2)
                {
                    GameManager.instance.upgrade_info.text = "Reached Maximum Upgrade!" + "\n E : go back to menu";
                    upgrade_menu = 20;
                }
                else
                {
                    GameManager.instance.upgrade_info.text = "Not enough Energy!" + "\n E : go back to menu";
                    upgrade_menu = 20;
                }
            }
            else if (upgrade_menu == 4)
            {
                if (GameManager.instance.energy >= upgradecost)
                {
                    GameManager.instance.upgrade_info.text = "Duck Tower Upgrade Complete!" + "\n E : go back to menu";
                    GameManager.instance.energy -= upgradecost;
                    GameManager.instance.energy_info.text = ("Energy Point : " + GameManager.instance.energy);
                    ++GameManager.instance.duck_upgrade;
                    upgrade_menu = 20;
                }
                else if (GameManager.instance.sheep_upgrade > 2)
                {
                    GameManager.instance.upgrade_info.text = "Reached Maximum Upgrade!" + "\n E : go back to menu";
                    upgrade_menu = 20;
                }
                else
                {
                    GameManager.instance.upgrade_info.text = "Not enough Energy!" + "\n E : go back to menu";
                    upgrade_menu = 20;
                }
            }
            else if (upgrade_menu == 5)
            {
                if (GameManager.instance.energy >= upgradecost)
                {
                    GameManager.instance.upgrade_info.text = "Mole Tower Upgrade Complete!" + "\n E : go back to menu";
                    GameManager.instance.energy -= upgradecost;
                    GameManager.instance.energy_info.text = ("Energy Point : " + GameManager.instance.energy);
                    ++GameManager.instance.mole_upgrade;
                    upgrade_menu = 20;
                }
                else if (GameManager.instance.sheep_upgrade > 2)
                {
                    GameManager.instance.upgrade_info.text = "Reached Maximum Upgrade!" + "\n E : go back to menu";
                    upgrade_menu = 20;
                }
                else
                {
                    GameManager.instance.upgrade_info.text = "Not enough Energy!" + "\n E : go back to menu";
                    upgrade_menu = 20;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (upgrade_menu == 10)
            {
                if (GameManager.instance.penguin_upgrade < 3)
                {
                    upgrade_menu = 2;
                    upgradecost = (GameManager.instance.penguin_upgrade + 1) * 4000;
                    GameManager.instance.upgrade_info.text = "Penguin Tower Damage+ : " + upgradecost + " energy" + "\n 1 : buy \n E : go back to menu";
                }
                else
                {
                    upgrade_menu = 30;
                    GameManager.instance.upgrade_info.text = "Reached Max Upgrade " + "\n E : go back to menu";
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (upgrade_menu == 10)
            {
                if (GameManager.instance.sheep_upgrade < 3)
                {
                    upgrade_menu = 3;
                    upgradecost = (GameManager.instance.sheep_upgrade + 1) * 4000;
                    GameManager.instance.upgrade_info.text = "Sheep Tower Damage+ : " + upgradecost + " energy" + "\n 1 : buy \n E : go back to menu";
                }
                else
                {
                    upgrade_menu = 30;
                    GameManager.instance.upgrade_info.text = "Reached Max Upgrade " + "\n E : go back to menu";
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (upgrade_menu == 10)
            {
                if (GameManager.instance.duck_upgrade < 3)
                {
                    upgrade_menu = 4;
                    upgradecost = (GameManager.instance.duck_upgrade + 1) * 4000;
                    GameManager.instance.upgrade_info.text = "Duck Tower Damage+ : " + upgradecost + " energy" + "\n 1 : buy \n E : go back to menu";
                }
                else
                {
                    upgrade_menu = 30;
                    GameManager.instance.upgrade_info.text = "Reached Max Upgrade " + "\n E : go back to menu";
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (upgrade_menu == 10)
            {
                if (GameManager.instance.mole_upgrade < 3)
                {
                    upgrade_menu = 5;
                    upgradecost = (GameManager.instance.mole_upgrade + 1) * 4000;
                    GameManager.instance.upgrade_info.text = "Mole Tower Damage+ : " + upgradecost + " energy" + "\n 1 : buy \n E : go back to menu";
                }
                else
                {
                    upgrade_menu = 30;
                    GameManager.instance.upgrade_info.text = "Reached Max Upgrade " + "\n E : go back to menu";
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            tower_index = (1+tower_index) % 4;
            tower_tobuild = tower[tower_index];
            
            if(tower_index==0)
            {
                GameManager.instance.equipment_info.text = "Penguin Tower\n" +"1000 Energy";
                GameManager.instance.penguin.SetActive(true);
                GameManager.instance.sheep.SetActive(false);
                GameManager.instance.duck.SetActive(false);
                GameManager.instance.mole.SetActive(false);
            }
            if (tower_index == 1)
            {
                GameManager.instance.equipment_info.text = "Sheep Tower\n" +"1000 Energy";
                GameManager.instance.penguin.SetActive(false);
                GameManager.instance.sheep.SetActive(true);
                GameManager.instance.duck.SetActive(false);
                GameManager.instance.mole.SetActive(false);
            }
            if (tower_index == 2)
            {
                GameManager.instance.equipment_info.text = "Mole Tower\n" +"1000 Energy";
                GameManager.instance.penguin.SetActive(false);
                GameManager.instance.sheep.SetActive(false);
                GameManager.instance.duck.SetActive(false);
                GameManager.instance.mole.SetActive(true);
            }
            if (tower_index == 3)
            {
                GameManager.instance.equipment_info.text = "Duck Tower\n" +"1000 Energy";
                GameManager.instance.penguin.SetActive(false);
                GameManager.instance.sheep.SetActive(false);
                GameManager.instance.duck.SetActive(true);
                GameManager.instance.mole.SetActive(false);
            }


        }

        if (Input.GetMouseButton(1) && !walking_rolling && GameManager.instance.energy >= 1000)
        {
            if (!transform2)
            {
                anim.SetBool("Roll_Anim", false);
            }

            if (trigger)
            {
                close_tower = null;
                search_close_turret();
                if (close_tower == null)
                    return;

                else if (8000 < Vector2.SqrMagnitude(new Vector2(transform.position.x - close_tower.transform.position.x, transform.position.z - close_tower.transform.position.z)))
                {
                    search_exit();
                    close_tower = null;
                    return;
                }
                tower_preview = Instantiate(preview_tower[tower_index], new Vector3(close_tower.transform.position.x, 0, close_tower.transform.position.z), transform.rotation);

                tower_preview.transform.Rotate(0, -90, 0);
                effect = Instantiate(effect2, new Vector3(close_tower.transform.position.x, 0, close_tower.transform.position.z), Quaternion.identity);
                GetComponent<AudioSource>().PlayOneShot(LaserCharging, 0.3f);
                search_exit();
                trigger = false;
            }
            turret_loop += Time.deltaTime;
            anim.SetBool("Walk_Anim", false);

            if (turret_loop > 2)
            {
                search_close_turret();
                close_tower.tag = "tower_built";
                Destroy(tower_preview);
                GameObject Tower = Instantiate(tower_tobuild, new Vector3(close_tower.transform.position.x, 0, close_tower.transform.position.z), transform.rotation);
                GameManager.instance.energy -= 1000;
                GameManager.instance.energy_info.text = "Energy Point : " + GameManager.instance.energy;
                search_exit();
                Tower.transform.Rotate(0, -90, 0);
                turret_loop = 0;
                trigger = true;

            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            trigger = true;
            turret_loop = 0;
            Destroy(effect);
            if (tower_preview != null)
            {
                Destroy(tower_preview);
            }
        }
            

            
            
            else if (Input.GetKeyDown(KeyCode.R))
            {
                anim.SetBool("Walk_Anim", false);
                if (anim.GetBool("Roll_Anim"))
                {
                    transform1 = false;
                    anim.SetBool("Roll_Anim", false);
                    GetComponent<Rigidbody>().drag = 2;

                }
                else
                {
                
                anim.SetBool("Roll_Anim", true);
                transform2 = false;


            }
            }
        

        else if (anim != null && !immobility)

        {
            if (Input.GetMouseButton(0) && !walking_rolling&& !GetComponentInChildren<MeshRenderer>().enabled&&!GameManager.instance.laser_on)
            {

                   GetComponentInChildren<MeshRenderer>().enabled = true;
                   GetComponentInChildren<BoxCollider>().enabled = true;
                GameManager.instance.laser_on = true;

            }

            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("Walk_Anim", true);
                GetComponent<Rigidbody>().AddRelativeForce(0, 0, speed * Time.deltaTime);

            }

            if (Input.GetKey(KeyCode.S))
            {
                GetComponent<Rigidbody>().AddRelativeForce(0, 0, -speed * Time.deltaTime);

                anim.SetBool("Walk_Anim", true);
            }



            // Rotate Left
            if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool("Walk_Anim", true);
                GetComponent<Rigidbody>().AddRelativeForce(-speed * Time.deltaTime, 0, 0);
            }


            // Rotate Right
            if (Input.GetKey(KeyCode.D))
            {
                anim.SetBool("Walk_Anim", true);
                GetComponent<Rigidbody>().AddRelativeForce(speed * Time.deltaTime, 0, 0);
            }
            // Roll

        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Walk_Anim", false);
        }


    }

    void search_close_turret()
    {
        GameObject towers;
        if (close_tower == null)
        {
            close_tower = GameObject.FindWithTag("tower_holders");
        }
        towers = GameObject.FindWithTag("tower_holders");
        if (towers == null) 
          return;
        float a = Vector2.SqrMagnitude(new Vector2(transform.position.x - close_tower.transform.position.x, transform.position.z - close_tower.transform.position.z));
        float b = Vector2.SqrMagnitude(new Vector2(transform.position.x - towers.transform.position.x, transform.position.z - towers.transform.position.z));
        if (a<=b)
        {
            close_tower.tag = "tower_checked";
            towers.tag = "tower_checked";
            search_close_turret();
        }
        else
        {
            close_tower.tag = "tower_checked";
            towers.tag = "tower_checked";
            close_tower = towers;
            search_close_turret();
        }
    }
    void search_exit()
    {
        
        GameObject towers;
        towers = GameObject.FindWithTag("tower_checked");
        if (towers == null)
            return;
        towers.tag = "tower_holders";
        search_exit();
        

    }

}

