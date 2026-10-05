using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private Sprite[] _stateSprite;

    private SpriteRenderer _spriteRenderer = null;
    private int _health = 1;
    private bool _breakable = false;

    #region properties fields
    public int Health { get => _health; set => _health = value; }
    public Sprite[] StateSprite { get => _stateSprite; set => _stateSprite = value; }
    #endregion properties fields


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!_breakable)
        {
            this.Health = this.StateSprite.Length;
            this._spriteRenderer.sprite = this._stateSprite[this.Health];
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
