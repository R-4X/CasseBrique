using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField] private ABrick[] _bricks = null;
    [SerializeField] private Transform _brickInitialPossition = null;
    private List<ABrick> _brickList = new List<ABrick>();




    // constructeur => quand appeler avec "New". il peut prendre des parrametre diff. Plusieurs fois la meme methode 
    // constructeur est appelé automatiquement quand on instancie un objet de la classe.
    // parametre de constructeur est utilisé pour initialiser les variables de l'objet.
    protected BrickSpawner()
    {

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        for (int i = 0; i < _bricks.Length; i++)
        {
            //  _brickInitialPossition POUR FAIRE SPAWN  à l'endroit exact
            ABrick brick = Instantiate(_bricks[i], new Vector3( _brickInitialPossition.transform.position.x + i*2f,0f, 0f), Quaternion.identity, _brickInitialPossition.transform);    //i * 2.
            _brickList.Add(brick);
        }
        _brickList[0].OnExplode();
        //_brickList = new List<ABrick>(_bricks);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
