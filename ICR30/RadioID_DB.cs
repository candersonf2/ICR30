using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using System.IO;
using System.Text.RegularExpressions;

namespace ICR30
{
    class RadioID_DB
    {
        // Storage for the Radio and Group Entries
        public ConcurrentDictionary<string, t_GroupID> P25Groups;
        public ConcurrentDictionary<string, t_RadioID> P25Radios;

        // Structures for each entry. We don't use everything, yet.

        public RadioID_DB()
        {
            // Constructor... create empty groups.
            P25Groups = new ConcurrentDictionary<string, t_GroupID>();
            P25Radios = new ConcurrentDictionary<string, t_RadioID>();
        }
        public struct t_GroupID
        {
            public string Protocol;
            public string NetworkID;
            public string Group;
            public int Priority;
            public string Override;
            public int Hits;
            public string Timestamp;
            public string GroupAlias;
        }
        public struct t_RadioID
        {
            public string Protocol;
            public string NetworkID;
            public string Group;
            public string Radio;
            public int Priority;
            public string Override;
            public int Hits;
            public string Timestamp;
            public string RadioAlias;
        }
        public bool LoadP25Groups(string grpFilename)
        {
            // Loader for P25 Group IDs
            FileStream fGroups;
            if (File.Exists(grpFilename))
            {
                try
                {
                    fGroups = File.Open(grpFilename, FileMode.Open);
                }
                catch(Exception e)
                {
                    return false;
                }
                StreamReader sr = new StreamReader(fGroups, Encoding.UTF8, true, 512);
                string gLine;
                P25Groups = new ConcurrentDictionary<string, t_GroupID>();
                while((gLine = sr.ReadLine()) != null)
                {
                    // This regex shamelessly "appropriated" from StackOverflow user https://stackoverflow.com/users/1670729/mana
                    // Provided as an answer to this post: https://stackoverflow.com/questions/3507498/reading-csv-files-using-c-sharp
                    // As an alternative to including any libraries. This may get replaced later.
                    Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    string[] gFields = CSVParser.Split(gLine);
                    if(gFields.Length > 7 )
                    {
                        if (gFields[0].ToUpper() == "P25")
                        {
                            t_GroupID tmpGrp = new t_GroupID();
                            tmpGrp.Protocol = "P25";
                            tmpGrp.NetworkID = gFields[1].Trim();
                            tmpGrp.Group = gFields[2].Trim();
                            tmpGrp.Priority = Convert.ToInt32(gFields[3]);
                            tmpGrp.Override = gFields[4].Trim();
                            tmpGrp.Hits = Convert.ToInt32(gFields[5]);
                            tmpGrp.Timestamp = gFields[6].Trim();
                            tmpGrp.GroupAlias = gFields[7].Trim().Replace("\"", "");
                            string NAC;
                            if (tmpGrp.NetworkID.IndexOf(".") > -1)
                            {
                                NAC = tmpGrp.NetworkID.Substring(tmpGrp.NetworkID.IndexOf(".") + 1);
                            }
                            else
                            {
                                NAC = tmpGrp.NetworkID;
                            }
                            P25Groups.TryAdd(NAC + "." + tmpGrp.Group, tmpGrp);
                         }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LoadP25Radios(string ridFilename)
        {
            // Loader for P25 Radio IDs
            FileStream fRadios;
            if (File.Exists(ridFilename))
            {
                try
                {
                    fRadios = File.Open(ridFilename, FileMode.Open);
                }
                catch (Exception e)
                {
                    return false;
                }
                StreamReader sr = new StreamReader(fRadios, Encoding.UTF8, true, 512);
                string rLine;
                P25Radios = new ConcurrentDictionary<string, t_RadioID>();
                while ((rLine = sr.ReadLine()) != null)
                {
                    // This regex shamelessly "appropriated" from StackOverflow user https://stackoverflow.com/users/1670729/mana
                    // Provided as an answer to this post: https://stackoverflow.com/questions/3507498/reading-csv-files-using-c-sharp
                    // As an alternative to including any libraries. This may get replaced later.
                    Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    string[] rFields = CSVParser.Split(rLine);
                    if (rFields.Length > 8)
                    {
                        if (rFields[0].ToUpper().Trim() == "P25")
                        {
                            t_RadioID tmpRadio = new t_RadioID();
                            tmpRadio.Protocol = "P25";
                            tmpRadio.NetworkID = rFields[1].Trim();
                            tmpRadio.Group = rFields[2].Trim();
                            tmpRadio.Radio = rFields[3].Trim();
                            tmpRadio.Priority = Convert.ToInt32(rFields[4]);
                            tmpRadio.Override = rFields[5].Trim();
                            tmpRadio.Hits = Convert.ToInt32(rFields[6]);
                            tmpRadio.Timestamp = rFields[7].Trim();
                            tmpRadio.RadioAlias = rFields[8].Trim().Replace("\"", "");
                            string NAC;
                            if (tmpRadio.NetworkID.IndexOf(".") > -1)
                            {
                                NAC = tmpRadio.NetworkID.Substring(tmpRadio.NetworkID.IndexOf(".") + 1);
                            }
                            else
                            {
                                NAC = tmpRadio.NetworkID;
                            }
                            P25Radios.TryAdd(NAC + "." + tmpRadio.Radio, tmpRadio);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }


        }
        public string GetP25GroupName(string NAC, string GroupID)
        {
            // Retreives the Group Name for a Given NAC/Group ID
            if (P25Groups.ContainsKey(NAC + "." + GroupID))
            {
                return P25Groups[NAC + "." + GroupID].GroupAlias;
            }
            return "";
        }
        public string GetP25RadioName(string NAC, string RadioID)
        {
            // Retreives the Radio Name for a Given NAC/Radio ID
            if (P25Radios.ContainsKey(NAC + "." + RadioID))
            {
                return P25Radios[NAC + "." + RadioID].RadioAlias;
            }
            return "";
        }
    }
}
