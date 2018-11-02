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
            public const string Name = "Name";
            public const string BackColor = "BackColor";
            public const string BackImage = "BackImage";
            public const string PathColor = "PathColor";
            public const string PathImage = "PathImage";
            public const string BaseColor = "BaseColor";
            public const string BaseImage = "BaseImage";
        }
    }
}
