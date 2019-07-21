using System.Collections.Generic;
using System;

namespace DPPtHGSS
{
    public static class Pokemon
    {
        public static Dictionary<UInt16, string> dpPKMShuffle = new Dictionary<UInt16, string>();
        public static Dictionary<UInt16, string> dPKMSpecies = new Dictionary<UInt16, string>();
        private static bool mDictionariesInitialized = false;

        public static void InitializeDictionaries()
        {
            if (mDictionariesInitialized) return;


            dpPKMShuffle.Add(0, "ABCD");
            dpPKMShuffle.Add(1, "ABDC");
            dpPKMShuffle.Add(2, "ACBD");
            dpPKMShuffle.Add(3, "ACDB");
            dpPKMShuffle.Add(4, "ADBC");
            dpPKMShuffle.Add(5, "ADCB");
            dpPKMShuffle.Add(6, "BACD");
            dpPKMShuffle.Add(7, "BADC");
            dpPKMShuffle.Add(8, "BCAD");
            dpPKMShuffle.Add(9, "BCDA");
            dpPKMShuffle.Add(10, "BDAC");
            dpPKMShuffle.Add(11, "BDCA");
            dpPKMShuffle.Add(12, "CABD");
            dpPKMShuffle.Add(13, "CADB");
            dpPKMShuffle.Add(14, "CBAD");
            dpPKMShuffle.Add(15, "CBDA");
            dpPKMShuffle.Add(16, "CDAB");
            dpPKMShuffle.Add(17, "CDBA");
            dpPKMShuffle.Add(18, "DABC");
            dpPKMShuffle.Add(19, "DACB");
            dpPKMShuffle.Add(20, "DBAC");
            dpPKMShuffle.Add(21, "DBCA");
            dpPKMShuffle.Add(22, "DCAB");
            dpPKMShuffle.Add(23, "DCBA");

            dPKMSpecies.Add(0, "MissingNo.");
            dPKMSpecies.Add(1, "Bulbasaur");
            dPKMSpecies.Add(2, "Ivysaur");
            dPKMSpecies.Add(3, "Venusaur");
            dPKMSpecies.Add(4, "Charmander");
            dPKMSpecies.Add(5, "Charmeleon");
            dPKMSpecies.Add(6, "Charizard");
            dPKMSpecies.Add(7, "Squirtle");
            dPKMSpecies.Add(8, "Wartortle");
            dPKMSpecies.Add(9, "Blastoise");
            dPKMSpecies.Add(10, "Caterpie");
            dPKMSpecies.Add(11, "Metapod");
            dPKMSpecies.Add(12, "Butterfree");
            dPKMSpecies.Add(13, "Weedle");
            dPKMSpecies.Add(14, "Kakuna");
            dPKMSpecies.Add(15, "Beedrill");
            dPKMSpecies.Add(16, "Pidgey");
            dPKMSpecies.Add(17, "Pidgeotto");
            dPKMSpecies.Add(18, "Pidgeot");
            dPKMSpecies.Add(19, "Rattata");
            dPKMSpecies.Add(20, "Raticate");
            dPKMSpecies.Add(21, "Spearow");
            dPKMSpecies.Add(22, "Fearow");
            dPKMSpecies.Add(23, "Ekans");
            dPKMSpecies.Add(24, "Arbok");
            dPKMSpecies.Add(25, "Pikachu");
            dPKMSpecies.Add(26, "Raichu");
            dPKMSpecies.Add(27, "Sandshrew");
            dPKMSpecies.Add(28, "Sandslash");
            dPKMSpecies.Add(29, "Nidoran" + char.ConvertFromUtf32(0x2640));
            dPKMSpecies.Add(30, "Nidorina");
            dPKMSpecies.Add(31, "Nidoqueen");
            dPKMSpecies.Add(32, "Nidoran" + char.ConvertFromUtf32(0x2642));
            dPKMSpecies.Add(33, "Nidorino");
            dPKMSpecies.Add(34, "Nidoking");
            dPKMSpecies.Add(35, "Clefairy");
            dPKMSpecies.Add(36, "Clefable");
            dPKMSpecies.Add(37, "Vulpix");
            dPKMSpecies.Add(38, "Ninetales");
            dPKMSpecies.Add(39, "Jigglypuff");
            dPKMSpecies.Add(40, "Wigglytuff");
            dPKMSpecies.Add(41, "Zubat");
            dPKMSpecies.Add(42, "Golbat");
            dPKMSpecies.Add(43, "Oddish");
            dPKMSpecies.Add(44, "Gloom");
            dPKMSpecies.Add(45, "Vileplume");
            dPKMSpecies.Add(46, "Paras");
            dPKMSpecies.Add(47, "Parasect");
            dPKMSpecies.Add(48, "Venonat");
            dPKMSpecies.Add(49, "Venomoth");
            dPKMSpecies.Add(50, "Diglett");
            dPKMSpecies.Add(51, "Dugtrio");
            dPKMSpecies.Add(52, "Meowth");
            dPKMSpecies.Add(53, "Persian");
            dPKMSpecies.Add(54, "Psyduck");
            dPKMSpecies.Add(55, "Golduck");
            dPKMSpecies.Add(56, "Mankey");
            dPKMSpecies.Add(57, "Primeape");
            dPKMSpecies.Add(58, "Growlithe");
            dPKMSpecies.Add(59, "Arcanine");
            dPKMSpecies.Add(60, "Poliwag");
            dPKMSpecies.Add(61, "Poliwhirl");
            dPKMSpecies.Add(62, "Poliwrath");
            dPKMSpecies.Add(63, "Abra");
            dPKMSpecies.Add(64, "Kadabra");
            dPKMSpecies.Add(65, "Alakazam");
            dPKMSpecies.Add(66, "Machop");
            dPKMSpecies.Add(67, "Machoke");
            dPKMSpecies.Add(68, "Machamp");
            dPKMSpecies.Add(69, "Bellsprout");
            dPKMSpecies.Add(70, "Weepinbell");
            dPKMSpecies.Add(71, "Victreebel");
            dPKMSpecies.Add(72, "Tentacool");
            dPKMSpecies.Add(73, "Tentacruel");
            dPKMSpecies.Add(74, "Geodude");
            dPKMSpecies.Add(75, "Graveler");
            dPKMSpecies.Add(76, "Golem");
            dPKMSpecies.Add(77, "Ponyta");
            dPKMSpecies.Add(78, "Rapidash");
            dPKMSpecies.Add(79, "Slowpoke");
            dPKMSpecies.Add(80, "Slowbro");
            dPKMSpecies.Add(81, "Magnemite");
            dPKMSpecies.Add(82, "Magneton");
            dPKMSpecies.Add(83, "Farfetch'd");
            dPKMSpecies.Add(84, "Doduo");
            dPKMSpecies.Add(85, "Dodrio");
            dPKMSpecies.Add(86, "Seel");
            dPKMSpecies.Add(87, "Dewgong");
            dPKMSpecies.Add(88, "Grimer");
            dPKMSpecies.Add(89, "Muk");
            dPKMSpecies.Add(90, "Shellder");
            dPKMSpecies.Add(91, "Cloyster");
            dPKMSpecies.Add(92, "Gastly");
            dPKMSpecies.Add(93, "Haunter");
            dPKMSpecies.Add(94, "Gengar");
            dPKMSpecies.Add(95, "Onix");
            dPKMSpecies.Add(96, "Drowzee");
            dPKMSpecies.Add(97, "Hypno");
            dPKMSpecies.Add(98, "Krabby");
            dPKMSpecies.Add(99, "Kingler");
            dPKMSpecies.Add(100, "Voltorb");
            dPKMSpecies.Add(101, "Electrode");
            dPKMSpecies.Add(102, "Exeggcute");
            dPKMSpecies.Add(103, "Exeggutor");
            dPKMSpecies.Add(104, "Cubone");
            dPKMSpecies.Add(105, "Marowak");
            dPKMSpecies.Add(106, "Hitmonlee");
            dPKMSpecies.Add(107, "Hitmonchan");
            dPKMSpecies.Add(108, "Lickitung");
            dPKMSpecies.Add(109, "Koffing");
            dPKMSpecies.Add(110, "Weezing");
            dPKMSpecies.Add(111, "Rhyhorn");
            dPKMSpecies.Add(112, "Rhydon");
            dPKMSpecies.Add(113, "Chansey");
            dPKMSpecies.Add(114, "Tangela");
            dPKMSpecies.Add(115, "Kangaskhan");
            dPKMSpecies.Add(116, "Horsea");
            dPKMSpecies.Add(117, "Seadra");
            dPKMSpecies.Add(118, "Goldeen");
            dPKMSpecies.Add(119, "Seaking");
            dPKMSpecies.Add(120, "Staryu");
            dPKMSpecies.Add(121, "Starmie");
            dPKMSpecies.Add(122, "Mr. Mime");
            dPKMSpecies.Add(123, "Scyther");
            dPKMSpecies.Add(124, "Jynx");
            dPKMSpecies.Add(125, "Electabuzz");
            dPKMSpecies.Add(126, "Magmar");
            dPKMSpecies.Add(127, "Pinsir");
            dPKMSpecies.Add(128, "Tauros");
            dPKMSpecies.Add(129, "Magikarp");
            dPKMSpecies.Add(130, "Gyarados");
            dPKMSpecies.Add(131, "Lapras");
            dPKMSpecies.Add(132, "Ditto");
            dPKMSpecies.Add(133, "Eevee");
            dPKMSpecies.Add(134, "Vaporeon");
            dPKMSpecies.Add(135, "Jolteon");
            dPKMSpecies.Add(136, "Flareon");
            dPKMSpecies.Add(137, "Porygon");
            dPKMSpecies.Add(138, "Omanyte");
            dPKMSpecies.Add(139, "Omastar");
            dPKMSpecies.Add(140, "Kabuto");
            dPKMSpecies.Add(141, "Kabutops");
            dPKMSpecies.Add(142, "Aerodactyl");
            dPKMSpecies.Add(143, "Snorlax");
            dPKMSpecies.Add(144, "Articuno");
            dPKMSpecies.Add(145, "Zapdos");
            dPKMSpecies.Add(146, "Moltres");
            dPKMSpecies.Add(147, "Dratini");
            dPKMSpecies.Add(148, "Dragonair");
            dPKMSpecies.Add(149, "Dragonite");
            dPKMSpecies.Add(150, "Mewtwo");
            dPKMSpecies.Add(151, "Mew");
            dPKMSpecies.Add(152, "Chikorita");
            dPKMSpecies.Add(153, "Bayleef");
            dPKMSpecies.Add(154, "Meganium");
            dPKMSpecies.Add(155, "Cyndaquil");
            dPKMSpecies.Add(156, "Quilava");
            dPKMSpecies.Add(157, "Typhlosion");
            dPKMSpecies.Add(158, "Totodile");
            dPKMSpecies.Add(159, "Croconaw");
            dPKMSpecies.Add(160, "Feraligatr");
            dPKMSpecies.Add(161, "Sentret");
            dPKMSpecies.Add(162, "Furret");
            dPKMSpecies.Add(163, "Hoothoot");
            dPKMSpecies.Add(164, "Noctowl");
            dPKMSpecies.Add(165, "Ledyba");
            dPKMSpecies.Add(166, "Ledian");
            dPKMSpecies.Add(167, "Spinarak");
            dPKMSpecies.Add(168, "Ariados");
            dPKMSpecies.Add(169, "Crobat");
            dPKMSpecies.Add(170, "Chinchou");
            dPKMSpecies.Add(171, "Lanturn");
            dPKMSpecies.Add(172, "Pichu");
            dPKMSpecies.Add(173, "Cleffa");
            dPKMSpecies.Add(174, "Igglybuff");
            dPKMSpecies.Add(175, "Togepi");
            dPKMSpecies.Add(176, "Togetic");
            dPKMSpecies.Add(177, "Natu");
            dPKMSpecies.Add(178, "Xatu");
            dPKMSpecies.Add(179, "Mareep");
            dPKMSpecies.Add(180, "Flaaffy");
            dPKMSpecies.Add(181, "Ampharos");
            dPKMSpecies.Add(182, "Bellossom");
            dPKMSpecies.Add(183, "Marill");
            dPKMSpecies.Add(184, "Azumarill");
            dPKMSpecies.Add(185, "Sudowoodo");
            dPKMSpecies.Add(186, "Politoed");
            dPKMSpecies.Add(187, "Hoppip");
            dPKMSpecies.Add(188, "Skiploom");
            dPKMSpecies.Add(189, "Jumpluff");
            dPKMSpecies.Add(190, "Aipom");
            dPKMSpecies.Add(191, "Sunkern");
            dPKMSpecies.Add(192, "Sunflora");
            dPKMSpecies.Add(193, "Yanma");
            dPKMSpecies.Add(194, "Wooper");
            dPKMSpecies.Add(195, "Quagsire");
            dPKMSpecies.Add(196, "Espeon");
            dPKMSpecies.Add(197, "Umbreon");
            dPKMSpecies.Add(198, "Murkrow");
            dPKMSpecies.Add(199, "Slowking");
            dPKMSpecies.Add(200, "Misdreavus");
            dPKMSpecies.Add(201, "Unown");
            dPKMSpecies.Add(202, "Wobbuffet");
            dPKMSpecies.Add(203, "Girafarig");
            dPKMSpecies.Add(204, "Pineco");
            dPKMSpecies.Add(205, "Forretress");
            dPKMSpecies.Add(206, "Dunsparce");
            dPKMSpecies.Add(207, "Gligar");
            dPKMSpecies.Add(208, "Steelix");
            dPKMSpecies.Add(209, "Snubbull");
            dPKMSpecies.Add(210, "Granbull");
            dPKMSpecies.Add(211, "Qwilfish");
            dPKMSpecies.Add(212, "Scizor");
            dPKMSpecies.Add(213, "Shuckle");
            dPKMSpecies.Add(214, "Heracross");
            dPKMSpecies.Add(215, "Sneasel");
            dPKMSpecies.Add(216, "Teddiursa");
            dPKMSpecies.Add(217, "Ursaring");
            dPKMSpecies.Add(218, "Slugma");
            dPKMSpecies.Add(219, "Magcargo");
            dPKMSpecies.Add(220, "Swinub");
            dPKMSpecies.Add(221, "Piloswine");
            dPKMSpecies.Add(222, "Corsola");
            dPKMSpecies.Add(223, "Remoraid");
            dPKMSpecies.Add(224, "Octillery");
            dPKMSpecies.Add(225, "Delibird");
            dPKMSpecies.Add(226, "Mantine");
            dPKMSpecies.Add(227, "Skarmory");
            dPKMSpecies.Add(228, "Houndour");
            dPKMSpecies.Add(229, "Houndoom");
            dPKMSpecies.Add(230, "Kingdra");
            dPKMSpecies.Add(231, "Phanpy");
            dPKMSpecies.Add(232, "Donphan");
            dPKMSpecies.Add(233, "Porygon2");
            dPKMSpecies.Add(234, "Stantler");
            dPKMSpecies.Add(235, "Smeargle");
            dPKMSpecies.Add(236, "Tyrogue");
            dPKMSpecies.Add(237, "Hitmontop");
            dPKMSpecies.Add(238, "Smoochum");
            dPKMSpecies.Add(239, "Elekid");
            dPKMSpecies.Add(240, "Magby");
            dPKMSpecies.Add(241, "Miltank");
            dPKMSpecies.Add(242, "Blissey");
            dPKMSpecies.Add(243, "Raikou");
            dPKMSpecies.Add(244, "Entei");
            dPKMSpecies.Add(245, "Suicune");
            dPKMSpecies.Add(246, "Larvitar");
            dPKMSpecies.Add(247, "Pupitar");
            dPKMSpecies.Add(248, "Tyranitar");
            dPKMSpecies.Add(249, "Lugia");
            dPKMSpecies.Add(250, "Ho-Oh");
            dPKMSpecies.Add(251, "Celebi");
            dPKMSpecies.Add(252, "Treecko");
            dPKMSpecies.Add(253, "Grovyle");
            dPKMSpecies.Add(254, "Sceptile");
            dPKMSpecies.Add(255, "Torchic");
            dPKMSpecies.Add(256, "Combusken");
            dPKMSpecies.Add(257, "Blaziken");
            dPKMSpecies.Add(258, "Mudkip");
            dPKMSpecies.Add(259, "Marshtomp");
            dPKMSpecies.Add(260, "Swampert");
            dPKMSpecies.Add(261, "Poochyena");
            dPKMSpecies.Add(262, "Mightyena");
            dPKMSpecies.Add(263, "Zigzagoon");
            dPKMSpecies.Add(264, "Linoone");
            dPKMSpecies.Add(265, "Wurmple");
            dPKMSpecies.Add(266, "Silcoon");
            dPKMSpecies.Add(267, "Beautifly");
            dPKMSpecies.Add(268, "Cascoon");
            dPKMSpecies.Add(269, "Dustox");
            dPKMSpecies.Add(270, "Lotad");
            dPKMSpecies.Add(271, "Lombre");
            dPKMSpecies.Add(272, "Ludicolo");
            dPKMSpecies.Add(273, "Seedot");
            dPKMSpecies.Add(274, "Nuzleaf");
            dPKMSpecies.Add(275, "Shiftry");
            dPKMSpecies.Add(276, "Taillow");
            dPKMSpecies.Add(277, "Swellow");
            dPKMSpecies.Add(278, "Wingull");
            dPKMSpecies.Add(279, "Pelipper");
            dPKMSpecies.Add(280, "Ralts");
            dPKMSpecies.Add(281, "Kirlia");
            dPKMSpecies.Add(282, "Gardevoir");
            dPKMSpecies.Add(283, "Surskit");
            dPKMSpecies.Add(284, "Masquerain");
            dPKMSpecies.Add(285, "Shroomish");
            dPKMSpecies.Add(286, "Breloom");
            dPKMSpecies.Add(287, "Slakoth");
            dPKMSpecies.Add(288, "Vigoroth");
            dPKMSpecies.Add(289, "Slaking");
            dPKMSpecies.Add(290, "Nincada");
            dPKMSpecies.Add(291, "Ninjask");
            dPKMSpecies.Add(292, "Shedinja");
            dPKMSpecies.Add(293, "Whismur");
            dPKMSpecies.Add(294, "Loudred");
            dPKMSpecies.Add(295, "Exploud");
            dPKMSpecies.Add(296, "Makuhita");
            dPKMSpecies.Add(297, "Hariyama");
            dPKMSpecies.Add(298, "Azurill");
            dPKMSpecies.Add(299, "Nosepass");
            dPKMSpecies.Add(300, "Skitty");
            dPKMSpecies.Add(301, "Delcatty");
            dPKMSpecies.Add(302, "Sableye");
            dPKMSpecies.Add(303, "Mawile");
            dPKMSpecies.Add(304, "Aron");
            dPKMSpecies.Add(305, "Lairon");
            dPKMSpecies.Add(306, "Aggron");
            dPKMSpecies.Add(307, "Meditite");
            dPKMSpecies.Add(308, "Medicham");
            dPKMSpecies.Add(309, "Electrike");
            dPKMSpecies.Add(310, "Manectric");
            dPKMSpecies.Add(311, "Plusle");
            dPKMSpecies.Add(312, "Minun");
            dPKMSpecies.Add(313, "Volbeat");
            dPKMSpecies.Add(314, "Illumise");
            dPKMSpecies.Add(315, "Roselia");
            dPKMSpecies.Add(316, "Gulpin");
            dPKMSpecies.Add(317, "Swalot");
            dPKMSpecies.Add(318, "Carvanha");
            dPKMSpecies.Add(319, "Sharpedo");
            dPKMSpecies.Add(320, "Wailmer");
            dPKMSpecies.Add(321, "Wailord");
            dPKMSpecies.Add(322, "Numel");
            dPKMSpecies.Add(323, "Camerupt");
            dPKMSpecies.Add(324, "Torkoal");
            dPKMSpecies.Add(325, "Spoink");
            dPKMSpecies.Add(326, "Grumpig");
            dPKMSpecies.Add(327, "Spinda");
            dPKMSpecies.Add(328, "Trapinch");
            dPKMSpecies.Add(329, "Vibrava");
            dPKMSpecies.Add(330, "Flygon");
            dPKMSpecies.Add(331, "Cacnea");
            dPKMSpecies.Add(332, "Cacturne");
            dPKMSpecies.Add(333, "Swablu");
            dPKMSpecies.Add(334, "Altaria");
            dPKMSpecies.Add(335, "Zangoose");
            dPKMSpecies.Add(336, "Seviper");
            dPKMSpecies.Add(337, "Lunatone");
            dPKMSpecies.Add(338, "Solrock");
            dPKMSpecies.Add(339, "Barboach");
            dPKMSpecies.Add(340, "Whiscash");
            dPKMSpecies.Add(341, "Corphish");
            dPKMSpecies.Add(342, "Crawdaunt");
            dPKMSpecies.Add(343, "Baltoy");
            dPKMSpecies.Add(344, "Claydol");
            dPKMSpecies.Add(345, "Lileep");
            dPKMSpecies.Add(346, "Cradily");
            dPKMSpecies.Add(347, "Anorith");
            dPKMSpecies.Add(348, "Armaldo");
            dPKMSpecies.Add(349, "Feebas");
            dPKMSpecies.Add(350, "Milotic");
            dPKMSpecies.Add(351, "Castform");
            dPKMSpecies.Add(352, "Kecleon");
            dPKMSpecies.Add(353, "Shuppet");
            dPKMSpecies.Add(354, "Banette");
            dPKMSpecies.Add(355, "Duskull");
            dPKMSpecies.Add(356, "Dusclops");
            dPKMSpecies.Add(357, "Tropius");
            dPKMSpecies.Add(358, "Chimecho");
            dPKMSpecies.Add(359, "Absol");
            dPKMSpecies.Add(360, "Wynaut");
            dPKMSpecies.Add(361, "Snorunt");
            dPKMSpecies.Add(362, "Glalie");
            dPKMSpecies.Add(363, "Spheal");
            dPKMSpecies.Add(364, "Sealeo");
            dPKMSpecies.Add(365, "Walrein");
            dPKMSpecies.Add(366, "Clamperl");
            dPKMSpecies.Add(367, "Huntail");
            dPKMSpecies.Add(368, "Gorebyss");
            dPKMSpecies.Add(369, "Relicanth");
            dPKMSpecies.Add(370, "Luvdisc");
            dPKMSpecies.Add(371, "Bagon");
            dPKMSpecies.Add(372, "Shelgon");
            dPKMSpecies.Add(373, "Salamence");
            dPKMSpecies.Add(374, "Beldum");
            dPKMSpecies.Add(375, "Metang");
            dPKMSpecies.Add(376, "Metagross");
            dPKMSpecies.Add(377, "Regirock");
            dPKMSpecies.Add(378, "Regice");
            dPKMSpecies.Add(379, "Registeel");
            dPKMSpecies.Add(380, "Latias");
            dPKMSpecies.Add(381, "Latios");
            dPKMSpecies.Add(382, "Kyogre");
            dPKMSpecies.Add(383, "Groudon");
            dPKMSpecies.Add(384, "Rayquaza");
            dPKMSpecies.Add(385, "Jirachi");
            dPKMSpecies.Add(386, "Deoxys");
            dPKMSpecies.Add(387, "Turtwig");
            dPKMSpecies.Add(388, "Grotle");
            dPKMSpecies.Add(389, "Torterra");
            dPKMSpecies.Add(390, "Chimchar");
            dPKMSpecies.Add(391, "Monferno");
            dPKMSpecies.Add(392, "Infernape");
            dPKMSpecies.Add(393, "Piplup");
            dPKMSpecies.Add(394, "Prinplup");
            dPKMSpecies.Add(395, "Empoleon");
            dPKMSpecies.Add(396, "Starly");
            dPKMSpecies.Add(397, "Staravia");
            dPKMSpecies.Add(398, "Staraptor");
            dPKMSpecies.Add(399, "Bidoof");
            dPKMSpecies.Add(400, "Bibarel");
            dPKMSpecies.Add(401, "Kricketot");
            dPKMSpecies.Add(402, "Kricketune");
            dPKMSpecies.Add(403, "Shinx");
            dPKMSpecies.Add(404, "Luxio");
            dPKMSpecies.Add(405, "Luxray");
            dPKMSpecies.Add(406, "Budew");
            dPKMSpecies.Add(407, "Roserade");
            dPKMSpecies.Add(408, "Cranidos");
            dPKMSpecies.Add(409, "Rampardos");
            dPKMSpecies.Add(410, "Shieldon");
            dPKMSpecies.Add(411, "Bastiodon");
            dPKMSpecies.Add(412, "Burmy");
            dPKMSpecies.Add(413, "Wormadam");
            dPKMSpecies.Add(414, "Mothim");
            dPKMSpecies.Add(415, "Combee");
            dPKMSpecies.Add(416, "Vespiquen");
            dPKMSpecies.Add(417, "Pachirisu");
            dPKMSpecies.Add(418, "Buizel");
            dPKMSpecies.Add(419, "Floatzel");
            dPKMSpecies.Add(420, "Cherubi");
            dPKMSpecies.Add(421, "Cherrim");
            dPKMSpecies.Add(422, "Shellos");
            dPKMSpecies.Add(423, "Gastrodon");
            dPKMSpecies.Add(424, "Ambipom");
            dPKMSpecies.Add(425, "Drifloon");
            dPKMSpecies.Add(426, "Drifblim");
            dPKMSpecies.Add(427, "Buneary");
            dPKMSpecies.Add(428, "Lopunny");
            dPKMSpecies.Add(429, "Mismagius");
            dPKMSpecies.Add(430, "Honchkrow");
            dPKMSpecies.Add(431, "Glameow");
            dPKMSpecies.Add(432, "Purugly");
            dPKMSpecies.Add(433, "Chingling");
            dPKMSpecies.Add(434, "Stunky");
            dPKMSpecies.Add(435, "Skuntank");
            dPKMSpecies.Add(436, "Bronzor");
            dPKMSpecies.Add(437, "Bronzong");
            dPKMSpecies.Add(438, "Bonsly");
            dPKMSpecies.Add(439, "Mime Jr.");
            dPKMSpecies.Add(440, "Happiny");
            dPKMSpecies.Add(441, "Chatot");
            dPKMSpecies.Add(442, "Spiritomb");
            dPKMSpecies.Add(443, "Gible");
            dPKMSpecies.Add(444, "Gabite");
            dPKMSpecies.Add(445, "Garchomp");
            dPKMSpecies.Add(446, "Munchlax");
            dPKMSpecies.Add(447, "Riolu");
            dPKMSpecies.Add(448, "Lucario");
            dPKMSpecies.Add(449, "Hippopotas");
            dPKMSpecies.Add(450, "Hippowdon");
            dPKMSpecies.Add(451, "Skorupi");
            dPKMSpecies.Add(452, "Drapion");
            dPKMSpecies.Add(453, "Croagunk");
            dPKMSpecies.Add(454, "Toxicroak");
            dPKMSpecies.Add(455, "Carnivine");
            dPKMSpecies.Add(456, "Finneon");
            dPKMSpecies.Add(457, "Lumineon");
            dPKMSpecies.Add(458, "Mantyke");
            dPKMSpecies.Add(459, "Snover");
            dPKMSpecies.Add(460, "Abomasnow");
            dPKMSpecies.Add(461, "Weavile");
            dPKMSpecies.Add(462, "Magnezone");
            dPKMSpecies.Add(463, "Lickilicky");
            dPKMSpecies.Add(464, "Rhyperior");
            dPKMSpecies.Add(465, "Tangrowth");
            dPKMSpecies.Add(466, "Electivire");
            dPKMSpecies.Add(467, "Magmortar");
            dPKMSpecies.Add(468, "Togekiss");
            dPKMSpecies.Add(469, "Yanmega");
            dPKMSpecies.Add(470, "Leafeon");
            dPKMSpecies.Add(471, "Glaceon");
            dPKMSpecies.Add(472, "Gliscor");
            dPKMSpecies.Add(473, "Mamoswine");
            dPKMSpecies.Add(474, "Porygon-Z");
            dPKMSpecies.Add(475, "Gallade");
            dPKMSpecies.Add(476, "Probopass");
            dPKMSpecies.Add(477, "Dusknoir");
            dPKMSpecies.Add(478, "Froslass");
            dPKMSpecies.Add(479, "Rotom");
            dPKMSpecies.Add(480, "Uxie");
            dPKMSpecies.Add(481, "Mesprit");
            dPKMSpecies.Add(482, "Azelf");
            dPKMSpecies.Add(483, "Dialga");
            dPKMSpecies.Add(484, "Palkia");
            dPKMSpecies.Add(485, "Heatran");
            dPKMSpecies.Add(486, "Regigigas");
            dPKMSpecies.Add(487, "Giratina");
            dPKMSpecies.Add(488, "Cresselia");
            dPKMSpecies.Add(489, "Phione");
            dPKMSpecies.Add(490, "Manaphy");
            dPKMSpecies.Add(491, "Darkrai");
            dPKMSpecies.Add(492, "Shaymin");
            dPKMSpecies.Add(493, "Arceus");

            mDictionariesInitialized = true;
        }

