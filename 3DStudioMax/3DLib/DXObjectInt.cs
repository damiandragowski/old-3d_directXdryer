using System;
using System.Collections.Generic;
using System.Text;

namespace _DStudioMax._3DLib
{
    interface IDXObject : IDisposable
    {
        void Draw(Microsoft.DirectX.Matrix worldTransform);
    }
}
