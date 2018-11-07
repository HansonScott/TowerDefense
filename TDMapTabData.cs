using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    public class TDMapTabData
    {
        public enum TDMapTabTypes
        {
            Template,
            Data,
            Path
        }

        public string Name;
        public int Level;
        public TDMapTabTypes Type = TDMapTabTypes.Path;
        public DataTable Table;

        public TDMapTabData(string tableName, int level, TDMapTabTypes Type, DataTable Table)
        {
            this.Name = tableName;
            this.Level = level;
            this.Table = Table;
            this.Type = Type;
        }

        public class ColumnNames
        {
            public const int Name = 0;
            public const int BackColor = 1;
            public const int BackImage = 2;
            public const int PathColor = 3;
            public const int PathImage = 4;
            public const int BaseColor = 5;
            public const int BaseImage = 6;
        }
    }
}
