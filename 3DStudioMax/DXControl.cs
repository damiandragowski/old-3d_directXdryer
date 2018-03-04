using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using _DStudioMax._3DLib;

namespace _DStudioMax
{
    public partial class DXControl : UserControl
    {
        public Microsoft.DirectX.Direct3D.Device device = null; // Our rendering device
        private PresentParameters presentParams = new PresentParameters();
        private bool pause = false;
        private CDXVertexBuffer objectsToDraw = null;
        private Camera camera = new Camera(0,0,10);

        private Matrix WorldTransform = Matrix.Identity;
        private Matrix matproj = Matrix.Identity;
        private Matrix matview = Matrix.Identity;

        private bool mousing = false;
        private bool mousing2 = false;
        private Point ptLastMousePosit;
        private Point ptCurrentMousePosit;

        private Mesh skyboxmesh;
        private Material[] skyboxmaterials;
        private Texture[] skyboxtextures;
        private Vector3 spacemeshangles = new Vector3(0, (float)(Math.PI/-2), 0);
        public bool alpha = false;
        private Effect effect;
        public bool vertexpixelshader=false;

        public DXControl()
        {
            InitializeComponent();
            InitializeGraphics();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
        }

        public bool InitializeGraphics()
        {
            try
            {
                // Now let's setup our D3D stuff
                Caps DevCaps = Microsoft.DirectX.Direct3D.Manager.GetDeviceCaps(0, Microsoft.DirectX.Direct3D.DeviceType.Hardware);
                Microsoft.DirectX.Direct3D.DeviceType DevType = Microsoft.DirectX.Direct3D.DeviceType.Reference;
                CreateFlags DevFlags = CreateFlags.SoftwareVertexProcessing;
                if ((DevCaps.VertexShaderVersion >= new Version(2, 0)) && (DevCaps.PixelShaderVersion >= new Version(2, 0)))
                {
                    DevType = Microsoft.DirectX.Direct3D.DeviceType.Hardware;
                    if (DevCaps.DeviceCaps.SupportsHardwareTransformAndLight)
                    {
                        DevFlags = CreateFlags.HardwareVertexProcessing;
                        if (DevCaps.DeviceCaps.SupportsPureDevice)
                        {
                            DevFlags |= CreateFlags.PureDevice;
                        }
                    }
                }

                presentParams.BackBufferFormat = Format.Unknown;
                presentParams.SwapEffect = SwapEffect.Discard;
                presentParams.Windowed = true;
                presentParams.EnableAutoDepthStencil = true;
                presentParams.AutoDepthStencilFormat = DepthFormat.D16;
                presentParams.PresentationInterval = PresentInterval.Immediate;

                device = new Device(0, DevType, this, DevFlags, presentParams);
                device.DeviceReset += new System.EventHandler(this.OnResetDevice);
                this.OnCreateDevice(device, null);
                this.OnResetDevice(device, null);
                pause = false;
                return true;
            }
            catch (DirectXException)
            {
                return false;
            }
        }

        public void LoadTexture(string fileName)
        {
            objectsToDraw.LoadTexture(fileName);
        }

        public void LoadSusz(string fileName)
        {
            objectsToDraw.LoadFromFile(fileName);
        }

        public void OnCreateDevice(object sender, EventArgs e)
        {
            Microsoft.DirectX.Direct3D.Device dev = (Device)sender;

            objectsToDraw = new CDXVertexBuffer(dev);
            objectsToDraw.LoadFromFile("../../susz.txt");
            objectsToDraw.LoadTexture("../../Texture1.bmp");
            LoadMeshes();
            LoadEfect();

            // Now Create the VB
            //vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), 3, dev, 0, CustomVertex.PositionColored.Format, Pool.Default);
            //vertexBuffer.Created += new System.EventHandler(this.OnCreateVertexBuffer);
            //this.OnCreateVertexBuffer(vertexBuffer, null);
        }

        private void LoadEfect()
        {
            try
            {
                effect = Effect.FromFile(device, @"../../efect.fx", null, null, ShaderFlags.None, null);
            }
            catch(Microsoft.DirectX.DirectXException e )
            {
                MessageBox.Show(e.Message);
            }
        }

