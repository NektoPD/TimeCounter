using System.Collections;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private float _timeInterval = 0.5f;
    private float _timeGap = 1;
    private float _startTime = 0;
    private float _currentTime;
    private bool _isPlaying = false;
    private Coroutine _coroutine;

    private void Start()
    {
        _text.text = _startTime.ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!_isPlaying)
            {
                _isPlaying = true;
                _coroutine = StartCoroutine(Counter());
            }
            else
            {
                _isPlaying = false;
                StopCoroutine(_coroutine);
            }
        }
    }

    private IEnumerator Counter()
    {
        WaitForSeconds interval = new WaitForSeconds(_timeInterval);

        while (true)
        {
            _currentTime += _startTime + _timeGap;
            _text.text = _currentTime.ToString();

            yield return interval;
        }
    }
}
