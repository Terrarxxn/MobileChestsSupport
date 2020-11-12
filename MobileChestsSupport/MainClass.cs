using System;
using System.Collections.Generic;
using System.Reflection;
using InfiniteChestsV3;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;
using System.Timers;

namespace MainClasses
{
	[ApiVersion(2, 1)]
	public class MainClass : TerrariaPlugin
	{

		public override string Author
		{
			get
			{
				return "Terrarian & AgaSpace";
			}
		}

		public override string Description
		{
			get
			{
				return "Adds mobile chests functions. For InfChestsV3";
			}
		}

		public override string Name
		{
			get
			{
				return "MobileChestsSupport";
			}
		}

		public override Version Version
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version;
			}
		}

		public MainClass(Main game) : base(game)
		{
			base.Order = 32767;
		}

		public override void Initialize()
		{
			ServerApi.Hooks.GamePostInitialize.Register(this, (x) => InitializeTimer());
		}

		private static void InitializeTimer()
		{
			new Timer(15000) // Таймер на каждые 15 секунд, проверяет на наличие сундуков, если нет - фиксит это
			{
				AutoReset = true,
				Enabled = true
			}.Elapsed += (x, y) => { if(Main.chest == null) { Fix(); } };
		}
		
		private static void Fix() // тихо спиздел и ушел называца нашол..
		{
			List<Chest> c = DB.GetAllChests();
			for (int i = 0; i < Main.chest.Length; i++)
			{
				Main.chest[i] = null;
			}
			for (int j = 0; j <= c.Count - 1; j++)
			{
				Main.chest[j] = c[j];
			}
		}
	}
}
