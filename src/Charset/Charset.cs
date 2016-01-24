//  Author:
//       Teeknofil <teeknofil@gmail.com>
//
//  Copyright (c) 2015 Teeknofil
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace crisis
{
    public static class Charset
    {
        private static List<string> charsetSelecting = new List<string>();

        public static List<string> CharsetSelecting
        {
            get { return charsetSelecting; }
            set { charsetSelecting = value; }
        }

        private static string charsetName;

        public static string CharsetName
        {
            get
            {
                return charsetName;
            }
            set
            {
                charsetName = value;
            }
        }

        private static bool booleanType = true;

        public static bool BooleanType
        {
            get
            {
                return booleanType;
            }
            set
            {
                booleanType = value;
            }
        }

        private static List<string> space           = new List<string>() { " " };
        private static List<string> sfr_fr          = new List<string>() { "-", "_" };
        private static List<string> livebox_sagem   = new List<string>() { "1","2","3","4","6","7","9","A","C","D","E","F" };

        private static List<string> numeric     = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private static List<string> hex_lower   = new List<string>() { "a", "b", "c", "d", "e", "f" };
        private static List<string> hex_upper   = new List<string>() { "A", "B", "C", "D", "E", "F" };
        private static List<string> symbols14   = new List<string>() { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=" };
        private static List<string> symbols_all = new List<string>() { "~", "`", "[", "]", "{", "}", "|", "\\", ":", ";", "\"", "<", ">", ",", ".", "?", "/" };
        private static List<string> ualpha      = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private static List<string> lalpha      = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        private static List<string> ualpha_sv   = new List<string>() { "Å", "Ä", "Ö" };
        private static List<string> lalpha_sv   = new List<string>() { "å", "ä", "ö" };
        private static List<string> syllable_fr = new List<string>() { "ac", "ach", "ad", "af", "ag", "ail", "ain", "aition", "aj", "ak", "al", "am", "anc", "anch", "and", "anf", "ang", "anj", "anl", "anph", "anr", "ans", "ant", "antion", "anv", "ap", "aph", "ar", "as", "at", "ation", "aub", "auc", "auch", "aud", "auf", "aug", "auj", "auk", "aul", "aum", "aun", "aup", "auph", "aur", "aus", "aution", "av", "bac", "bai", "bain", "bam", "ban", "bao", "bau", "baut", "be", "bé", "bè", "bê", "beau", "béi", "bein", "bès", "bet", "béu", "bèv", "bez", "bi", "bid", "bien", "big", "bin", "bion", "bla", "blé", "bli", "blo", "blon", "blu", "bo", "boeu", "boi", "boig", "boin", "boj", "bon", "bonk", "bop", "bou", "bra", "bré", "brè", "bri", "bro", "bron", "bru", "bru", "buf", "bup", "ca", "ça", "cad", "cae", "cai", "cain", "çain", "cam", "çan", "cau", "çau", "cauz", "ce", "cé", "cè", "cê", "ceau", "cei", "cein", "cem", "cen", "cer", "cet", "ceu", "cez", "cha", "chab", "chai", "chain", "cham", "chan", "chau", "chaul", "che", "ché", "chè", "chê", "chéa", "cheau", "chei", "chein", "chèk", "chem", "chen", "cheo", "cher", "chet", "cheu", "chez", "chi", "chien", "chig", "chin", "cho", "choeu", "chof", "choi", "choic", "choin", "chon", "chonc", "chou", "chouj", "chu", "chud", "chun", "ci", "cien", "cion", "clé", "clè", "clo", "clon", "clou", "clu", "co", "ço", "cod", "coi", "çoi", "coin", "çoin", "çon", "cos", "coub", "coul", "cra", "cran", "cré", "crè", "cri", "cron", "crou", "cru", "cui", "cun", "çun", "cup", "dab", "dai", "dain", "dal", "dam", "dan", "dau", "dauj", "daz", "de", "dé", "dè", "dê", "dea", "dèa", "deau", "deg", "dei", "dein", "déj", "dem", "den", "déo", "der", "det", "deu", "dév", "dez", "dia", "dien", "dil", "dion", "do", "doi", "doin", "doj", "don", "dong", "dou", "douf", "dra", "dran", "drau", "dre", "dré", "drè", "dri", "dro", "dron", "dru", "dun", "dur", "dut", "eb", "ec", "éc", "ed", "éd", "èd", "éf", "èf", "eg", "èg", "eil", "eition", "éj", "èj", "ek", "ék", "él", "èl", "ém", "ention", "ep", "èp", "er", "ér", "ér", "èr", "és", "és", "ès", "èt", "etion", "étion", "ètion", "euil", "eution", "év", "év", "fai", "fain", "fam", "fan", "fat", "fau", "faui", "fe", "fé", "fè", "fê", "féa", "feau", "fei", "fein", "fem", "fenv", "féo", "fer", "fet", "fèt", "fez", "fia", "fic", "fien", "fla", "fla", "flau", "flé", "fli", "flo", "flo", "flon", "flu", "fo", "foeu", "foin", "fons", "fop", "four", "fré", "fré", "frè", "fren", "fri", "fro", "fron", "ful", "fun", "fur", "fuz", "ga", "gab", "gai", "gain", "gam", "gan", "gau", "ge", "gé", "gè", "gê", "gen", "geou", "geu", "gi", "gin", "gla", "glau", "gle", "glé", "glè", "gli", "glo", "gloi", "glon", "glou", "glu", "gna", "gnain", "gnan", "gnau", "gne", "gné", "gnè", "gnê", "gneau", "gnei", "gnein", "gnen", "gner", "gnet", "gneu", "gnez", "gni", "gnien", "gnin", "gno", "gnoeu", "gnoi", "gnoin", "gnon", "gnou", "gnu", "gnun", "go", "goa", "goin", "goit", "gond", "gou", "goud", "gra", "gran", "grau", "gre", "gré", "grè", "gri", "gro", "groi", "groi", "gron", "grou", "gru", "gu", "gub", "gue", "gué", "guè", "guê", "guein", "guéj", "guep", "guèp", "guer", "guet", "gueu", "gui", "guic", "guion", "hau", "hè", "hê", "heau", "hou", "id", "if", "ig", "il", "im", "in", "intion", "ip", "iph", "ir", "is", "it", "ition", "iton", "iv", "ja", "jab", "jai", "jam", "jan", "jau", "jaup", "jauv", "je", "jé", "jè", "jê", "jeau", "jeb", "jéf", "jei", "jein", "jem", "jer", "jès", "jet", "jeu", "jez", "ji", "jic", "jien", "jin", "jion", "jo", "joeu", "joi", "join", "jol", "jon", "jonf", "jou", "joua", "ju", "jud", "jun", "ka", "kad", "kai", "kain", "kam", "kan", "kau", "kaun", "ke", "ké", "kè", "kê", "kéa", "keau", "keg", "kei", "kein", "kem", "ken", "ker", "ket", "keu", "kez", "ki", "kien", "kim", "kin", "kion", "kla", "klau", "kle", "klé", "kli", "klo", "klu", "ko", "koeu", "koi", "koin", "kor", "kou", "koul", "kra", "krau", "kre", "kri", "kro", "kru", "ku", "kun", "kuo", "la", "lab", "lab", "lag", "lai", "lain", "lam", "lan", "lans", "lap", "lau", "lé", "lè", "lê", "léa", "leau", "lei", "léi", "lein", "lem", "len", "ler", "lèr", "let", "leu", "lez", "léz", "lic", "lien", "lin", "lion", "lir", "lo", "loa", "lod", "loeu", "loi", "loij", "loin", "lon", "lor", "lou", "lud", "lué", "lun", "lut", "luz", "mab", "mai", "main", "man", "mao", "mau", "mauc", "mé", "mè", "mê", "méa", "meau", "mei", "mein", "méj", "mem", "mèo", "mer", "met", "meu", "méu", "mez", "mia", "mien", "mij", "min", "mion", "mit", "miu", "mod", "moeu", "moi", "moin", "moiv", "mon", "mos", "mou", "mov", "mu", "muf", "muj", "mun", "mup", "na", "nab", "nai", "nain", "nam", "nan", "nau", "naup", "ne", "nè", "nê", "néa", "neau", "nei", "nein", "nem", "nen", "neo", "ner", "net", "neu", "név", "nez", "nien", "nif", "nig", "no", "noa", "noeu", "noi", "noif", "noin", "nol", "non", "nonj", "nou", "nu", "nun", "nut", "ob", "oc", "oc", "och", "oeu", "of", "og", "oib", "oic", "oich", "oid", "oif", "oig", "oij", "oik", "oil", "oim", "oip", "oit", "oition", "ok", "ol", "om", "om", "onc", "onch", "ond", "onf", "ong", "onj", "onp", "onph", "onr", "ons", "ont", "onv", "op", "oph", "or", "os", "os", "ot", "otion", "ouc", "ouch", "oud", "oug", "ouil", "ouj", "ouk", "oul", "ouph", "ous", "out", "oution", "ov", "paf", "pag", "pain", "pam", "pan", "pau", "pauf", "paz", "pe", "pé", "pè", "peau", "pei", "pein", "pem", "pen", "penk", "péo", "per", "pet", "peu", "péu", "pez", "pèz", "pha", "phab", "phai", "phain", "pham", "phan", "phau", "phaul", "phe", "phé", "phè", "phê", "phéa", "pheau", "phei", "phein", "phem", "phenj", "pher", "phet", "phèt", "pheu", "phien", "phin", "pho", "phon", "phor", "phran", "phré", "phu", "pim", "pin", "pit", "pla", "plan", "plau", "ple", "plé", "plè", "plen", "pli", "plo", "plon", "plu", "po", "poeu", "poi", "poic", "poin", "pom", "pon", "pop", "pos", "pou", "pouc", "pra", "pran", "pre", "pré", "pré", "prè", "pren", "pri", "pri", "pro", "pru", "pru", "pu", "puc", "pun", "pur", "qeue", "qua", "quai", "quain", "quan", "quau", "que", "qué", "què", "quê", "queau", "quei", "quein", "quer", "quet", "quez", "qui", "quien", "quin", "quo", "quoi", "quoin", "quou", "rab", "raf", "rai", "ram", "ran", "rau", "raub", "rav", "ré", "rè", "rê", "reau", "rég", "rei", "rein", "rèj", "rem", "renc", "rer", "ret", "reu", "réu", "rev", "rez", "rien", "rij", "rin", "rio", "rion", "roeu", "roin", "rois", "rok", "ron", "ros", "rou", "rov", "rua", "ruc", "rui", "rul", "run", "sa", "sab", "sai", "sain", "sam", "san", "sand", "sao", "sau", "sauc", "se", "sé", "sê", "seau", "sei", "séi", "sèi", "sein", "sem", "sen", "ser", "set", "seu", "sév", "sez", "si", "sic", "sien", "sin", "sion", "siz", "so", "soa", "sod", "soeu", "soi", "soif", "soin", "soiz", "son", "sonr", "sou", "sou", "soug", "su", "suf", "sum", "sun", "tad", "tai", "tain", "tan", "tau", "te", "té", "tei", "tem", "ter", "tez", "tib", "tien", "tif", "tin", "to", "tob", "tod", "ton", "top", "tou", "tra", "trau", "tre", "tré", "tren", "tri", "tro", "tron", "tru", "tru", "tud", "tug", "tui", "tun", "uc", "uch", "ud", "uf", "ug", "uj", "uk", "ul", "um", "untion", "up", "uph", "ur", "us", "ut", "ution", "uv", "vain", "vam", "vauk", "vè", "véa", "vein", "vén", "vet", "veu", "vin", "vion", "vir", "vlan", "vlon", "vo", "voeu", "voi", "voin", "voiz", "voj", "von", "vonl", "vop", "vou", "voz", "vra", "vra", "vrau", "vre", "vré", "vrè", "vri", "vro", "vron", "vrou", "vru", "vu", "vum", "vun", "vus", "vut", "xa", "xain", "xan", "xau", "xe", "xé", "xè", "xeau", "xez", "xi", "xin", "xo", "xoeu", "xoi", "xon", "xu", "za", "zain", "zan", "ze", "zé", "zeau", "zein", "zeu", "zi", "zien", "zin" };
        private static List<string> cyrillic = new List<string>() { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м,", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
        

        public static List<string> ReadFileTxt()
        {
            if (File.Exists(charsetName.ToString()))
            {
                try
                {
                    charsetSelecting.Add(System.IO.File.ReadAllText(CharsetName.ToString()));
                    booleanType = false;
                    MainMenu.BooleanCategoryMenu = false;
                    Parameter.TypesOfGeneration = 8;
                }
                catch (OutOfMemoryException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n The file is too large to be stored in RAM !");
                    Console.WriteLine(" {0} \n", e.Message);
                    Console.ResetColor();
                    Parameter.TypesOfGeneration = 0;
                }               
                
            }
            else
            {
                booleanType = true;
                MainMenu.BooleanCategoryMenu = true;
                Parameter.TypesOfGeneration = 0;
            }
            return charsetSelecting;
        }

        public static List<string> WifiCharset()
        {
            if (charsetName == "sfr")
            {
                charsetSelecting = sfr_fr.Concat(numeric).Concat(ualpha).Concat(lalpha).ToList();
                booleanType = false;
                SubMenu.BooleanSubMenu = false;
                MainMenu.BooleanCategoryMenu = false;
                Parameter.NumberOfChar = 20;
            }
            else if (charsetName == "livebox-sagem")
            {
                charsetSelecting = livebox_sagem.ToList();
                booleanType = false;
                SubMenu.BooleanSubMenu = false;
                MainMenu.BooleanCategoryMenu = false;
                Parameter.NumberOfChar = 26;
            }
            else
            {
                booleanType = true;
            }

            return charsetSelecting;
        }        

        public static List<string> Hexa()
        {
            if (charsetName == "hex-lower")
            {
                //hex-lower
                charsetSelecting = numeric.Concat(hex_lower).ToList();
                booleanType = false;
            }
            else if (charsetName == "hex-upper")
            {
                //hex-upper 
                charsetSelecting = numeric.Concat(hex_upper).ToList();
                booleanType = false;
            }
            else
            {
                booleanType = true;
            }
            
            return charsetSelecting;
        }

        public static List<string> Numeric()
        {
            if (charsetName == "numeric")
            {
                //numeric
                charsetSelecting = numeric;
                booleanType = false;
            }
            else if (charsetName == "numeric-space")
            {
                //numeric-space
                CharsetSelecting = numeric.Concat(space).ToList();
                booleanType = false;
            }
            else
            {
                booleanType = true;
            }
            
            return charsetSelecting;
        }

        

        public static List<string> Symbols()
        {
            if (charsetName == "symbols14")
            {
                //symbols14  
                charsetSelecting = symbols14;
                booleanType = false;
            }
            else if (charsetName == "symbols14-space")
            {
                //symbols14-space
                charsetSelecting = symbols14.Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "symbols-all")
            {
                //symbols-all
                charsetSelecting = symbols14.Concat(symbols_all).ToList();
                booleanType = false;
            }
            else if (charsetName == "symbols-all-space")
            {
                //symbols-all-space
                charsetSelecting = symbols14.Concat(symbols_all).Concat(space).ToList();
                booleanType = false;
            }
            else
            {
                booleanType = true;
            }
            
            return charsetSelecting;
        }

        public static List<string> Lalpha()
        {
            if (charsetName == "lalpha")
            {
                //lalpha
                charsetSelecting = lalpha.ToList();
                booleanType = false;
            }
            else if (charsetName == "lalpha-space")
            {
                // lalpha_space
                charsetSelecting = lalpha.Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "lalpha-numeric")
            {
                // lalpha-numeric
                charsetSelecting = lalpha.Concat(numeric).ToList();
                booleanType = false;
            }
            else if (charsetName == "lalpha-numeric-space")
            {
                // lalpha-numeric-space
                charsetSelecting = lalpha.Concat(numeric).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "lalpha-numeric-symbol14")
            {
                //lalpha-numeric-symbol14
                charsetSelecting = lalpha.Concat(numeric).Concat(symbols14).ToList();
                booleanType = false;
            }
            else if (charsetName == "lalpha-numeric-symbol14-space")
            {
                // lalpha-numeric-symbol14-space
                charsetSelecting = lalpha.Concat(numeric).Concat(symbols14).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "lalpha-numeric-all")
            {
                //lalpha-numeric-all
                charsetSelecting = lalpha.Concat(numeric).Concat(symbols14).Concat(symbols_all).ToList();
                booleanType = false;
            }
            else if (charsetName == "lalpha-numeric-all-space")
            {
                //lalpha-numeric-all-space
                charsetSelecting = lalpha.Concat(numeric).Concat(symbols14).Concat(symbols_all).Concat(space).ToList();
                booleanType = false;
            }
            else
            {
                booleanType = true;
            }

            return charsetSelecting;
        }

        

        public static List<string> Ualpha()
        {
            if (charsetName == "ualpha")
            {
                //ualpha
                charsetSelecting = ualpha;
                booleanType = false;
            }
            else if (charsetName == "ualpha-space")
            {
                //ualpha-space
                charsetSelecting = ualpha.Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "ualpha-numeric")
            {
                //ualpha-numeric
                charsetSelecting = ualpha.Concat(numeric).ToList();
                booleanType = false;
            }
            else if (charsetName == "ualpha-numeric-space")
            {
                //ualpha_numeric_space
                charsetSelecting = ualpha.Concat(numeric).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "ualpha-numeric-symbol14")
            {
                // ualpha_numeric_symbol14
                charsetSelecting = ualpha.Concat(numeric).Concat(symbols14).ToList();
                booleanType = false;
            }
            else if (charsetName == "ualpha-numeric-symbol14-space")
            {
                //ualpha_numeric-symbol14-space
                charsetSelecting = ualpha.Concat(numeric).Concat(symbols14).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "ualpha-numeric-all")
            {
                //ualpha-numeric-all
                charsetSelecting = ualpha.Concat(numeric).Concat(symbols14).Concat(symbols_all).ToList();
                booleanType = false;
            }
            else if (charsetName == "ualpha-numeric-all-space")
            {
                //ualpha-numeric-all-space
                charsetSelecting = ualpha.Concat(numeric).Concat(symbols14).Concat(symbols_all).Concat(space).ToList();
                booleanType = false;
            }
            else
            {
                booleanType = true;
            }
            
            return charsetSelecting;
        }

        
        public static List<string> MixAlpha()
        {


            if (charsetName == "mixalpha")
            {
                //mixalpha
                charsetSelecting = lalpha.Concat(ualpha).ToList();
                booleanType = false;
            }
            else if (charsetName == "mixalpha-space")
            {
                //mixalpha-space
                charsetSelecting = lalpha.Concat(ualpha).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "mixalpha-numeric")
            {
                //mixalpha-numeric
                charsetSelecting = lalpha.Concat(ualpha).Concat(numeric).ToList();
                booleanType = false;

            }
            else if (charsetName == "mixalpha-numeric-space")
            {
                //mixalpha-numeric-space
                charsetSelecting = lalpha.Concat(ualpha).Concat(numeric).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "mixalpha-numeric-symbol14")
            {
                //mixalpha-numeric-symbol14
                charsetSelecting = lalpha.Concat(ualpha).Concat(numeric).Concat(symbols14).ToList();
                booleanType = false;

            }
            else if (charsetName == "mixalpha-numeric-symbol14-space")
            {
                //mixalpha-numeric-symbol14-space
                charsetSelecting = lalpha.Concat(ualpha).Concat(numeric).Concat(symbols14).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "mixalpha-numeric-all")
            {
                // mixalpha-numeric-all
                charsetSelecting = lalpha.Concat(ualpha).Concat(numeric).Concat(symbols14).Concat(symbols_all).ToList();
                booleanType = false;

            }
            else if (charsetName == "mixalpha-numeric-all-space")
            {
                // mixalpha-numeric-all-space
                charsetSelecting = lalpha.Concat(ualpha).Concat(numeric).Concat(symbols14).Concat(symbols_all).Concat(space).ToList();
                booleanType = false;

            }
            else
            {
                booleanType = true;
            }

            
            return charsetSelecting;
        }


        public static List<string> Lcyrillic()
        {
            if (charsetName == "lcyrillic")
            {
                //lcyrillic
                charsetSelecting = cyrillic.ToList();
                ;
                booleanType = false;
            }
            else if (charsetName == "lcyrillic-space")
            {
                // lcyrillic-space
                charsetSelecting = cyrillic.Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "lcyrillic-numeric")
            {
                // lcyrillic-numeric
                charsetSelecting = cyrillic.Concat(numeric).ToList();
                booleanType = false;
            }
            else if (charsetName == "lcyrillic-numeric-space")
            {
                // lcyrillic-numeric-space
                charsetSelecting = cyrillic.Concat(numeric).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "lcyrillic-numeric-symbol14")
            {
                //lcyrillic-numeric-symbol14
                charsetSelecting = cyrillic.Concat(numeric).Concat(symbols14).ToList();
                booleanType = false;
            }
            else if (charsetName == "lcyrillic-numeric-symbol14-space")
            {
                // lcyrillic-numeric-symbol14-space
                charsetSelecting = cyrillic.Concat(numeric).Concat(symbols14).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "lcyrillic-numeric-all")
            {
                //lcyrillic-numeric-all
                charsetSelecting = cyrillic.Concat(numeric).Concat(symbols14).Concat(symbols_all).ToList();
                booleanType = false;
            }
            else if (charsetName == "lcyrillic-numeric-all-space")
            {
                //lcyrillic-numeric-all-space
                charsetSelecting = cyrillic.Concat(numeric).Concat(symbols14).Concat(symbols_all).Concat(space).ToList();
                booleanType = false;
            }
            else
            {
                booleanType = true;
            }

            return charsetSelecting;
        }

        public static List<string> Ucyrillic()
        {
            if (charsetName == "ucyrillic")
            {
                //ucyrillique
                charsetSelecting = cyrillic.ConvertAll(item => item.ToUpper()).ToList();
                booleanType = false;
            }
            else if (charsetName == "ucyrillic-space")
            {
                //uacyrillique-space
                charsetSelecting = cyrillic.ConvertAll(item => item.ToUpper()).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "ucyrillic-numeric")
            {
                //ucyrillique-numeric
                charsetSelecting = cyrillic.ConvertAll(item => item.ToUpper()).Concat(numeric).ToList();
                booleanType = false;
            }
            else if (charsetName == "ucyrillic-numeric-space")
            {
                //ucyrillique_numeric_space
                charsetSelecting = cyrillic.ConvertAll(item => item.ToUpper()).Concat(numeric).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "ucyrillic-numeric-symbol14")
            {
                // ucyrillique_numeric_symbol14
                charsetSelecting = cyrillic.ConvertAll(item => item.ToUpper()).Concat(numeric).Concat(symbols14).ToList();
                booleanType = false;
            }
            else if (charsetName == "ucyrillic-numeric-symbol14-space")
            {
                //ucyrillique_numeric-symbol14-space
                charsetSelecting = cyrillic.ConvertAll(item => item.ToUpper()).Concat(numeric).Concat(symbols14).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "ucyrillic-numeric-all")
            {
                //ucyrillique-numeric-all
                charsetSelecting = cyrillic.ConvertAll(item => item.ToUpper()).Concat(numeric).Concat(symbols14).Concat(symbols_all).ToList();
                booleanType = false;
            }
            else if (charsetName == "ucyrillic-numeric-all-space")
            {
                //ucyrillique-numeric-all-space
                charsetSelecting = cyrillic.ConvertAll(item => item.ToUpper()).Concat(numeric).Concat(symbols14).Concat(symbols_all).Concat(space).ToList();
                booleanType = false;
            }
            else
            {
                booleanType = true;
            }

            return charsetSelecting;
        }

        public static List<string> MixCyrillic()
        {


            if (charsetName == "mixcyrillic")
            {
                //mixcyrillic
                charsetSelecting = cyrillic.Concat(cyrillic.ConvertAll(item => item.ToUpper())).ToList();
                booleanType = false;
            }
            else if (charsetName == "mixcyrillic-space")
            {
                //mixcyrillic-space
                charsetSelecting = cyrillic.Concat(cyrillic.ConvertAll(item => item.ToUpper())).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "mixcyrillic-numeric")
            {
                //mixcyrillic-numeric
                charsetSelecting = cyrillic.Concat(cyrillic.ConvertAll(item => item.ToUpper())).Concat(numeric).ToList();
                booleanType = false;

            }
            else if (charsetName == "mixcyrillic-numeric-space")
            {
                //mixcyrillic-numeric-space
                charsetSelecting = cyrillic.Concat(cyrillic.ConvertAll(item => item.ToUpper())).Concat(numeric).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "mixcyrillic-numeric-symbol14")
            {
                //mixcyrillic-numeric-symbol14
                charsetSelecting = cyrillic.Concat(cyrillic.ConvertAll(item => item.ToUpper())).Concat(numeric).Concat(symbols14).ToList();
                booleanType = false;

            }
            else if (charsetName == "mixcyrillic-numeric-symbol14-space")
            {
                //mixcyrillic-numeric-symbol14-space
                charsetSelecting = cyrillic.Concat(cyrillic.ConvertAll(item => item.ToUpper())).Concat(numeric).Concat(symbols14).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "mixcyrillic-numeric-all")
            {
                // mixcyrillic-numeric-all
                charsetSelecting = cyrillic.Concat(cyrillic.ConvertAll(item => item.ToUpper())).Concat(numeric).Concat(symbols14).Concat(symbols_all).ToList();
                booleanType = false;

            }
            else if (charsetName == "mixcyrillic-numeric-all-space")
            {
                // mixcyrillic-numeric-all-space
                charsetSelecting = cyrillic.Concat(cyrillic.ConvertAll(item => item.ToUpper())).Concat(numeric).Concat(symbols14).Concat(symbols_all).Concat(space).ToList();
                booleanType = false;

            }
            else
            {
                booleanType = true;
            }


            return charsetSelecting;
        }


        public static List<string> Lalpha_sv()
        {

            if (charsetName == "sv-lalpha")
            {
                //lalpha-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-lalpha-space")
            {
                //lalpha-space-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "sv-lalpha-numeric")
            {
                //lalpha-numeric-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(numeric).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-lalpha-numeric-space")
            {
                //lalpha-numeric-space-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(numeric).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-lalpha-numeric-symbol14")
            {

                //lalpha-numeric-symbol14-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(numeric).Concat(symbols14).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-lalpha-numeric-symbol14-space")
            {

                // lalpha-numeric-symbol14-space-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(numeric).Concat(symbols14).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-lalpha-numeric-all")
            {
                // lalpha-numeric-all-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(numeric).Concat(symbols14).Concat(symbols_all).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-lalpha-numeric-all-space")
            {
                //lalpha-numeric-all-space-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(numeric).Concat(symbols14).Concat(symbols_all).Concat(space).ToList();                    //charsetSelecting.Add("a"); charsetSelecting.Add("b"); charsetSelecting.Add("c"); charsetSelecting.Add("d"); charsetSelecting.Add("e"); charsetSelecting.Add("f"); charsetSelecting.Add("g"); charsetSelecting.Add("h"); charsetSelecting.Add("i"); charsetSelecting.Add("indexEnuCharset"); charsetSelecting.Add("k"); charsetSelecting.Add("l"); charsetSelecting.Add("m"); charsetSelecting.Add("n"); charsetSelecting.Add("o"); charsetSelecting.Add("p"); charsetSelecting.Add("q"); charsetSelecting.Add("r"); charsetSelecting.Add("s"); charsetSelecting.Add("t"); charsetSelecting.Add("u"); charsetSelecting.Add("v"); charsetSelecting.Add("w"); charsetSelecting.Add("x"); charsetSelecting.Add("y"); charsetSelecting.Add("z"); charsetSelecting.Add("å"); charsetSelecting.Add("ä"); charsetSelecting.Add("ö"); charsetSelecting.Add("0"); charsetSelecting.Add("1"); charsetSelecting.Add("2"); charsetSelecting.Add("3"); charsetSelecting.Add("4"); charsetSelecting.Add("5"); charsetSelecting.Add("6"); charsetSelecting.Add("7"); charsetSelecting.Add("8"); charsetSelecting.Add("9"); charsetSelecting.Add("!"); charsetSelecting.Add("@"); charsetSelecting.Add("#"); charsetSelecting.Add("$"); charsetSelecting.Add("%"); charsetSelecting.Add("^"); charsetSelecting.Add("&"); charsetSelecting.Add("*"); charsetSelecting.Add("("); charsetSelecting.Add(")"); charsetSelecting.Add("-"); charsetSelecting.Add("_"); charsetSelecting.Add("+"); charsetSelecting.Add("="); charsetSelecting.Add("!"); charsetSelecting.Add("@"); charsetSelecting.Add("#"); charsetSelecting.Add("$"); charsetSelecting.Add("%"); charsetSelecting.Add("^"); charsetSelecting.Add("&"); charsetSelecting.Add("*"); charsetSelecting.Add("("); charsetSelecting.Add(")"); charsetSelecting.Add("-"); charsetSelecting.Add("_"); charsetSelecting.Add("+"); charsetSelecting.Add("="); charsetSelecting.Add("~"); charsetSelecting.Add("`"); charsetSelecting.Add("["); charsetSelecting.Add("]"); charsetSelecting.Add("{"); charsetSelecting.Add("}"); charsetSelecting.Add("|"); charsetSelecting.Add("\\"); charsetSelecting.Add(":"); charsetSelecting.Add(";"); charsetSelecting.Add("\""); charsetSelecting.Add("'"); charsetSelecting.Add("<"); charsetSelecting.Add(">"); charsetSelecting.Add(","); charsetSelecting.Add("."); charsetSelecting.Add("?"); charsetSelecting.Add("/"); charsetSelecting.Add(" ");
                booleanType = false;

            }
            else
            {
                booleanType = true;
            }
            
            return charsetSelecting;
        }

        public static List<string> Ualpha_sv()
        {

            if (charsetName == "sv-ualpha")
            {
                //ualpha-sv
                charsetSelecting = ualpha.Concat(ualpha_sv).ToList();
                booleanType = false;
            }
            else if (charsetName == "sv-ualpha-space")
            {
                //ualpha-space-sv
                charsetSelecting = ualpha.Concat(ualpha_sv).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-ualpha-numeric")
            {
                //ualpha-numeric-sv
                charsetSelecting = ualpha.Concat(ualpha_sv).Concat(numeric).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-ualpha-numeric-space")
            {
                //ualpha-numeric-space-sv
                charsetSelecting = ualpha.Concat(ualpha_sv).Concat(numeric).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-ualpha-numeric-symbol14")
            {
                //ualpha-numeric-symbol14-sv
                charsetSelecting = ualpha.Concat(ualpha_sv).Concat(numeric).Concat(symbols14).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-ualpha-numeric-symbol14-space")
            {
                //ualpha-numeric-symbol14-space-sv
                charsetSelecting = ualpha.Concat(ualpha_sv).Concat(numeric).Concat(symbols14).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-ualpha-numeric-all")
            {
                //ualpha-numeric-all-sv
                charsetSelecting = ualpha.Concat(ualpha_sv).Concat(numeric).Concat(symbols14).Concat(symbols_all).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-ualpha-numeric-all-space")
            {
                //ualpha-numeric-all-space-sv
                charsetSelecting = ualpha.Concat(ualpha_sv).Concat(numeric).Concat(symbols14).Concat(symbols_all).Concat(space).ToList();
                booleanType = false;

            }
            else
            {
                booleanType = true;
            }

            
            return charsetSelecting;
        }

        

        public static List<string> MixAlpha_sv()
        {

            if (charsetName == "sv-mixalpha")
            {
                //mixalpha-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(ualpha).Concat(ualpha_sv).ToList();
                booleanType = false;
            }
            else if (charsetName == "sv-mixalpha-space")
            {
                //mixalpha-space-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(ualpha).Concat(ualpha_sv).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-mixalpha-numeric")
            {
                // mixalpha-numeric-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(ualpha).Concat(ualpha_sv).Concat(numeric).ToList();
                booleanType = false;
            }
            else if (charsetName == "sv-mixalpha-numeric-space")
            {
                //mixalpha-numeric-space_sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(ualpha).Concat(ualpha_sv).Concat(numeric).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-mixalpha-numeric-symbol14")
            {
                //mixalpha-numeric-symbol14-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(ualpha).Concat(ualpha_sv).Concat(numeric).Concat(symbols14).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-mixalpha-numeric-symbol14-space")
            {
                //mixalpha-numeric-symbol14-space-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(ualpha).Concat(ualpha_sv).Concat(numeric).Concat(symbols14).Concat(space).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-mixalpha-numeric-all")
            {
                //mixalpha-numeric-all-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(ualpha).Concat(ualpha_sv).Concat(numeric).Concat(symbols14).Concat(symbols_all).ToList();
                booleanType = false;

            }
            else if (charsetName == "sv-mixalpha-numeric-all-space")
            {
                //mixalpha-numeric-all-space-sv
                charsetSelecting = lalpha.Concat(lalpha_sv).Concat(ualpha).Concat(ualpha_sv).Concat(numeric).Concat(symbols14).Concat(symbols_all).Concat(space).ToList();
                booleanType = false;

            }
            else
            {
                booleanType = true;
            }

            
            return charsetSelecting;

        }

        public static List<string> Lsyllable_fr()
        {
            if (charsetName == "lsyllable")
            {
                //syllable
                charsetSelecting = syllable_fr;
                booleanType = false;
            }
            else if (charsetName == "lsyllable-space")
            {
                // lsyllable_space
                charsetSelecting = syllable_fr.Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "lsyllable-numeric")
            {
                // lsyllable-numeric
                charsetSelecting = syllable_fr.Concat(numeric).ToList();
                booleanType = false;
            }
            else if (charsetName == "lsyllable-numeric-space")
            {
                // lsyllable-numeric-space
                charsetSelecting = syllable_fr.Concat(numeric).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "lsyllable-numeric-symbol14")
            {
                //lsyllable-numeric-symbol14
                charsetSelecting = syllable_fr.Concat(numeric).Concat(symbols14).ToList();
                booleanType = false;
            }
            else if (charsetName == "lsyllable-numeric-symbol14-space")
            {
                // lsyllable-numeric-symbol14-space
                charsetSelecting = syllable_fr.Concat(numeric).Concat(symbols14).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "lsyllable-numeric-all")
            {
                //lsyllable-numeric-all
                charsetSelecting = syllable_fr.Concat(numeric).Concat(symbols14).Concat(symbols_all).ToList();
                booleanType = false;
            }
            else if (charsetName == "lsyllable-numeric-all-space")
            {
                //lsyllable-numeric-all-space
                charsetSelecting = syllable_fr.Concat(numeric).Concat(symbols14).Concat(symbols_all).Concat(space).ToList();
                booleanType = false;
            }
            else
            {
                booleanType = true;
            }
            
            return charsetSelecting;
        }

        public static List<string> Usyllable_fr()
        {
            if (charsetName == "usyllable")
            {

                //usyllable
                charsetSelecting = syllable_fr.ConvertAll(item => item.ToUpper());
                booleanType = false;
            }
            else if (charsetName == "usyllable-space")
            {
                //usyllable-space
                charsetSelecting = syllable_fr.ConvertAll(item => item.ToUpper()).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "usyllable-numeric")
            {

                //usyllable-numeric
                charsetSelecting = syllable_fr.ConvertAll(item => item.ToUpper()).Concat(numeric).ToList();
                booleanType = false;
            }
            else if (charsetName == "usyllable-numeric-space")
            {
                //usyllable_numeric_space
                charsetSelecting = syllable_fr.ConvertAll(item => item.ToUpper()).Concat(numeric).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "usyllable-numeric-symbol14")
            {
                // usyllable_numeric_symbol14
                charsetSelecting = syllable_fr.ConvertAll(item => item.ToUpper()).Concat(numeric).Concat(symbols14).ToList();
                booleanType = false;
            }
            else if (charsetName == "usyllable-numeric-symbol14-space")
            {
                //usyllable_numeric-symbol14-space
                charsetSelecting = syllable_fr.ConvertAll(item => item.ToUpper()).Concat(numeric).Concat(symbols14).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "usyllable-numeric-all")
            {
                //usyllable-numeric-all
                charsetSelecting = syllable_fr.ConvertAll(item => item.ToUpper()).Concat(numeric).Concat(symbols14).Concat(symbols_all).ToList();
                booleanType = false;
            }
            else if (charsetName == "usyllable-numeric-all-space")
            {
                //usyllable-numeric-all-space
                charsetSelecting = syllable_fr.ConvertAll(item => item.ToUpper()).Concat(numeric).Concat(symbols14).Concat(symbols_all).Concat(space).ToList();
                booleanType = false;
            }
            else
            {
                booleanType = true;
            }
            
            return charsetSelecting;
        }

        public static List<string> mixsyllable_fr()
        {
            if (charsetName == "mixsyllable")
            {
                //syllable
                charsetSelecting = syllable_fr.Concat(syllable_fr.ConvertAll(item => item.ToUpper())).ToList();
                booleanType = false;
            }
            else if (charsetName == "mixsyllable-space")
            {
                // mixsyllable_space
                charsetSelecting = syllable_fr.Concat(syllable_fr.ConvertAll(item => item.ToUpper())).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "mixsyllable-numeric")
            {
                // mixsyllable-numeric
                charsetSelecting = syllable_fr.Concat(syllable_fr.ConvertAll(item => item.ToUpper())).Concat(numeric).ToList();
                booleanType = false;
            }
            else if (charsetName == "mixsyllable-numeric-space")
            {
                // mixsyllable-numeric-space
                charsetSelecting = syllable_fr.Concat(syllable_fr.ConvertAll(item => item.ToUpper())).Concat(numeric).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "mixsyllable-numeric-symbol14")
            {
                //mixsyllable-numeric-symbol14
                charsetSelecting = syllable_fr.Concat(syllable_fr.ConvertAll(item => item.ToUpper())).Concat(numeric).Concat(symbols14).ToList();
                booleanType = false;
            }
            else if (charsetName == "mixsyllable-numeric-symbol14-space")
            {

                // mixsyllable-numeric-symbol14-space
                charsetSelecting = syllable_fr.Concat(syllable_fr.ConvertAll(item => item.ToUpper())).Concat(numeric).Concat(symbols14).Concat(space).ToList();
                booleanType = false;
            }
            else if (charsetName == "mixsyllable-numeric-all")
            {
                //mixsyllable-numeric-all
                charsetSelecting = syllable_fr.Concat(syllable_fr.ConvertAll(item => item.ToUpper())).Concat(numeric).Concat(symbols14).Concat(symbols_all).ToList();
                booleanType = false;
            }
            else if (charsetName == "mixsyllable-numeric-all-space")
            {
                //mixsyllable-numeric-all-space
                charsetSelecting = syllable_fr.Concat(syllable_fr.ConvertAll(item => item.ToUpper())).Concat(numeric).Concat(symbols14).Concat(symbols_all).Concat(space).ToList();
                booleanType = false;
            }
            else
            {
                booleanType = true;
            }
            
            return charsetSelecting;
        }

    } // End Class
} // End name space
