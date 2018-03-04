using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Direct3D = Microsoft.DirectX.Direct3D;

namespace _DStudioMax._3DLib
{

    public class Camera
    {

        private Matrix view;

        public Camera(float forward, float up, float strafe)
        {
            view = Matrix.LookAtLH(new Vector3(strafe, up, forward), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        }

        public void Turn(float amount)
        {
            view.Multiply(Matrix.RotationY(0 - amount));
        }

        public void AdjustPitch(float amount)
        {
            view.Multiply(Matrix.RotationX(0 - amount));
        }

        public void Roll(float amount)
        {
            view.Multiply(Matrix.RotationZ(0 - amount));
        }

        public void Move(float forward, float up, float strafe)
        {
            Vector3 m = new Vector3(0 - strafe, 0 - up, 0 - forward);
            view.Multiply(Matrix.Translation(m));
        }

        public void SetView(Device dev, ref Matrix _view)
        {
            dev.Transform.View = view;
            _view = view;
        }
    }
}
