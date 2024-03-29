using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class SlayerGroup
	{
		private static SlayerEntry[] m_TotalEntries;
		private static SlayerGroup[] m_Groups;

		public static SlayerEntry[] TotalEntries
		{
			get{ return m_TotalEntries; }
		}

		public static SlayerGroup[] Groups
		{
			get{ return m_Groups; }
		}

		public static SlayerEntry GetEntryByName( SlayerName name )
		{
			int v = (int)name;

			if ( v >= 0 && v < m_TotalEntries.Length )
				return m_TotalEntries[v];

			return null;
		}

		public static SlayerName GetLootSlayerType( Type type )
		{
			for ( int i = 0; i < m_Groups.Length; ++i )
			{
				SlayerGroup group = m_Groups[i];
				Type[] foundOn = group.FoundOn;

				bool inGroup = false;

				for ( int j = 0; foundOn != null && !inGroup && j < foundOn.Length; ++j )
					inGroup = ( foundOn[j] == type );

				if ( inGroup )
				{
					int index = Utility.Random( 1 + group.Entries.Length );

					if ( index == 0 )
						return group.m_Super.Name;

					return group.Entries[index - 1].Name;
				}
			}

			return SlayerName.Silver;
		}

		static SlayerGroup()
		{
			SlayerGroup humanoid = new SlayerGroup();
			SlayerGroup undead = new SlayerGroup();
                        SlayerGroup fey = new SlayerGroup();
        		SlayerGroup elemental = new SlayerGroup();
			SlayerGroup abyss = new SlayerGroup();
			SlayerGroup arachnid = new SlayerGroup();
			SlayerGroup reptilian = new SlayerGroup();
			SlayerGroup goblin = new SlayerGroup();

			humanoid.Opposition = new SlayerGroup[]{ undead };
			humanoid.FoundOn = new Type[]{ typeof( BoneKnight ), typeof( Lich ), typeof( LichLord ) };
			humanoid.Super = new SlayerEntry( SlayerName.Repond, typeof( RakktaviRenowned ), typeof( TikitaviRenowned ), typeof( VitaviRenowned ), typeof( ArcticOgreLord ), typeof( Cyclops ), typeof( Ettin ), typeof( EvilMage ), typeof( EvilMageLord ), typeof( FrostTroll ), typeof( MeerCaptain ), typeof( MeerEternal ), typeof( MeerMage ), typeof( MeerWarrior ), typeof( Ogre ), typeof( OgreLord ), typeof( Orc ), typeof( OrcBomber ), typeof( OrcBrute ), typeof( OrcCaptain ), typeof( OrcChopper ), typeof( OrcScout ), typeof( OrcishLord ), typeof( OrcishMage ), typeof( Ratman ), typeof( RatmanArcher ), typeof( RatmanMage ), typeof( SavageRider ), typeof( SavageShaman ), typeof( Savage ), typeof( Titan ), typeof( Troll ), /* Mondain's Legacy */ typeof( Troglodyte ), typeof( MougGuur ), typeof( Chiikkaha ), typeof( Minotaur ) /* ML End, SA begins */, typeof( Medusa ) );
			humanoid.Entries = new SlayerEntry[]
				{
					new SlayerEntry( SlayerName.OgreTrashing, typeof( Ogre ), typeof( OgreLord ), typeof( ArcticOgreLord ) ),
					new SlayerEntry( SlayerName.OrcSlaying, typeof( Orc ), typeof( OrcBomber ), typeof( OrcBrute ), typeof( OrcCaptain ), typeof( OrcChopper ), typeof( OrcScout ), typeof( OrcishLord ), typeof( OrcishMage ) ),
					new SlayerEntry( SlayerName.TrollSlaughter, typeof( Troll ), typeof( FrostTroll ) ),
                                        new SlayerEntry( SlayerName.Repond, typeof( RakktaviRenowned ), typeof( TikitaviRenowned ), typeof( VitaviRenowned ), typeof( ArcticOgreLord ), typeof( Cyclops ), typeof( Ettin ), typeof( EvilMage ), typeof( EvilMageLord ), typeof( FrostTroll ), typeof( MeerCaptain ), typeof( MeerEternal ), typeof( MeerMage ), typeof( MeerWarrior ), typeof( Ogre ), typeof( OgreLord ), typeof( Orc ), typeof( OrcBomber ), typeof( OrcBrute ), typeof( OrcCaptain ), typeof( OrcChopper ), typeof( OrcScout ), typeof( OrcishLord ), typeof( OrcishMage ), typeof( Ratman ), typeof( RatmanArcher ), typeof( RatmanMage ), typeof( SavageRider ), typeof( SavageShaman ), typeof( Savage ), typeof( Titan ), typeof( Troll ), /* Mondain's Legacy */ typeof( Troglodyte ), typeof( MougGuur ), typeof( Chiikkaha ), typeof( Minotaur ) /* ML End, SA begins */, typeof( Medusa ) )
				};

			undead.Opposition = new SlayerGroup[]{ humanoid };
			undead.Super = new SlayerEntry( SlayerName.Silver, typeof( AncientLich ), typeof( AncientLichRenowned ), typeof( Bogle ), typeof( BoneKnight ), typeof( BoneMagi ),/* typeof( DarkGuardian ), */typeof( DarknightCreeper ), typeof( FleshGolem ), typeof( Ghoul ), typeof( GoreFiend ), typeof( HellSteed ), typeof( LadyOfTheSnow ), typeof( Lich ), typeof( LichLord ), typeof( Mummy ), typeof( Revenant ), typeof( RevenantLion ), typeof( RottingCorpse ), typeof( Shade ), typeof( ShadowKnight ), typeof( SkeletalKnight ), typeof( SkeletalMage ), typeof( SkeletalMount ), typeof( Skeleton ), typeof( Spectre ), typeof( Wraith ), typeof( Zombie ), /* Mondain's Legacy */ typeof( UnfrozenMummy ), typeof( RedDeath ), typeof( SirPatrick ), typeof( LadyJennifyr ), typeof( MasterMikael ), typeof( MasterJonath ), typeof( LadyMarai ) /* ML End, SA Begins */, typeof (PestilentBandage), typeof (PrimevalLich), typeof (DreamWraith), typeof (UndeadGargoyle), typeof (UndeadGuardian), typeof (PutridUndeadGuardian) );
			undead.Entries = new SlayerEntry[]
                {
					new SlayerEntry( SlayerName.Silver, typeof( AncientLich ), typeof( AncientLichRenowned ), typeof( Bogle ), typeof( BoneKnight ), typeof( BoneMagi ),/* typeof( DarkGuardian ), */typeof( DarknightCreeper ), typeof( FleshGolem ), typeof( Ghoul ), typeof( GoreFiend ), typeof( HellSteed ), typeof( LadyOfTheSnow ), typeof( Lich ), typeof( LichLord ), typeof( Mummy ), typeof( Revenant ), typeof( RevenantLion ), typeof( RottingCorpse ), typeof( Shade ), typeof( ShadowKnight ), typeof( SkeletalKnight ), typeof( SkeletalMage ), typeof( SkeletalMount ), typeof( Skeleton ), typeof( Spectre ), typeof( Wraith ), typeof( Zombie ), /* Mondain's Legacy */ typeof( UnfrozenMummy ), typeof( RedDeath ), typeof( SirPatrick ), typeof( LadyJennifyr ), typeof( MasterMikael ), typeof( MasterJonath ), typeof( LadyMarai ) /* ML End, SA Begins */, typeof (PestilentBandage), typeof (PrimevalLich), typeof (DreamWraith), typeof (UndeadGargoyle), typeof (UndeadGuardian), typeof (PutridUndeadGuardian) )
				};

			fey.Opposition = new SlayerGroup[]{ abyss };
			fey.Super = new SlayerEntry( SlayerName.Fey, typeof( Centaur ), typeof( EtherealWarrior ), typeof( PixieRenowned ), typeof( Kirin ), typeof( LordOaks ), typeof( Pixie ), typeof( Silvani ), typeof( Treefellow ), typeof( Unicorn ), typeof( Wisp ), /* Mondain's Legacy */ typeof( CuSidhe ), typeof( MLDryad ), typeof( InsaneDryad ), typeof( Satyr ), typeof( CorporealBrume ), typeof( CrystalLatticeSeeker ), typeof( LadyMelisande ) /* End */, typeof ( FeralTreefellow ) );
			fey.Entries = new SlayerEntry[]
                                {
					new SlayerEntry( SlayerName.Fey, typeof( Centaur ), typeof( EtherealWarrior ), typeof( PixieRenowned ), typeof( Kirin ), typeof( LordOaks ), typeof( Pixie ), typeof( Silvani ), typeof( Treefellow ), typeof( Unicorn ), typeof( Wisp ), /* Mondain's Legacy */ typeof( CuSidhe ), typeof( MLDryad ), typeof( InsaneDryad ), typeof( Satyr ), typeof( CorporealBrume ), typeof( CrystalLatticeSeeker ), typeof( LadyMelisande ) /* End */, typeof ( FeralTreefellow ) )
				};
 
			elemental.Opposition = new SlayerGroup[]{ abyss };
			elemental.FoundOn = new Type[]{ typeof( Balron ), typeof( Daemon ) };
			elemental.Super = new SlayerEntry( SlayerName.ElementalBan, typeof( ToxicElemental ), typeof( AcidElementalRenowned ), typeof( FireElementalRenowned ), typeof( AgapiteElemental ), typeof( AirElemental ), typeof( SummonedAirElemental ), typeof( BloodElemental ), typeof( BronzeElemental ), typeof( CopperElemental ), typeof( CrystalElemental ), typeof( DullCopperElemental ), typeof( EarthElemental ), typeof( SummonedEarthElemental ), typeof( Efreet ), typeof( FireElemental ), typeof( SummonedFireElemental ), typeof( GoldenElemental ), typeof( IceElemental ), typeof( KazeKemono ), typeof( PoisonElemental ), typeof( RaiJu ), typeof( SandVortex ), typeof( ShadowIronElemental ), typeof( SnowElemental ), typeof( ValoriteElemental ), typeof( VeriteElemental ), typeof( WaterElemental ), typeof( SummonedWaterElemental ), typeof( Flurry ), typeof( Mistral ), typeof( Tempest ) );
			elemental.Entries = new SlayerEntry[]
				{
					new SlayerEntry( SlayerName.BloodDrinking, typeof( AcidElementalRenowned ), typeof( BloodElemental ) ),
					new SlayerEntry( SlayerName.EarthShatter, typeof( AgapiteElemental ), typeof( BronzeElemental ), typeof( CopperElemental ), typeof( DullCopperElemental ), typeof( EarthElemental ), typeof( SummonedEarthElemental ), typeof( GoldenElemental ), typeof( ShadowIronElemental ), typeof( ValoriteElemental ), typeof( VeriteElemental ) ),
					new SlayerEntry( SlayerName.ElementalHealth, typeof( AcidElementalRenowned ), typeof( FireElementalRenowned ), typeof( PoisonElemental ) ),
					new SlayerEntry( SlayerName.FlameDousing, typeof( FireElemental ), typeof( FireElementalRenowned ), typeof( SummonedFireElemental ) ),
					new SlayerEntry( SlayerName.SummerWind, typeof( SnowElemental ), typeof( IceElemental ) ),
					new SlayerEntry( SlayerName.Vacuum, typeof( AirElemental ), typeof( SummonedAirElemental ), typeof( Flurry ), typeof( Mistral ), typeof( Tempest ) ),
					new SlayerEntry( SlayerName.WaterDissipation, typeof( WaterElemental ), typeof( SummonedWaterElemental ) )
				};

			abyss.Opposition = new SlayerGroup[]{ elemental, fey };
			abyss.FoundOn = new Type[]{ typeof( BloodElemental ) };

			if( Core.AOS )
			{
				abyss.Super = new SlayerEntry( SlayerName.Exorcism, typeof( DevourerRenowned ), typeof( FireDaemonRenowned ), typeof( AbysmalHorror ), typeof( AbyssalInfernal ), typeof( ArcaneDaemon ), typeof( Balron ), typeof( BoneDemon ), typeof( ChaosDaemon ), typeof( Daemon ), typeof( SummonedDaemon ), typeof( DemonKnight ), typeof( Devourer ), typeof( EnslavedGargoyle ), typeof( FanDancer ), typeof( FireGargoyle ), typeof( Gargoyle ), typeof( GargoyleDestroyer ), typeof( GargoyleEnforcer ), typeof( Gibberling ), typeof( HordeMinion ), typeof( IceFiend ), typeof( Imp ), typeof( Impaler ), typeof( Moloch ), typeof( Oni ), typeof( Ravager ), typeof( Semidar ), typeof( StoneGargoyle ), typeof( Succubus ), typeof( TsukiWolf ), /* Mondain's Legacy */ typeof( Szavetra ), typeof( CrystalDaemon ) /* End */ );
	
				abyss.Entries = new SlayerEntry[]
					{
						// Daemon Dismissal & Balron Damnation have been removed and moved up to super slayer on OSI.
						new SlayerEntry( SlayerName.GargoylesFoe, typeof( EnslavedGargoyle ), typeof( FireGargoyle ), typeof( Gargoyle ), typeof( GargoyleDestroyer ), typeof( GargoyleEnforcer ), typeof( StoneGargoyle ) ),
					};
			}
			else
			{
				abyss.Super = new SlayerEntry( SlayerName.Exorcism, typeof( DevourerRenowned ), typeof( FireDaemonRenowned ), typeof( SlasherOfVeils ), typeof( AbyssalInfernal ), typeof( AbysmalHorror ), typeof( Balron ), typeof( BoneDemon ), typeof( ChaosDaemon ), typeof( Daemon ), typeof( SummonedDaemon ), typeof( DemonKnight ), typeof( Devourer ), typeof( Gargoyle ), typeof( FireGargoyle ), typeof( Gibberling ), typeof( HordeMinion ), typeof( IceFiend ), typeof( Imp ), typeof( Impaler ), typeof( Ravager ), typeof( StoneGargoyle ), typeof( ArcaneDaemon ), typeof( EnslavedGargoyle ), typeof( GargoyleDestroyer ), typeof( GargoyleEnforcer ), typeof( Moloch ), typeof( Vasanord ), typeof( Korpre ), typeof( PutridUndeadGuardian ), typeof( GargoyleShade ), typeof( Szavetra ), typeof( Putrefier ) );

				abyss.Entries = new SlayerEntry[]
					{
						new SlayerEntry( SlayerName.DaemonDismissal, typeof( AbysmalHorror ), typeof( AbyssalInfernal ), typeof( SlasherOfVeils ), typeof( Balron ), typeof( BoneDemon ), typeof( ChaosDaemon ), typeof( Daemon ), typeof( SummonedDaemon ), typeof( DemonKnight ), typeof( Devourer ), typeof( Gibberling ), typeof( HordeMinion ), typeof( IceFiend ), typeof( Imp ), typeof( Impaler ), typeof( Ravager ), typeof( ArcaneDaemon ), typeof( Moloch ) ),
						new SlayerEntry( SlayerName.GargoylesFoe, typeof( FireGargoyle ), typeof( Gargoyle ), typeof( StoneGargoyle ), typeof( EnslavedGargoyle ), typeof( GargoyleDestroyer ), typeof( GargoyleEnforcer ) ),
						new SlayerEntry( SlayerName.BalronDamnation, typeof( SlasherOfVeils ), typeof( Balron ) )
					};
			}

			arachnid.Opposition = new SlayerGroup[]{ reptilian };
			arachnid.FoundOn = new Type[]{ typeof( AncientWyrm ), typeof( GreaterDragon ), typeof( Dragon ), typeof( OphidianMatriarch ), typeof( ShadowWyrm ) };
			arachnid.Super = new SlayerEntry( SlayerName.ArachnidDoom, typeof( DreadSpider ), typeof( FrostSpider ), typeof( GiantBlackWidow ), typeof( GiantSpider ), typeof( Mephitis ), typeof( Scorpion ), typeof( TerathanAvenger ), typeof( TerathanDrone ), typeof( TerathanMatriarch ), typeof( TerathanWarrior ), /* Mondain's Legacy */ typeof( Miasma ), typeof( SpeckledScorpion ) /* End */, typeof( Navrey ), typeof( TrapdoorSpider )  );
			arachnid.Entries = new SlayerEntry[]
				{
					new SlayerEntry( SlayerName.ScorpionsBane, typeof( Scorpion ), /* Mondain's Legacy */ typeof( Miasma ), typeof( SpeckledScorpion ) /* End */ ),
					new SlayerEntry( SlayerName.SpidersDeath, typeof( DreadSpider ), typeof( FrostSpider ), typeof( GiantBlackWidow ), typeof( GiantSpider ), typeof( Mephitis ), /* Mondain's Legacy */ typeof( LadyLissith ), typeof( LadySabrix ), typeof( Virulent ), typeof( Silk ), typeof( Malefic ) /* End */, typeof( Navrey ), typeof( TrapdoorSpider )  ),
					new SlayerEntry( SlayerName.Terathan, typeof( TerathanAvenger ), typeof( TerathanDrone ), typeof( TerathanMatriarch ), typeof( TerathanWarrior ) )
				};

			reptilian.Opposition = new SlayerGroup[]{ arachnid };
			reptilian.FoundOn = new Type[]{ typeof( TerathanAvenger ), typeof( TerathanMatriarch ) };
			reptilian.Super = new SlayerEntry( SlayerName.ReptilianDeath, typeof( SkeletalDragonRenowned ), typeof( AncientWyrm ), typeof( WyvernRenowned ), typeof( DeepSeaSerpent ), typeof( GreaterDragon ), typeof( Dragon ), typeof( Drake ), typeof( GiantIceWorm ), typeof( IceSerpent ), typeof( GiantSerpent ), typeof( Hiryu ), typeof( IceSnake ), typeof( JukaLord ), typeof( JukaMage ), typeof( JukaWarrior ), typeof( LavaSerpent ), typeof( LavaSnake ), typeof( LesserHiryu ), typeof( Lizardman ), typeof( OphidianArchmage ), typeof( OphidianKnight ), typeof( OphidianMage ), typeof( OphidianMatriarch ), typeof( OphidianWarrior ), typeof( SeaSerpent ), typeof( Serado ), typeof( SerpentineDragon ), typeof( ShadowWyrm ), typeof( SilverSerpent ), typeof( SkeletalDragon ), typeof( Snake ), typeof( SwampDragon ), typeof( WhiteWyrm ), typeof( Wyvern ), typeof( Yamandon ), typeof( Hydra ), typeof( CrystalHydra ), typeof( CrystalSeaSerpent ), typeof( Reptalon ), typeof( Rend ), typeof( Thrasher ), typeof( Abscess ), typeof( Grim ), typeof( ChickenLizard ), typeof( StygianDragon ), typeof( FairyDragon ), typeof( Skree ), typeof( Slith ), typeof( StoneSlith ), typeof( ToxicSlith ), typeof( Raptor ), typeof( Kepetch ), typeof( KepetchAmbusher ) );
			reptilian.Entries = new SlayerEntry[]
				{
					new SlayerEntry( SlayerName.DragonSlaying, typeof( SkeletalDragonRenowned ), typeof( WyvernRenowned ), typeof( AncientWyrm ), typeof( GreaterDragon ), typeof( Dragon ), typeof( Drake ), typeof( Hiryu ), typeof( LesserHiryu ), typeof( SerpentineDragon ), typeof( ShadowWyrm ), typeof( SkeletalDragon ), typeof( SwampDragon ), typeof( WhiteWyrm ), typeof( Wyvern ), /* Mondain's Legacy */ typeof( Hydra ), typeof( CrystalHydra ), typeof( Reptalon ), typeof( Rend ) /* End */, typeof( FairyDragon ), typeof( Grim ), typeof( StygianDragon ), typeof( Abscess ) ),
					new SlayerEntry( SlayerName.LizardmanSlaughter, typeof( Lizardman ) ),
					new SlayerEntry( SlayerName.Ophidian, typeof( OphidianArchmage ), typeof( OphidianKnight ), typeof( OphidianMage ), typeof( OphidianMatriarch ), typeof( OphidianWarrior ) ),
					new SlayerEntry( SlayerName.SnakesBane, typeof( DeepSeaSerpent ), typeof( GiantIceWorm ), typeof( GiantSerpent ), typeof( IceSerpent ), typeof( IceSnake ), typeof( LavaSerpent ), typeof( LavaSnake ), typeof( SeaSerpent ), typeof( Serado ), typeof( SilverSerpent ), typeof( Snake ), typeof( Yamandon ), /* Mondain's Legacy */ typeof( CrystalSeaSerpent ) /* End */ )
				};

                        goblin.Opposition = new SlayerGroup[]{ humanoid };
			goblin.Super = new SlayerEntry( SlayerName.Goblin, typeof( EnslavedGoblinScout ), typeof( EnslavedGoblinKeeper ), typeof( EnslavedGreenGoblinAlchemist ), typeof( EnslavedGoblinMage ),	typeof( EnslavedGrayGoblin ), typeof( GreenGoblinScout ), typeof( GreenGoblinAlchemist ), typeof( GreenGoblin ) );
			goblin.Entries = new SlayerEntry[]
                                {
					new SlayerEntry( SlayerName.Goblin, typeof( EnslavedGoblinScout ), typeof( EnslavedGoblinKeeper ), typeof( EnslavedGreenGoblin ), typeof( EnslavedGreenGoblinAlchemist ), typeof( EnslavedGoblinMage ), typeof( EnslavedGreenGoblinAlchemist ),	typeof( EnslavedGrayGoblin ), typeof( GreenGoblinScout ), typeof( GreenGoblinAlchemist ), typeof( GreenGoblin ), typeof( GrayGoblinMage ), typeof( GrayGoblinKeeper ), typeof( GrayGoblin ), typeof( ReownedGreenGoblinAlchemist ), typeof( ReownedGrayGoblinMage ), typeof( GreenGoblinAlchemistRenowned ), typeof( GrayGoblinMageRenowned ) )
                                };


			m_Groups = new SlayerGroup[]
				{
					humanoid,
					undead,
                                        fey,
					elemental,
					abyss,
					arachnid,
					reptilian,
                                        goblin
				};

			m_TotalEntries = CompileEntries( m_Groups );
		}

		private static SlayerEntry[] CompileEntries( SlayerGroup[] groups )
		{
			SlayerEntry[] entries = new SlayerEntry[29];

			for ( int i = 0; i < groups.Length; ++i )
			{
				SlayerGroup g = groups[i];

				g.Super.Group = g;

				entries[(int)g.Super.Name] = g.Super;

				for ( int j = 0; j < g.Entries.Length; ++j )
				{
					g.Entries[j].Group = g;
					entries[(int)g.Entries[j].Name] = g.Entries[j];
				}
			}

			return entries;
		}

		private SlayerGroup[] m_Opposition;
		private SlayerEntry m_Super;
		private SlayerEntry[] m_Entries;
		private Type[] m_FoundOn;

		public SlayerGroup[] Opposition{ get{ return m_Opposition; } set{ m_Opposition = value; } }
		public SlayerEntry Super{ get{ return m_Super; } set{ m_Super = value; } }
		public SlayerEntry[] Entries{ get{ return m_Entries; } set{ m_Entries = value; } }
		public Type[] FoundOn{ get{ return m_FoundOn; } set{ m_FoundOn = value; } }

		public bool OppositionSuperSlays( Mobile m )
		{
			for( int i = 0; i < Opposition.Length; i++ )
			{
				if ( Opposition[i].Super.Slays( m ) )
					return true;
			}

			return false;
		}

		public SlayerGroup()
		{
		}
	}
}