        public void OnResetDevice(object sender, EventArgs e)
        {
            Microsoft.DirectX.Direct3D.Device dev = (Device)sender;
            // Turn off culling, so we see the front and back of the triangle
            dev.RenderState.CullMode = Cull.None;
            // Turn off D3D lighting, since we are providing our own vertex colors
            dev.RenderState.Lighting = true;

            dev.Lights[0].Type = LightType.Directional;
            dev.Lights[0].Diffuse = Color.Silver;
            dev.Lights[0].Direction = new Vector3(0, 0, 10);
            dev.Lights[0].Update();
            dev.Lights[0].Enabled = true;

            
            dev.Lights[1].Type = LightType.Spot;
            dev.Lights[1].Diffuse = System.Drawing.Color.White;
            dev.Lights[1].Ambient = System.Drawing.Color.White;
            dev.Lights[1].Specular = System.Drawing.Color.White;
            dev.Lights[1].Direction = new Vector3(0f, 0f, 0f);
            dev.Lights[1].Position = new Vector3(10f, 0f, 0f);
            dev.Lights[1].Range = 1000;

            dev.Lights[1].Attenuation0 = 0.1f;
            dev.Lights[1].Attenuation1 = 0.1f;

            dev.Lights[1].InnerConeAngle = 0.1f;

            dev.Lights[1].OuterConeAngle = 0.5f;


            dev.Lights[1].Enabled = true;


            dev.RenderState.SourceBlend = Blend.One;
            dev.RenderState.DestinationBlend = Blend.One;
            
            dev.RenderState.AlphaSourceBlend = Blend.SourceAlpha;
            dev.RenderState.AlphaDestinationBlend = Blend.InvSourceAlpha;
            dev.RenderState.AlphaTestEnable = true;
            dev.RenderState.AlphaFunction = Compare.NotEqual;
            //dev.RenderState.BlendFactor = Color.Black;


            dev.RenderState.Ambient = Color.FromArgb(120, 120, 120);
            dev.RenderState.ShadeMode = ShadeMode.Flat;


            dev.RenderState.ZBufferEnable = true;

            dev.Transform.Projection = matproj =
                Matrix.PerspectiveFovLH(Geometry.DegreeToRadian(45.0f),
                (float)this.ClientSize.Width / this.ClientSize.Height,
                0.1f, 100.0f);


            objectsToDraw.OnResetDevice(sender, e);
        }

        Clock clock = new Clock();
        float time = 0;


        private void Render()
        {
            if (device == null)
                return;

            if (pause)
                return;
            time += clock.GetTime();
            //Clear the backbuffer to a blue color 
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, System.Drawing.Color.Black, 1.0f, 0);
            //Begin the scene
            device.BeginScene();
            // Setup the world, view, and projection matrices
            SetupMatrices();

            device.RenderState.Ambient = Color.White;
            device.Transform.World = Matrix.RotationX((float)Math.PI / 2) * Matrix.RotationYawPitchRoll((float)spacemeshangles.X, (float)spacemeshangles.Y, (float)spacemeshangles.Z);
            //DrawMesh(skyboxmesh, skyboxmaterials, skyboxtextures);


            if (alpha)
            {
                device.RenderState.AlphaBlendEnable = true;
                //device.RenderState.CullMode = (cullMode == Cull.CounterClockwise ? Cull.Clockwise : Cull.CounterClockwise);
                device.RenderState.ZBufferWriteEnable = false;
                device.RenderState.CullMode = Cull.None;
            }

            if (vertexpixelshader)
            {
                objectsToDraw.setVD();
                effect.Technique = "Simplest";
                effect.SetValue("xWorldViewProjection", objectsToDraw.Transform * WorldTransform * matview * matproj);
                effect.SetValue("xStreetTexture", objectsToDraw.texture);
                effect.SetValue("time", time);
                int numpasses = effect.Begin(0);
                for (int i = 0; i < numpasses; i++)
                {
                    effect.BeginPass(i);
                    objectsToDraw.Draw(WorldTransform);
                    effect.EndPass();
                }
                effect.End();
            } else
                objectsToDraw.Draw(WorldTransform);

            if (alpha)
            {
                device.RenderState.AlphaBlendEnable = false;
                device.RenderState.CullMode = Cull.None;
                device.RenderState.ZBufferWriteEnable = true;
            }



           // device.SetStreamSource(0, vertexBuffer, 0);
            //device.VertexFormat = CustomVertex.PositionColored.Format;
            //device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
            //End the scene
            device.EndScene();
            device.Present();
        }
        private float scaling = 0.0005f;

