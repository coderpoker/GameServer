﻿using System;
using System.Runtime.InteropServices;
using GameServerCore.Domain.GameObjects;

namespace LeagueSandbox.GameServer.GameObjects.Stats
{
    // deviates from the style guide
    // see discussion here:https://github.com/LeagueSandbox/GameServer/pull/583
    [StructLayout(LayoutKind.Explicit)]
    public class ChampionStats : IChampionStats
    {
        [FieldOffset(0)]
        public int Assists;
        [FieldOffset(8)]
        public int Kills;
        [FieldOffset(16)]
        public int DoubleKills;
        [FieldOffset(32)]
        public int UnrealKills;
        [FieldOffset(36)]
        public float GoldEarned;
        [FieldOffset(40)]
        public float GoldSpent;
        [FieldOffset(84)]
        public int CurrentKillingSpree;
        [FieldOffset(88)]
        public float LargestCriticalStrike;
        [FieldOffset(92)]
        public int LargestKillingSpree;
        [FieldOffset(96)]
        public int LargestMultiKill;
        [FieldOffset(104)]
        public float LongestTimeSpentLiving;
        [FieldOffset(108)]
        public float MagicDamageDealt;
        [FieldOffset(112)]
        public float MagicDamageDealtToChampions;
        [FieldOffset(116)]
        public float MagicDamageTaken;
        [FieldOffset(120)]
        public int MinionsKilled;
        [FieldOffset(126)]
        public int NeutralMinionsKilled;
        [FieldOffset(130)]
        public int NeutralMinionsKilledInEnemyJungle;
        [FieldOffset(134)]
        public int NeutralMinionsKilledInTeamJungle;
        [FieldOffset(142)]
        public int Deaths;
        [FieldOffset(146)]
        public int PentaKills;
        [FieldOffset(150)]
        public float PhysicalDamageDealt;
        [FieldOffset(154)]
        public float PhysicalDamageDealtToChampions;
        [FieldOffset(158)]
        public float PhysicalDamageTaken;
        [FieldOffset(166)]
        public int QuadraKills;
        [FieldOffset(206)]
        public int TeamId;
        [FieldOffset(226)]
        public float TotalDamageDealt;
        [FieldOffset(230)]
        public float TotalDamageDealtToChampions;
        [FieldOffset(234)]
        public float TotalDamageTaken;
        [FieldOffset(238)]
        public int TotalHeal;
        [FieldOffset(242)]
        public float TotalTimeCrowdControlDealt;
        [FieldOffset(246)]
        public float TotalTimeSpentDead;
        [FieldOffset(250)]
        public int TotalUnitsHealed;
        [FieldOffset(254)]
        public int TripleKills;
        [FieldOffset(258)]
        public float TrueDamageDealt;
        [FieldOffset(262)]
        public float TrueDamageDealtToChampions;
        [FieldOffset(266)]
        public float TrueDamageTaken;
        [FieldOffset(270)]
        public int TurretsKilled;
        [FieldOffset(274)]
        public int BarracksKilled;
        [FieldOffset(282)]
        public int WardsKilled;
        [FieldOffset(286)]
        public int WardsPlaced;
        [FieldOffset(298)]
        // sort of length (when above 0 sends malformed buffer error)
        public short Padding;

        int IChampionStats.Assists => Assists;
        int IChampionStats.Kills => Kills;
        int IChampionStats.DoubleKills => DoubleKills;
        int IChampionStats.UnrealKills => UnrealKills;
        float IChampionStats.GoldEarned => GoldEarned;
        float IChampionStats.GoldSpent => GoldSpent;
        int IChampionStats.CurrentKillingSpree => CurrentKillingSpree;
        float IChampionStats.LargestCriticalStrike => LargestCriticalStrike;
        int IChampionStats.LargestKillingSpree => LargestKillingSpree;
        int IChampionStats.LargestMultiKill => LargestMultiKill;
        float IChampionStats.LongestTimeSpentLiving => LongestTimeSpentLiving;
        float IChampionStats.MagicDamageDealt => MagicDamageDealt;
        float IChampionStats.MagicDamageDealtToChampions => MagicDamageDealtToChampions;
        float IChampionStats.MagicDamageTaken => MagicDamageTaken;
        int IChampionStats.MinionsKilled => MinionsKilled;
        int IChampionStats.NeutralMinionsKilled => NeutralMinionsKilled;
        int IChampionStats.NeutralMinionsKilledInEnemyJungle => NeutralMinionsKilledInEnemyJungle;
        int IChampionStats.NeutralMinionsKilledInTeamJungle => NeutralMinionsKilledInTeamJungle;
        int IChampionStats.Deaths => Deaths;
        int IChampionStats.PentaKills => PentaKills;
        float IChampionStats.PhysicalDamageDealt => PhysicalDamageDealt;
        float IChampionStats.PhysicalDamageDealtToChampions => PhysicalDamageDealtToChampions;
        float IChampionStats.PhysicalDamageTaken => PhysicalDamageTaken;
        int IChampionStats.QuadraKills => QuadraKills;
        int IChampionStats.TeamId => TeamId;
        float IChampionStats.TotalDamageDealt => TotalDamageDealt;
        float IChampionStats.TotalDamageDealtToChampions => TotalDamageDealtToChampions;
        float IChampionStats.TotalDamageTaken => TotalDamageTaken;
        int IChampionStats.TotalHeal => TotalHeal;
        float IChampionStats.TotalTimeCrowdControlDealt => TotalTimeCrowdControlDealt;
        float IChampionStats.TotalTimeSpentDead => TotalTimeSpentDead;
        int IChampionStats.TotalUnitsHealed => TotalUnitsHealed;
        int IChampionStats.TripleKills => TripleKills;
        float IChampionStats.TrueDamageDealt => TrueDamageDealt;
        float IChampionStats.TrueDamageDealtToChampions => TrueDamageDealtToChampions;
        float IChampionStats.TrueDamageTaken => TrueDamageTaken;
        int IChampionStats.TurretsKilled => TurretsKilled;
        int IChampionStats.BarracksKilled => BarracksKilled;
        int IChampionStats.WardsKilled => WardsKilled;
        int IChampionStats.WardsPlaced => WardsPlaced;

        // TODO: move to universal serializer
        // also code here is unsafe, but thats prefered than just
        // write a function that simply dumps all the variables
        public static byte[] GetBytes(ChampionStats stats)
        {
            int size = Marshal.SizeOf(stats);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(stats, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }

        public byte[] GetBytes()
        {
            return GetBytes(this);
        }
    }
}
