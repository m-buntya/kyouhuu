using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSwitcher : MonoBehaviour
{
    [SerializeField] private Collider2D _colA;
    [SerializeField] private Collider2D _colB;
    [SerializeField] private Collider2D _colC;

    public bool ignoreCollision;
    private bool _ignoreCollisionCache;
    void Start()
    {
        _ignoreCollisionCache = ignoreCollision;
    }

    // Update is called once per frame
    void Update()
    {
        if (_ignoreCollisionCache!=ignoreCollision)
        {
            Physics2D.IgnoreCollision(_colA, _colB, ignoreCollision);
            Physics2D.IgnoreCollision(_colA, _colC, ignoreCollision);
            Physics2D.IgnoreCollision(_colB, _colC, ignoreCollision);

            _ignoreCollisionCache = ignoreCollision;
        }
    }

    private void ApplyIgnoreCollision()
    {
        Debug.Log("Applying collision ignore: " + ignoreCollision);
        Debug.Log("Collider A: " + _colA);
        Debug.Log("Collider B: " + _colB);
        Debug.Log("Collider C: " + _colC);

        if (_colA != null && _colB != null)
        {
            Physics2D.IgnoreCollision(_colA, _colB, ignoreCollision);
        }
        if (_colA != null && _colC != null)
        {
            Physics2D.IgnoreCollision(_colA, _colC, ignoreCollision);
        }
        if (_colB != null && _colC != null)
        {
            Physics2D.IgnoreCollision(_colB, _colC, ignoreCollision);
        }
    }
}
