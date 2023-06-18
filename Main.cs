using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using GameFrst.Animation;
using GameFrst.Sprite;
using GameFrst.FloorElement;
using GameFrst.FloorNames;
using GameFrst.AreaClass;
using GameFrst.Button;
using GameFrst.AntogonistScreamer;
using GameFrst.CameraClass;
using GameFrst.Door;
using GameFrst.Anotogonist;
using GameFrst.FlashLight;
using GameFrst.Emeralds;
using GameFrst.GarageFinal;
using GameFrst.Icons;
using GameFrst.MobSpawn;
using GameFrst.NPCClass;
using GameFrst.PlatformClass;
using GameFrst.SensorClass;
using GameFrst.Shoker;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using GameFrst.LastDoorClass;
using GameFrst.HelpersClass;
using Lab_n._12.CheatsClass;

namespace GameFrst
{
    public class Main : Game
    {
        #region Объявление объектов игры

        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        private StartMenu menu;

        private Camera _camera;

        private FlashLightModel _flashLight;

        public List<FloorElementModel> _floorList;

        private ShokerModel _shokerModel;

        private SpriteModel _player;

        private EmeraldsModel _emeralds;

        private List<Sensor> _sensorList;

        private PlatformFinal _platformFinal;

        private GarageFinalModel _garageFinal;

        private List<ButtonModel> _buttonList;

        private IconsModel _icons;

        private List<NPC> _NPCList;

        private AntogonistScreamerModel _anotogonistScreamer;

        private List<MobSpawnModel> _mobSpawnList;

        private DoorModel _door;

        private List<Area> _areaList;

        private Texture2D _world;

        private Texture2D _winPlace;

        private AntogonistModel antogonist;

        public static int ScreenHeight;

        public static int ScreenWidth;

        public static bool exit;

        private bool IsPlaying;

        private Song mainTheme;

        private LastDoor lastDoor;

        private Helpers helpers;

        private Song victory;

        private bool isVictory;

        private Cheats cheats;

        #endregion

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1024; // Ширина окна
            graphics.PreferredBackBufferHeight = 768; // Длина окна
            graphics.ApplyChanges();

            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;

            base.Initialize();

        }

