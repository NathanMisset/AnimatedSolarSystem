#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace Opdracht6_Transformations
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class SimPhyGameWorld : Game
    {
        GraphicsDeviceManager graphDev;
        Color background = new Color(20, 0, 60);
        public static SimPhyGameWorld World;
        Vector3 cameraPosition = new Vector3(0, 30, 80);
        public Matrix View;
        public Matrix Projection;
        public static GraphicsDevice Graphics;

        List<Sphere> spheres;

        Sphere sun;

        public SimPhyGameWorld()
            : base()
        {
            Content.RootDirectory = "Content";

            World = this;
            graphDev = new GraphicsDeviceManager(this);
        }
        protected override void Initialize()
        {
            Graphics = GraphicsDevice;

            graphDev.PreferredBackBufferWidth = 1280;
            graphDev.PreferredBackBufferHeight = 800;
            graphDev.IsFullScreen = false;
            graphDev.ApplyChanges();

            SetupCamera(true);

            Window.Title = "HvA - Simulation & Physics - Opdracht 5 - Transformations - press <> to rotate camera";

            spheres = new List<Sphere>();

            // Step 1: Study the way the Sphere class is used in Initialize()
            // Step 2: Scale the sun uniformly (= the same factor in x, y and z directions) by a factor 2
            spheres.Add(sun = new Sphere(Matrix.Identity, Color.Yellow, 30));
            // Step 3: Create an earth Sphere, with radius, distance and color as given in the assignment

            // Step 4: Create 4 other planets: mars, jupiter, saturnus, uranus (radius, distance and color as given)
            // Step 5: Randomize the orbital rotation (in the Y plane) relative to the sun for each planet
            
            // Step 7: Create the moon (radius, distance and color as given)            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();

            IsMouseVisible = true;
        }

        private void SetupCamera(bool initialize = false)
        {
            View = Matrix.CreateLookAt(cameraPosition, new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            if(initialize) Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, SimPhyGameWorld.World.GraphicsDevice.Viewport.AspectRatio, 1.0f, 300.0f);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(background);

            foreach (Sphere sphere in spheres)
            {
                sphere.Draw();
            }

            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                // Step 10: Make the camera position rotate around the origin depending on gameTime.ElapsedGameTime.TotalSeconds

                SetupCamera();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                // Step 10: Make the camera position rotate around the origin depending on gameTime.ElapsedGameTime.TotalSeconds

                SetupCamera();
            }
            
            // Step 6: Make the planets rotate, all with different speeds between 0.15 and 0.5 (radians) per second

            // Step 7: Make the moon rotate around the earth, speed 1.5
            // Step 8: Change the orbit of the moon such that it is rotated 45 degrees toward the sun/origin(see example!)

            base.Update(gameTime);
        }
    }
}
