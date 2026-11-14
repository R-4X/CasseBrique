using UnityEngine;

public class PlayAudiosource : MonoBehaviour
{
    #region properties fields
    [Header("Sound")]
    [SerializeField] private AudioClip _creditSound;
    [SerializeField] private AudioClip _playSound;
    [SerializeField] private AudioClip _quitSound;
    [SerializeField] private AudioClip _hoverSound;
    [SerializeField] private AudioSource _audioSourceReference;
    #endregion properties fields

    private void PlayCreditSound()
    {
        _audioSourceReference.PlayOneShot(_creditSound);
    }

    private void PlayLevelSound()
    {
        _audioSourceReference.PlayOneShot(_playSound);
    }

    private void PlayQuitSound()
    {
        _audioSourceReference.PlayOneShot(_quitSound);
    }

    private void HoverButoon()
    {
        _audioSourceReference.PlayOneShot(_hoverSound);
    }
}