        public static byte[] EncryptPokemon(byte[] PKM)
        {
            UInt16 checksum = Calculate_Checksum(PKM);
            byte[] chkBytes = BitConverter.GetBytes(checksum);

            PKM[6] = chkBytes[0];
            PKM[7] = chkBytes[1];

            byte[] Encrypted = ShuffleBytes(PKM);

            Encrypted = Decrypt_Data(Encrypted);

            return Encrypted;
        }

        public static UInt16 Calculate_Checksum(byte[] PKM)
        {
            byte[] Data = new byte[PKM.Length];

            for (int i = 0; i <= Data.Length - 1; i++)
            {
                Data[i] = PKM[i];
            }

            uint index = 0;

            for (int i = 0x8; i <= 0x86; i += 2)
            {
                index += (uint)(Data[i] + (Data[i + 1] * 256));
            }

            string bin = DecToBin(index, 32);
            bin = bin.Substring(16, 16);
            return Convert.ToUInt16(bin, 2);
        }

        private static byte[] ShuffleBytes(byte[] UnencryptedData)
        {
            InitializeDictionaries();
            UInt32 PID = BitConverter.ToUInt32(UnencryptedData, 0);
            UInt16 UnShuffleIndex = (UInt16)(((PID >> 0xd) & 0x1f) % 24);
            string ShuffleOrder = dpPKMShuffle[UnShuffleIndex];

            byte[] Block1 = new byte[32];
            byte[] Block2 = new byte[32];
            byte[] Block3 = new byte[32];
            byte[] Block4 = new byte[32];

            switch (ShuffleOrder.Substring(0, 1))
            {
                case "A":
                    for (int i = 0x8; i <= 0x27; i++)
                    {
                        Block1[i - 0x8] = UnencryptedData[i];
                    }

                    break;
                case "B":
                    for (int i = 0x28; i <= 0x47; i++)
                    {
                        Block1[i - 0x28] = UnencryptedData[i];
                    }

                    break;
                case "C":
                    for (int i = 0x48; i <= 0x67; i++)
                    {
                        Block1[i - 0x48] = UnencryptedData[i];
                    }

                    break;
                case "D":
                    for (int i = 0x68; i <= 0x87; i++)
                    {
                        Block1[i - 0x68] = UnencryptedData[i];
                    }

                    break;
            }

            switch (ShuffleOrder.Substring(1, 1))
            {
                case "A":
                    for (int i = 0x8; i <= 0x27; i++)
                    {
                        Block2[i - 0x8] = UnencryptedData[i];
                    }

                    break;
                case "B":
                    for (int i = 0x28; i <= 0x47; i++)
                    {
                        Block2[i - 0x28] = UnencryptedData[i];
                    }

                    break;
                case "C":
                    for (int i = 0x48; i <= 0x67; i++)
                    {
                        Block2[i - 0x48] = UnencryptedData[i];
                    }

                    break;
                case "D":
                    for (int i = 0x68; i <= 0x87; i++)
                    {
                        Block2[i - 0x68] = UnencryptedData[i];
                    }

                    break;
            }

            switch (ShuffleOrder.Substring(2, 1))
            {
                case "A":
                    for (int i = 0x8; i <= 0x27; i++)
                    {
                        Block3[i - 0x8] = UnencryptedData[i];
                    }

                    break;
                case "B":
                    for (int i = 0x28; i <= 0x47; i++)
                    {
                        Block3[i - 0x28] = UnencryptedData[i];
                    }

                    break;
                case "C":
                    for (int i = 0x48; i <= 0x67; i++)
                    {
                        Block3[i - 0x48] = UnencryptedData[i];
                    }

                    break;
                case "D":
                    for (int i = 0x68; i <= 0x87; i++)
                    {
                        Block3[i - 0x68] = UnencryptedData[i];
                    }

                    break;
            }

            switch (ShuffleOrder.Substring(3, 1))
            {
                case "A":
                    for (int i = 0x8; i <= 0x27; i++)
                    {
                        Block4[i - 0x8] = UnencryptedData[i];
                    }

                    break;
                case "B":
                    for (int i = 0x28; i <= 0x47; i++)
                    {
                        Block4[i - 0x28] = UnencryptedData[i];
                    }

                    break;
                case "C":
                    for (int i = 0x48; i <= 0x67; i++)
                    {
                        Block4[i - 0x48] = UnencryptedData[i];
                    }

                    break;
                case "D":
                    for (int i = 0x68; i <= 0x87; i++)
                    {
                        Block4[i - 0x68] = UnencryptedData[i];
                    }

                    break;
            }

            for (int i = 0x8; i <= 0x27; i++)
            {
                UnencryptedData[i] = Block1[i - 0x8];
            }

            for (int i = 0x28; i <= 0x47; i++)
            {
                UnencryptedData[i] = Block2[i - 0x28];
            }

            for (int i = 0x48; i <= 0x67; i++)
            {
                UnencryptedData[i] = Block3[i - 0x48];
            }

            for (int i = 0x68; i <= 0x87; i++)
            {
                UnencryptedData[i] = Block4[i - 0x68];
            }

            return UnencryptedData;
        }

