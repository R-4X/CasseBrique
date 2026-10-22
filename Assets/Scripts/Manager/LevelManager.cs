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
    #endregion Attributes



    #region Properties
    public static LevelManager Instance { get => instance; set => instance = value; }
    public int NbrBrickToBreak { get => _nbrBrickToBreak; set => _nbrBrickToBreak = value; }
    #region Bool for each level unlock
    //allow to know what level is unlock  == counter 1 by 1
    public int CurrentLevelIndexUnlock { get => _currentLevelIndexUnlock; set => _currentLevelIndexUnlock = value; }
    //allow to set level to unlock thank int CurrentLevelIndexUnlock
    public bool[] LevelUnlock { get => _levelUnlock; set => _levelUnlock = value; }
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
    // Allow to set True level unlock  to update UI level name and sprite
    public void SetLevelUnlock(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < LevelUnlock.Length)
        {
            LevelManager.Instance.LevelUnlock[levelIndex] = true;
            Debug.Log("Level " + levelIndex + " unlocked.");
            //UpdateUI();
        }
        else
        {
            Debug.LogWarning("Invalid level index: " + levelIndex);
        }
    }

    #endregion Methodes for UI MAJ
    #endregion Methods



}
