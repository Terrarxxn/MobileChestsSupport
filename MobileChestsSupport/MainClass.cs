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
				return "Terrarian (compiler) & AgaSpace (code)";
			}
		}

		public override string Description
		{
			get
			{
				return "Defender";
			}
		}

		public override string Name
		{
			get
			{
				return "TADefender";
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
			base.Order = 0;
		}

		public override void Initialize()
		{
			Commands.ChatCommands.Add(new Command("superadmin", new CommandDelegate(MainClass.AddAllChest), new string[]
			{
				"mcs"
			}));
		}

		public static void AddAllChest(CommandArgs args)
		{
			List<Chest> allChests = DB.GetAllChests();
			for (int i = 0; i < Main.chest.Length; i++)
			{
				Main.chest[i] = null;
			}
			for (int j = 0; j <= allChests.Count - 1; j++)
			{
				Main.chest[j] = allChests[j];
			}
			args.Player.SendSuccessMessage("Added all chests!");
		}
	}
}