        private void LoadMesh(string filename, ref Mesh mesh, ref Material[] meshmaterials, ref Texture[] meshtextures, ref float meshradius)
        {
            ExtendedMaterial[] materialarray;
            mesh = Mesh.FromFile(filename, MeshFlags.Managed, device, out materialarray);

            if ((materialarray != null) && (materialarray.Length > 0))
            {
                meshmaterials = new Material[materialarray.Length];
                meshtextures = new Texture[materialarray.Length];

                for (int i = 0; i < materialarray.Length; i++)
                {
                    meshmaterials[i] = materialarray[i].Material3D;
                    meshmaterials[i].Ambient = meshmaterials[i].Diffuse;

                    if ((materialarray[i].TextureFilename != null) && (materialarray[i].TextureFilename != string.Empty))
                    {
                        meshtextures[i] = TextureLoader.FromFile(device, materialarray[i].TextureFilename);
                    }
                }
            }

            mesh = mesh.Clone(mesh.Options.Value, CustomVertex.PositionNormalTextured.Format, device);
            mesh.ComputeNormals();

            VertexBuffer vertices = mesh.VertexBuffer;
            GraphicsStream stream = vertices.Lock(0, 0, LockFlags.None);
            Vector3 meshcenter;
            meshradius = Geometry.ComputeBoundingSphere(stream, mesh.NumberVertices, mesh.VertexFormat, out meshcenter) * scaling;
        }

        private void SetupMatrices()
        {

            // Set up our view matrix. A view matrix can be defined given an eye point,
            // a point to lookat, and a direction for which way is up. Here, we set the
            // eye five units back along the z-axis and up three units, look at the
            // origin, and define "up" to be in the y-direction.

            camera.SetView(device,ref matview);
        }

        private void LoadMeshes()
        {
            float dummy = 0;
            LoadMesh("skybox2.x", ref skyboxmesh, ref skyboxmaterials, ref skyboxtextures, ref dummy);
        }
        private void DrawMesh(Mesh mesh, Material[] meshmaterials, Texture[] meshtextures)
        {
            for (int i = 0; i < meshmaterials.Length; i++)
            {
                device.Material = meshmaterials[i];
                device.SetTexture(0, meshtextures[i]);
                mesh.DrawSubset(i);
            }
        }

        private void DXControl_Paint(object sender, PaintEventArgs e)
        {
            this.Render();
        }

        private void DXControl_Resize(object sender, EventArgs e)
        {
            pause = !this.Visible;
        }

        private void DXControl_MouseDown(object sender, MouseEventArgs e)
        {
            ptLastMousePosit = ptCurrentMousePosit = PointToScreen(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Right)
                mousing2 = true;
            else if (e.Button == MouseButtons.Left)
                mousing = true;
        }

        private void DXControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mousing2 = false;
            else if  ( e.Button == MouseButtons.Left )
                mousing = false;
        }

        private void DXControl_MouseMove(object sender, MouseEventArgs e)
        {
            ptCurrentMousePosit = PointToScreen(new Point(e.X, e.Y));

            if (mousing)
            {
                int spinX;
                int spinY;
                spinX = (ptCurrentMousePosit.X - ptLastMousePosit.X);
                spinY = (ptCurrentMousePosit.Y - ptLastMousePosit.Y);
                objectsToDraw.Transform = objectsToDraw.Transform * Matrix.RotationYawPitchRoll(Geometry.DegreeToRadian(-spinX) * 0.5f,
                    Geometry.DegreeToRadian(spinY) * 0.5f, 0.0f);
            }
            else if ( mousing2 )
            {
                int spinX;
                int spinY;
                spinX = (ptCurrentMousePosit.X - ptLastMousePosit.X);
                spinY = (ptCurrentMousePosit.Y - ptLastMousePosit.Y);
                camera.Turn(Geometry.DegreeToRadian(spinX)*0.1f);
                camera.AdjustPitch(Geometry.DegreeToRadian(spinY) * 0.1f);
            }

            ptLastMousePosit = ptCurrentMousePosit;
        }

        private void DXControl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.W:
                    camera.Move(0.1f, 0, 0);
                    break;
                case System.Windows.Forms.Keys.S:
                    camera.Move(-0.1f, 0, 0);
                    break;
                case System.Windows.Forms.Keys.A:
                    camera.Move(0, 0,-0.1f);
                    break;
                case System.Windows.Forms.Keys.D:
                    camera.Move(0, 0,0.1f);
                    break;

            }
        }
    }
}
