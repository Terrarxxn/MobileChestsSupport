using System;
using System.Collections.Generic;
using System.Reflection;
using InfiniteChestsV3;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace MainClasses
{
	[ApiVersion(2, 1)]
	public class MainClass : TerrariaPlugin
	{

		public override string Author
		{
			get
			{
				return "Terrarian";
			}
		}

		public override string Description
		{
			get
			{
				return ":P";
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
			ServerApi.Hooks.GamePostInitialize.Register(this, (x) => MCS());
		}

		public static void MCS()
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