        private static byte[] Decrypt_Data(byte[] Data)
        {
            UInt16 Checksum = BitConverter.ToUInt16(Data, 0x6);

            UInt16 ucheck = Checksum;
            PokePRNG prng = new PokePRNG();
            //(ucheck)
            prng.Seed = ucheck;

            for (int i = 8; i <= 135; i += 2)
            {
                ushort bef = BitConverter.ToUInt16(Data, i);
                ushort aft = (ushort)(bef ^ (prng.NextNum() >> 0x10));
                Data[i + 1] = (byte)(aft >> 0x8);
                Data[i] = (byte)(aft & 0xff);
            }

            if (Data.Length == 136) return Data;

            prng.Seed = BitConverter.ToUInt32(Data, 0);

            for (int i = 136; i <= 235; i += 2)
            {
                ushort bef = BitConverter.ToUInt16(Data, i);
                ushort aft = (ushort)(bef ^ (prng.NextNum() >> 0x10));
                Data[i + 1] = (byte)(aft >> 0x8);
                Data[i] = (byte)(aft & 0xff);
            }

            return Data;
        }

        public static byte[] DecryptPokemon(byte[] PKM)
        {
            return UnShuffleBytes(Decrypt_Data(PKM));
        }

        private static string DecToBin(long DeciValue, int NoOfBits)
        {
            string functionReturnValue = Convert.ToString(DeciValue, 2).PadLeft(NoOfBits, '0');
            //int i = 0;
            ////make sure there are enough bits to contain the number
            //while (DeciValue > (Math.Pow(2, NoOfBits)) - 1)
            //{
            //    NoOfBits = NoOfBits + 8;
            //}
            //functionReturnValue = null;
            ////build the string
            //for (i = 0; i <= (NoOfBits - 1); i++)
            //{
            //    double tmp = Math.Pow(2, i);
            //    functionReturnValue = ((DeciValue & tmp) / tmp).ToString() + functionReturnValue;
            //}
            return functionReturnValue;
        }

