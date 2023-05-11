using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [Header("Info")]
    public string characterName;
    public enum Gender { Male, Female};
    public Gender gender;

    [Header("=== Eyes ===")]
    public Color EyeColor;

    [Header("=== Facial Hair ===")]
    public int Beard;
    public GameObject[] BeardObjects;

    public int M_Eyebrow;
    public GameObject[] EyebrowObjects;
    public int F_Eyebrow;
    public GameObject[] F_EyebrowObjects;

    public int Moustache;
    public GameObject[] MustacheObjects;

    [Header("=== Hair ===")]
    public Color HairColor;
    public int Hair;
    public GameObject[] M_HairObjects;
    public GameObject[] F_HairObjects;

    [Header("=== Body ===")]
    public Color SkinColor;
    public int BodyType;
    public GameObject[] M_BodyObjects;
    public GameObject[] F_BodyObjects;

    public int HeadType;
    public GameObject[] M_HeadObjects;
    public GameObject[] F_HeadObjects;

    public int UnderwearType;
    public GameObject[] M_UnderwearObjects;
    public GameObject[] F_UnderwearObjects;

}
