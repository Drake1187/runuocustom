using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a master jonath corpse" )]
	public class MasterJonath : BaseCreature
	{
		[Constructable]
		public MasterJonath() : base( AIType.AI_NecroMage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a master jonath";
			Title = "the necromancer";
			BaseSoundID = 0x1C3;
			Hue = 0x497;
			Body = Utility.Random( 0x7D, 1 );

			SetStr( 109, 131 );
			SetDex( 98, 110 );
			SetInt( 232, 259 );

			SetHits( 766, 920 );

			SetDamage( 10, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 55, 60 );
			SetResistance( ResistanceType.Fire, 43, 49 );
			SetResistance( ResistanceType.Cold, 45, 80 );
			SetResistance( ResistanceType.Poison, 41, 45 );
			SetResistance( ResistanceType.Energy, 54, 55 );

			SetSkill( SkillName.Wrestling, 80.5, 88.6 );
			SetSkill( SkillName.Tactics, 88.5, 95.1 );
			SetSkill( SkillName.MagicResist, 102.7, 102.9 );
			SetSkill( SkillName.Magery, 100.0, 106.6 );
			SetSkill( SkillName.EvalInt, 99.6, 106.9 );
			SetSkill( SkillName.Necromancy, 100.0, 106.6 );
			SetSkill( SkillName.SpiritSpeak, 99.6, 106.9 );
			
			if ( Utility.RandomBool() )
				PackNecroScroll( Utility.RandomMinMax( 5, 9 ) );
			else
				PackScroll( 4, 7 );
				
			PackReg( 7 );
			PackReg( 7 );
			PackReg( 8 );
		}
		
		public override void GenerateLoot()
		{
			AddLoot( LootPack.AosUltraRich, 4 );
		}
		
		public override void OnDeath( Container c )
		{
			base.OnDeath( c );		
			
			if ( Utility.RandomDouble() < 0.05 )				
				c.DropItem( new ParrotItem() );
			
			if ( Utility.RandomDouble() < 0.15 )
				c.DropItem( new DisintegratingThesisNotes() );
		}
		
		public override bool GivesMinorArtifact{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 5; } }
	
		public MasterJonath( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}
	}
}

