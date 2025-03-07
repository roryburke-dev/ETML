using System;
using UnityEngine;

namespace ETML.Model
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Letter : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Sprite _sprite;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public Transform GetTransform()
        {
            return this.gameObject.transform;
        }

        public void SetTransform(Transform transformParam)
        {
            this.gameObject.transform.SetParent(transformParam.parent, false);
            this.gameObject.transform.localPosition = transformParam.localPosition;
            this.gameObject.transform.localRotation = transformParam.localRotation;
            this.gameObject.transform.localScale = transformParam.localScale;
        }
        
        public void SetPosition(Vector3 positionParam)
        {
            this.gameObject.transform.position = positionParam;
        }

        public void SetPosition(float x, float y, float z)
        {
            SetPosition(new Vector3(x, y, z));
        }

        /// <summary>
        /// 0 - X axis,
        /// 1 - Y axis,
        /// 2 - Z axis
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="axis"></param>
        public void SetRotation(float angle, int axis)
        {
            var axisVector = axis switch
            {
                0 => new Vector3(1, 0, 0),
                1 => new Vector3(0, 1, 0),
                2 => new Vector3(0, 0, 1),
                _ => new Vector3()
            };
            this.gameObject.transform.rotation = Quaternion.AngleAxis(angle, axisVector);
        }

        public void SetRotation(Vector3 rotation)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(rotation);
        }

        public void SetScale(Vector3 scale)
        {
            this.transform.localScale = scale;
        }

        public void SetScale(float x, float y, float z)
        {
            SetScale(new Vector3(x, y, z));
        }

        public void SetParent(Transform parentParam)
        {
            this.gameObject.transform.parent = parentParam;
        }

        public Transform GetParentTransform()
        {
            return this.gameObject.transform.parent;
        }

        public Sprite GetSprite()
        {
            SetPosition(new Vector3(0, 0, 0));
            SetPosition(0,0,0);
            return _sprite;
        }

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
            _spriteRenderer.sprite = _sprite;
        }

        public SpriteRenderer GetSpriteRenderer()
        {
            return _spriteRenderer;
        }

        public void ChangeColor(ENUMColor color)
        {
            var c = color switch
            {
                ENUMColor.Red => Color.red,
                ENUMColor.Green => Color.green,
                ENUMColor.Blue => Color.blue,
                ENUMColor.Yellow => Color.yellow,
                ENUMColor.Pink => Color.magenta,
                ENUMColor.Purple => Color.white,
                ENUMColor.Grey => Color.gray,
                ENUMColor.BlueGrey => Color.blue,
                _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
            };
            _spriteRenderer.color = c;
        }
    }
}
