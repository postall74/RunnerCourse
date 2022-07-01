using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _image;
    private float _imageUVPositionX;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        _imageUVPositionX += _speed * Time.deltaTime;

        if (_imageUVPositionX > 1)
            _imageUVPositionX = 0;

        _image.uvRect = new Rect(_imageUVPositionX, 0, _image.uvRect.width, _image.uvRect.height);
    }
}
