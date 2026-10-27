using Microsoft.Unity.VisualStudio.Editor;
using System;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    #region Attributes
    private static LevelManager instance;

    // Private values allow to change level  (Need : name scene, Nbr of brick to break to win, state SpriteRenderer od level, Name level string of UI)
    private int _currentLevelIndexUnlock = 1;
    private int _nbrBrickToBreak = 3;


    // Bool for eatch level Unlock 
    private bool[] _levelUnlock = new bool[6] { true, false, false, false, false, false}; // 6 levels for now
    private bool _level1Unlock = false; 
    private bool _level2Unlock = false;
    private bool _level3Unlock = false;
    private bool _level4Unlock = false;
    private bool _level5Unlock = false;
    private bool _level6Unlock = false;
    private bool _levelCanLoadLevel = false;
    #endregion Attributes



    #region Properties
    public static LevelManager Instance { get => instance; set => instance = value; }
    public int NbrBrickToBreak { get => _nbrBrickToBreak; set => _nbrBrickToBreak = value; }

  
    #region Bool for each level unlock
    //allow to know what level is unlock  == counter 1 by 1
    public int CurrentLevelIndexUnlock { get => _currentLevelIndexUnlock; set => _currentLevelIndexUnlock = value; }
    //allow to set level to unlock thank int CurrentLevelIndexUnlock

    public bool[] LevelUnlock { get => _levelUnlock; set => _levelUnlock = value; }
    public bool Level1Unlock { get => _level1Unlock; set => _level1Unlock = value; }
    public bool Level2Unlock { get => _level2Unlock; set => _level2Unlock = value; }
    public bool Level3Unlock { get => _level3Unlock; set => _level3Unlock = value; }
    public bool Level4Unlock { get => _level4Unlock; set => _level4Unlock = value; }
    public bool Level5Unlock { get => _level5Unlock; set => _level5Unlock = value; }
    public bool Level6Unlock { get => _level6Unlock; set => _level6Unlock = value; }


    public bool LevelCanLoadLevel { get => _levelCanLoadLevel; set => _levelCanLoadLevel = value; }
    #endregion Bool for each level unlock
    #endregion Properties



    #region Methods
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // supprime une instance précédente
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // conserve l'objet entre scènes
    }


    #region Methodes for UI MAJ



    #endregion Methodes for UI MAJ
    #endregion Methods



}
