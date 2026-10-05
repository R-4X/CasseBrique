using UnityEngine;

public  abstract class ABrick : MonoBehaviour
{
    // Abrick herite de MonoBehaviour. MonoBehaviour herite de gameobject, object... (ils sont parents)


    // protected :private mais pas pour les enfants qui hérites.
    protected int titi = 0;

    public abstract void OnExplode();
}
