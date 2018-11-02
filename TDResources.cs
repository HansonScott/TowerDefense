using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense
{
    class TDResources
    {
        public static TDMap[] Maps;
        public static List<TDAttacker> Attackers;

        public static void LoadResources()
        {
            Maps = LoadMaps();
            Attackers = LoadAttackers();
        }

        #region Map Loading
        private static TDMap[] LoadMaps()
        {
            DataSet data;
            try
            {
                ClaimRemedi.ExcelReader.Reader r = new ClaimRemedi.ExcelReader.Reader("Maps.xls");
                //r.FirstLineIsHeader = true;
                data = r.ReadAllData();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Cannot read Maps.xls");
                return null;
            }

            int maxLevel = 0;
            List<TDMapTabData> MapDataTabs = new List<TDMapTabData>();
            #region Determine the count of levels in the file and store the tabs
            string tableName;
            string Level;
            int lvl;
            // based on the tab name, each tab represents different things.
            foreach(DataTable t in data.Tables)
            {
                tableName = t.TableName.Replace("'", ""); // remove the quotes
                tableName = tableName.Replace("$", ""); // remove the $ sign

                if (tableName.ToLower().Contains("template"))
                {
                    continue;
                }

                // get just the level
                Level = tableName.Substring(0, 2);
                if (!Int32.TryParse(Level, out lvl)) 
                { 
                    // if we can't parse the level, then there's no point in keeping it
                    continue; 
                }

                TowerDefense.TDMapTabData.TDMapTabTypes type = TDMapTabData.TDMapTabTypes.Path;
                // check for a level's data tab
                if (tableName.ToLower().Contains("data"))
                {
                    type = TDMapTabData.TDMapTabTypes.Data;
                }

                // store the data we have into a list.
                MapDataTabs.Add(new TDMapTabData(tableName, lvl, type, t));
                
                // set the max level for later use
                maxLevel = Math.Max(maxLevel, lvl);
            } // end first lap
            #endregion

            TDMap[] results = new TDMap[maxLevel];

            foreach (TDMapTabData tab in MapDataTabs)
            {
                // make sure we have this level in our output collection
                if (results[tab.Level - 1] == null)
                {
                    results[tab.Level - 1] = new TDMap(tab.Level, new List<TDPath>());
                }

                switch (tab.Type)
                {
                    case TDMapTabData.TDMapTabTypes.Data:
                        results[tab.Level - 1].LoadMapData(tab);
                        break;
                    case TDMapTabData.TDMapTabTypes.Path:
                        results[tab.Level - 1].Paths.Add(LoadPathFromDataTable(tab.Table));
                        break;
                }
            }
            return results;
        }

        private static TDPath LoadPathFromDataTable(DataTable t)
        {
            TDPath p = new TDPath();

            for (int x = 1; x <= t.Columns.Count; x++)
            {
                for (int y = 2; y <= t.Rows.Count; y++) // start at 2 because of the 'name' row
                {
                    string val = t.Rows[y - 1][x - 1].ToString().ToLower();

                    if (!String.IsNullOrEmpty(val))
                    {
                        p.PathPoints.Add(new TDPathPoint(Int32.Parse(val), x * TDMap.GridSize, y * TDMap.GridSize));
                    }
                }
            }
            p.PathPoints.Sort();
            return p;
        }
        #endregion

        #region Attackers loading
        private static List<TDAttacker> LoadAttackers()
        {
            ClaimRemedi.ExcelReader.Reader r = new ClaimRemedi.ExcelReader.Reader("Attackers.xls");
            r.FirstLineIsHeader = true;
            DataSet data = r.ReadAllData();

            foreach (DataTable t in data.Tables)
            {
                switch (t.TableName)
                {
                    case "Attackers$":
                        return LoadAttackersTable(t);
                    default:
                        break;
                }
            }

            // if we get here, then it didn't find the attackers tab
            return null;
        }
        private static List<TDAttacker> LoadAttackersTable(DataTable t)
        {
            List<TDAttacker> results = new List<TDAttacker>();

            foreach (DataRow r in t.Rows)
            {
                int ID = Int32.Parse(r["ID"].ToString());
                string Name = r["Name"].ToString();
                int HP = Int32.Parse(r["HP%"].ToString());
                int Speed = Int32.Parse(r["Speed%"].ToString());
                int Damage = Int32.Parse(r["Damage%"].ToString());
                int Range = Int32.Parse(r["Range%"].ToString());
                int FireSpeed = Int32.Parse(r["FireSpeed%"].ToString());
                string ImageName = r["Image"].ToString();

                TDAttacker a = new TDAttacker(Name, HP, Speed, Damage, Range, 100 - FireSpeed);

                ImageName = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Images" + Path.DirectorySeparatorChar + ImageName;
                a.MainImage = Image.FromFile(ImageName);

                results.Add(a);
            }

            return results;
        }
        #endregion
    }
}
