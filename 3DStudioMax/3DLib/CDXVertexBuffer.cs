using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Direct3D = Microsoft.DirectX.Direct3D;

namespace _DStudioMax._3DLib
{
    class CDXVertexBuffer:CDXObject
    {
        private CustomVertex.PositionNormalTextured[] vertices = null;
        private VertexBuffer vb=null;
        private VertexDeclaration vd=null;
        private int[] indices;
        private IndexBuffer ib;

        public Texture texture = null;
        private Material material;

        public bool LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                return false;

            StreamReader sr = File.OpenText(fileName);
            string temp;
            string[] space = { " " };
            bool positions = true;
            int i=0;

            while (!sr.EndOfStream)
            {
                temp=sr.ReadLine();
                string[] str = temp.Split(space, StringSplitOptions.None);
                if (str.Length == 1)
                {
                    if (positions)
                    {
                        i=0;
                        positions = false;
                        vertices = new CustomVertex.PositionNormalTextured[Int32.Parse(str[0])];
                    }
                    else
                    {
                        i=0;
                        indices = new int[Int32.Parse(str[0]) * 3];
                    }
                }
                else if (str.Length == 9)
                {
                        vertices[i].X = float.Parse(str[0]) ;
                        vertices[i].Y = float.Parse(str[1])  ;
                        vertices[i].Z = float.Parse(str[2])  ;
                        vertices[i].Nx = float.Parse(str[3]);
                        vertices[i].Ny = float.Parse(str[4]);
                        vertices[i].Nz = float.Parse(str[5]);
                        vertices[i].Tu = float.Parse(str[6]);
                        vertices[i].Tv = float.Parse(str[7]);
                        ++i;                    
                }
                else if (str.Length == 3)
                {
                        indices[i] = Int32.Parse(str[0]);
                        indices[++i] = Int32.Parse(str[1]);
                        indices[++i] = Int32.Parse(str[2]);
                         ++i;                    
                }


            }
            OnResetDevice(device, null);


            return true;
        }

        public void LoadTexture(string fileName)
        {
            material = new Material();

            material.Diffuse = Color.White;
            material.Specular = Color.White;
            material.SpecularSharpness = 55.0F;

            texture = TextureLoader.FromFile(device, fileName);
        }


        public CDXVertexBuffer(Microsoft.DirectX.Direct3D.Device dev):base(dev)
        {

        }

        public override void OnResetDevice(object sender, EventArgs e)
        {
            device = (Device)sender;
            if ( vertices == null )
                return;

            vb = new VertexBuffer(typeof(CustomVertex.PositionNormalTextured), vertices.Length, device, Usage.Dynamic | Usage.WriteOnly, CustomVertex.PositionNormalTextured.Format, Pool.Default);
            vb.SetData(vertices, 0, LockFlags.None);

            VertexElement[] velements = new VertexElement[]
             {
                 new VertexElement(0, 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 0),
                 new VertexElement(0, 12, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Normal, 0),
                 new VertexElement(0, 24, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate, 0),        
                 VertexElement.VertexDeclarationEnd
             };

            vd = new VertexDeclaration(device, velements);
            ib = new IndexBuffer(typeof(int), indices.Length, device, Usage.WriteOnly, Pool.Default);
            ib.SetData(indices, 0, LockFlags.None);
        }

        public override void Draw(Microsoft.DirectX.Matrix worldTransform)
        {
            if (vertices == null)
                return;

            device.Transform.World = _Transform * worldTransform;

            if (texture != null)
            {
                device.Material = material;
                device.SetTexture(0, texture);
            }


            device.VertexFormat = CustomVertex.PositionNormalTextured.Format;
            device.SetStreamSource(0, vb, 0);
            device.Indices = ib;
            device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, vertices.Length, 0, indices.Length/3);
            
        }

        public void setVD()
        {
            device.VertexDeclaration = vd;
        }

        public override void Dispose()
        {
            if (vertices != null)
            {
                vertices = null;
            }
        }
    }
}