        private static byte[] UnShuffleBytes(byte[] UnencryptedData)
        {
            InitializeDictionaries();
            UInt32 PID = BitConverter.ToUInt32(UnencryptedData, 0);
            UInt16 UnShuffleIndex = (UInt16)(((PID >> 0xd) & 0x1f) % 24);
            string ShuffleOrder = dpPKMShuffle[UnShuffleIndex];

            byte[] Block1 = new byte[32];
            byte[] Block2 = new byte[32];
            byte[] Block3 = new byte[32];
            byte[] Block4 = new byte[32];

            switch (ShuffleOrder.Substring(0, 1))
            {
                case "A":
                    for (int i = 0x8; i <= 0x27; i++)
                    {
                        Block1[i - 0x8] = UnencryptedData[i];
                    }

                    break;
                case "B":
                    for (int i = 0x8; i <= 0x27; i++)
                    {
                        Block2[i - 0x8] = UnencryptedData[i];
                    }

                    break;
                case "C":
                    for (int i = 0x8; i <= 0x27; i++)
                    {
                        Block3[i - 0x8] = UnencryptedData[i];
                    }

                    break;
                case "D":
                    for (int i = 0x8; i <= 0x27; i++)
                    {
                        Block4[i - 0x8] = UnencryptedData[i];
                    }

                    break;
            }

            switch (ShuffleOrder.Substring(1, 1))
            {
                case "A":
                    for (int i = 0x28; i <= 0x47; i++)
                    {
                        Block1[i - 0x28] = UnencryptedData[i];
                    }

                    break;
                case "B":
                    for (int i = 0x28; i <= 0x47; i++)
                    {
                        Block2[i - 0x28] = UnencryptedData[i];
                    }

                    break;
                case "C":
                    for (int i = 0x28; i <= 0x47; i++)
                    {
                        Block3[i - 0x28] = UnencryptedData[i];
                    }

                    break;
                case "D":
                    for (int i = 0x28; i <= 0x47; i++)
                    {
                        Block4[i - 0x28] = UnencryptedData[i];
                    }

                    break;
            }

            switch (ShuffleOrder.Substring(2, 1))
            {
                case "A":
                    for (int i = 0x48; i <= 0x67; i++)
                    {
                        Block1[i - 0x48] = UnencryptedData[i];
                    }

                    break;
                case "B":
                    for (int i = 0x48; i <= 0x67; i++)
                    {
                        Block2[i - 0x48] = UnencryptedData[i];
                    }

                    break;
                case "C":
                    for (int i = 0x48; i <= 0x67; i++)
                    {
                        Block3[i - 0x48] = UnencryptedData[i];
                    }

                    break;
                case "D":
                    for (int i = 0x48; i <= 0x67; i++)
                    {
                        Block4[i - 0x48] = UnencryptedData[i];
                    }

                    break;
            }

            switch (ShuffleOrder.Substring(3, 1))
            {
                case "A":
                    for (int i = 0x68; i <= 0x87; i++)
                    {
                        Block1[i - 0x68] = UnencryptedData[i];
                    }

                    break;
                case "B":
                    for (int i = 0x68; i <= 0x87; i++)
                    {
                        Block2[i - 0x68] = UnencryptedData[i];
                    }

                    break;
                case "C":
                    for (int i = 0x68; i <= 0x87; i++)
                    {
                        Block3[i - 0x68] = UnencryptedData[i];
                    }

                    break;
                case "D":
                    for (int i = 0x68; i <= 0x87; i++)
                    {
                        Block4[i - 0x68] = UnencryptedData[i];
                    }

                    break;
            }

            for (int i = 0x8; i <= 0x27; i++)
            {
                UnencryptedData[i] = Block1[i - 0x8];
            }

            for (int i = 0x28; i <= 0x47; i++)
            {
                UnencryptedData[i] = Block2[i - 0x28];
            }

            for (int i = 0x48; i <= 0x67; i++)
            {
                UnencryptedData[i] = Block3[i - 0x48];
            }

            for (int i = 0x68; i <= 0x87; i++)
            {
                UnencryptedData[i] = Block4[i - 0x68];
            }

            return UnencryptedData;
        }

    }