        protected override void LoadContent()
        {
            #region Загрузка контента в объекты
            spriteBatch = new SpriteBatch(GraphicsDevice);

            menu = new StartMenu(Content.Load<Texture2D>("menuNew1"), Content.Load<Song>("Sound/mainMenu"));

            antogonist = new AntogonistModel(Content.Load<Texture2D>("antogonist"), new Vector2(962, 4072), Content.Load<SoundEffect>("Sound/antogonistSound1"));

            _areaList = new List<Area>()
            {
                new Area() { rect = new Rectangle(1344, 7488, 3071, 2112), start = 0, end = 10 },
                new Area() { rect = new Rectangle(960, 5952, 3071, 1536), start = 11, end = 21 },
                new Area() { rect = new Rectangle(4415, 5952, 3842, 2688), start = 22, end = 34 },
                new Area() { rect = new Rectangle(4031, 4032, 385, 3456), start = 35, end = 37 },
                new Area() { rect = new Rectangle(576, 2880, 3456, 2304), start = 38, end = 46 },
                new Area() { rect = new Rectangle(2880, 576, 2304, 2304), start = 47, end = 70 },
                new Area() { rect = new Rectangle(5184, 2496, 3264, 1920), start = 71, end = 80 }
            };

            _sensorList = new List<Sensor>()
            {
                new Sensor(Content.Load<Texture2D>("Sensors/blueDatchik"), new Vector2(3329, 3880),Content.Load<SoundEffect>("Sound/buttonSound")),
                new Sensor(Content.Load<Texture2D>("Sensors/GreenDatchik"), new Vector2(641, 3872), Content.Load < SoundEffect >("Sound/buttonSound")),
                new Sensor(Content.Load<Texture2D>("Sensors/PinkDatchik"), new Vector2(3713, 429),Content.Load<SoundEffect>("Sound/buttonSound")),
                new Sensor(Content.Load<Texture2D>("Sensors/RedDatchik"), new Vector2(5633, 2354), Content.Load < SoundEffect >("Sound/buttonSound"))
            };

            _buttonList = new List<ButtonModel>()
            {
                new ButtonModel(Content.Load<Texture2D>("Instruments/button"),new Vector2(1035,5835),Content.Load<SoundEffect>("Sound/buttonSound")),
                new ButtonModel(Content.Load<Texture2D>("Instruments/button"),new Vector2(4491,6603),Content.Load<SoundEffect>("Sound/buttonSound")),
                new ButtonModel(Content.Load<Texture2D>("Instruments/button"),new Vector2(7564,7749),Content.Load<SoundEffect>("Sound/buttonSound"))
            };

            _NPCList = new List<NPC>()
            {
                new NPC(Content.Load<Texture2D>("npc"),new Vector2(3272,7900)),
                new NPC(Content.Load<Texture2D>("npc"),new Vector2(3660,7900)),
                new NPC(Content.Load<Texture2D>("npc"),new Vector2(3650,6516)),
                new NPC(Content.Load<Texture2D>("npc"),new Vector2(2312,5979)),
                new NPC(Content.Load<Texture2D>("npc"),new Vector2(1540,5979)),
                new NPC(Content.Load<Texture2D>("npc"),new Vector2(1156,5787)),
                new NPC(Content.Load<Texture2D>("npc"),new Vector2(7876,7709)),
                new NPC(Content.Load<Texture2D>("npc"),new Vector2(4226,3867)),
                new NPC(Content.Load<Texture2D>("npc"),new Vector2(4036,3867))
            };

            _shokerModel = new ShokerModel(new Dictionary<string, Texture2D>
            {
                {"shokerL", Content.Load<Texture2D>("shoker/shokerL") },
                {"shokerR", Content.Load<Texture2D>("shoker/shokerR") },
                {"shokerUD", Content.Load<Texture2D>("shoker/shokerUD") },
            });

            _mobSpawnList = new List<MobSpawnModel>()
            {
                new MobSpawnModel(Content.Load<Texture2D>("Instruments/spawn"), new Vector2(3264,8064)),
                new MobSpawnModel(Content.Load<Texture2D>("Instruments/spawn"), new Vector2(3648,8064)),
                new MobSpawnModel(Content.Load<Texture2D>("Instruments/spawn"), new Vector2(3839,6720)),
                new MobSpawnModel(Content.Load<Texture2D>("Instruments/spawn"), new Vector2(3264,6336)),
                new MobSpawnModel(Content.Load<Texture2D>("Instruments/spawn"), new Vector2(1344,6528)),
                new MobSpawnModel(Content.Load<Texture2D>("Instruments/spawn"), new Vector2(1152,5952)),
                new MobSpawnModel(Content.Load<Texture2D>("Instruments/spawn"), new Vector2(8065,7872)),
                new MobSpawnModel(Content.Load<Texture2D>("Instruments/spawn"), new Vector2(4224,4032)),
                new MobSpawnModel(Content.Load<Texture2D>("Instruments/spawn"), new Vector2(4032,4032))
            };

            _player = new SpriteModel(new Dictionary<string, AnimationModel>()
            {
                { "MoveUp", new AnimationModel(Content.Load<Texture2D>("Movemenet/MoveUp1"), 9) },
                { "MoveDown", new AnimationModel(Content.Load<Texture2D>("Movemenet/MoveDown1"), 9) },
                { "MoveLeft", new AnimationModel(Content.Load<Texture2D>("Movemenet/MoveLeft1"), 9) },
                { "MoveRight", new AnimationModel(Content.Load<Texture2D>("Movemenet/MoveRight1"), 9) },
            })
            {
                Position = new Vector2(1536, 8256)
            };

            _icons = new IconsModel(Content.Load<Texture2D>("Icons/shoker"), 
                               Content.Load<Texture2D>("Icons/light"));
            _camera = new Camera();

            _emeralds = new EmeraldsModel(Content.Load<Texture2D>("emerlands"), new Vector2(4555, 2370));

            _platformFinal = new PlatformFinal(Content.Load<Texture2D>("antogonistPlatform"), new Vector2(4800, 2176));

            _garageFinal = new GarageFinalModel(Content.Load<Texture2D>("antogonistfinal 1"), new Vector2(4416, 1920));

            _world = Content.Load<Texture2D>("gamePlace");

            _winPlace = Content.Load<Texture2D>("winPlace");

            _anotogonistScreamer = new AntogonistScreamerModel(Content.Load<Texture2D>("sreamer"), new Vector2(3648, 3867), Content.Load<SoundEffect>("Sound/screamer"));

            _door = new DoorModel(Content.Load<Texture2D>("DoorSprite"), new Vector2(4032, 6478));

            _flashLight = new FlashLightModel(Content.Load<Texture2D>("flashLight"));

            _floorList = new List<FloorElementModel>();

            foreach(var floorName in new AllFloorNames().AllFloorListNames)
                _floorList.Add(new FloorElementModel(Content.Load<Texture2D>("Floor/" + floorName)));

            mainTheme = Content.Load<Song>("Sound/mainTheme");

            lastDoor = new LastDoor(Content.Load<Texture2D>("fnlDoorClose"), Content.Load<Texture2D>("fnlDoorOpen"), Content.Load<SoundEffect>("Sound/buttonSound"));

            helpers = new Helpers(Content.Load<Texture2D>("helpersNew1"));

            victory = Content.Load<Song>("Sound/pobedaa");

            cheats = new Cheats(Content.Load<Texture2D>("cheats"));

            #endregion
        }

        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            // Выход из игры
            if (exit || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Обновление либо меню либо основной игры
            if (menu.isStart)
                MainGameUpdate(gameTime);
            else
                menu.Update(gameTime);

            base.Update(gameTime);
        }
        

