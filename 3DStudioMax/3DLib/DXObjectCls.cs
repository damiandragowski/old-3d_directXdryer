using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;

namespace _DStudioMax._3DLib
{
    abstract class CDXObject : IDXObject
    {
        protected Matrix _Transform = Matrix.Identity;
        protected bool bIsVisible = true;
        protected Microsoft.DirectX.Direct3D.Device device = null;

        public CDXObject(Microsoft.DirectX.Direct3D.Device dev)
        {
            device = dev;
        }

        public void RotateYPR(float y, float p, float r)
        {
            _Transform = Matrix.RotationYawPitchRoll(y, p, r) * _Transform;
        }
        public void RotateX(float ang)
        {
            _Transform = Matrix.RotationX(ang) * _Transform;
        }
        public void RotateY(float ang)
        {
            _Transform = Matrix.RotationY(ang) * _Transform;
        }
        public void RotateZ(float ang)
        {
            _Transform = Matrix.RotationZ(ang) * _Transform;
        }

        #region Property Sheet
        /// <summary>
        /// set/get Transformation
        /// </summary>
        public Matrix Transform 
        {
            get { return _Transform; }
            set { _Transform = value; }
        }
        /// <summary>
        /// Change visibility 
        /// </summary>
        public bool Visible
        {
            get { return bIsVisible; }
            set { bIsVisible = value; }
        }

        #endregion

        #region IDXObject Members

        public virtual void Draw(Matrix worldTransform) { }
        public virtual void OnResetDevice(object sender, EventArgs e) {  }


        #endregion

        #region IDisposable Members

        public virtual void Dispose() { }

        #endregion
    }
}