    public class PokePRNG
    {

        public PokePRNG()
        {
            m_seed = 0u;
        }

        public PokePRNG(UInt32 _SEED)
        {
            m_seed = _SEED;
        }

        private UInt32 m_seed;

        public UInt32 Seed
        {
            get { return m_seed; }
            set { m_seed = value; }
        }

        public UInt32 Previous()
        {
            return 0xeeb9eb65 * m_seed + 0xa3561a1;
        }

        public UInt32 PreviousNum()
        {
            m_seed = Previous();
            return m_seed;
        }

        public UInt32 Next()
        {
            return (0x41c64e6d * m_seed) + 0x6073;
        }

        public UInt32 NextNum()
        {
            m_seed = Next();
            return m_seed;
        }

    }

    public class GTS_PRNG
    {

        public GTS_PRNG()
        {
            m_seed = 0u;
        }

        public GTS_PRNG(UInt32 _SEED)
        {
            m_seed = _SEED | (_SEED << 16);
        }

        private UInt32 m_seed;

        public UInt32 Seed
        {
            get { return m_seed; }
            set { m_seed = value; }
        }

        public UInt32 Next()
        {
            return (m_seed * 0x45 + 0x1111) & 0x7fffffff;
        }

        public UInt32 NextNum()
        {
            m_seed = Next();
            return (m_seed >> 16) & 0xff;
        }

    }

}