        protected override void Draw(GameTime gameTime)
        {

            // Отрисовка либо меню либо основной  игры
            if (menu.isStart)
                MainGameDraw(gameTime);
            else
                menu.Draw(gameTime, spriteBatch);

            base.Draw(gameTime);
        }

        private void MainGameUpdate(GameTime gameTime)
        {
            if (!IsPlaying)
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(mainTheme);
                IsPlaying = true;
            }

            foreach (var area in _areaList)
            {
                area.Collide(_floorList, _player.controller);
                area.Collide(_floorList, antogonist.controller);
            }

            antogonist.controller.Update(gameTime, _player.Position, _player.Rectangle);

            _player.controller.Update(gameTime, _door);

            cheats.Update(_player);

            antogonist.controller.UpdateFlagDoor(_door.CanGoUp, _door.CanGoDown);

            foreach (var button in _buttonList)
                button.controller.Update(_door, _player.Rectangle);

            foreach (var sensor in _sensorList)
                sensor.Update(gameTime, _player.Rectangle, _emeralds);

            for (var i = 0; i < _NPCList.Count; i++)
            {
                _mobSpawnList[i].controller.Update(gameTime, _NPCList[i].rectangle);
                _NPCList[i].Update(gameTime, _player.Rectangle, _mobSpawnList[i].IsMobAtHome);
            }

            _shokerModel.controller.Update(gameTime, _player.Position);

            _emeralds.controller.Update(gameTime, _player.Rectangle);

            _door.controller.Update(_door, _player.Rectangle);

            _platformFinal.Update(antogonist);

            _player.controller.UpdateFlagDoor(_door.CanGoUp, _door.CanGoDown);

            _flashLight.controller.Update(gameTime, _player.Position);

            _anotogonistScreamer.controller.Update(gameTime, _player.Rectangle);

            _garageFinal.controller.Update(gameTime, antogonist);

            _icons.controller.Update(gameTime, _player.Position);

            lastDoor.Update(gameTime, antogonist, _player);

            _camera.Follow(_player);

            if (_player.Rectangle.Intersects(new Rectangle(8448, 2021, 3899, 4023)))
            {
                if (!isVictory)
                {
                    MediaPlayer.Play(victory);
                    isVictory = true;
                }
            }
            else if (isVictory)
            {
                isVictory = IsPlaying = false;
            }

            if (Cheats.wantOpenFrstDoor)
                _door.doorCondition = 3;

            if (Cheats.wantOpenScndDoor)
                lastDoor.isOpen = true;

        }

        private void MainGameDraw(GameTime gameTime)
        {
            spriteBatch.Begin(transformMatrix: _camera.Transform);

            spriteBatch.Draw(_world, Vector2.Zero, Color.White);

            spriteBatch.Draw(_winPlace, new Vector2(8448,2021), Color.White);

            foreach (var floor in _floorList)
                floor.view.Draw(gameTime, spriteBatch);

            foreach (var button in _buttonList)
                button.view.Draw(gameTime, spriteBatch);

            foreach (var sensor in _sensorList)
                sensor.Draw(gameTime, spriteBatch,helpers,_player);

            foreach (var spawn in _mobSpawnList)
                spawn.view.Draw(gameTime, spriteBatch);

            _door.view.Draw(spriteBatch,_player,helpers);

            _emeralds.view.Draw(gameTime, spriteBatch);

            _shokerModel.view.Draw(gameTime, spriteBatch);

            _anotogonistScreamer.view.Draw(gameTime, spriteBatch);

            _platformFinal.Draw(gameTime, spriteBatch);

            _garageFinal.view.Draw(spriteBatch,_player,helpers);

            lastDoor.Draw(gameTime, spriteBatch,_player,helpers);

            _player.view.Draw(gameTime, spriteBatch);

            foreach (var npc in _NPCList)
                npc.Draw(gameTime, spriteBatch);

            antogonist.view.Draw(gameTime, spriteBatch);

            _garageFinal.view.DrawVictory(spriteBatch, antogonist);

            _flashLight.view.Draw(_player.Rectangle, spriteBatch);

            cheats.Draw(spriteBatch);

            _icons.view.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

    }
}