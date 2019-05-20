﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SqlSugar
{
    public class PostgreSQLBuilder : SqlBuilderProvider
    {
        public override string SqlTranslationLeft
        {
            get
            {
                return "\"";
            }
        }
        public override string SqlTranslationRight
        {
            get
            {
                return "\"";
            }
        }
        public override string SqlDateNow
        {
            get
            {
                return "current_date";
            }
        }
        public override string FullSqlDateNow
        {
            get
            {
                return "select current_date";
            }
        }
        public override string GetTranslationColumnName(string propertyName)
        {
            if (propertyName.Contains(SqlTranslationLeft)) return propertyName;
            else
                return SqlTranslationLeft + propertyName.ToLower() + SqlTranslationRight;
        }

        //public override string GetNoTranslationColumnName(string name)
        //{
        //    return name.TrimEnd(Convert.ToChar(SqlTranslationRight)).TrimStart(Convert.ToChar(SqlTranslationLeft)).ToLower();
        //}
        public override string GetTranslationColumnName(string entityName, string propertyName)
        {
            Check.ArgumentNullException(entityName, string.Format(ErrorMessage.ObjNotExist, "Table Name"));
            Check.ArgumentNullException(propertyName, string.Format(ErrorMessage.ObjNotExist, "Column Name"));
            var context = this.Context;
            var mappingInfo = context
                 .MappingColumns
                 .FirstOrDefault(it =>
                 it.EntityName.Equals(entityName, StringComparison.CurrentCultureIgnoreCase) &&
                 it.PropertyName.Equals(propertyName, StringComparison.CurrentCultureIgnoreCase));
            return (mappingInfo == null ? SqlTranslationLeft + propertyName.ToLower() + SqlTranslationRight : SqlTranslationLeft + mappingInfo.DbColumnName.ToLower() + SqlTranslationRight);
        }

        public override string GetTranslationTableName(string name)
        {
            Check.ArgumentNullException(name, string.Format(ErrorMessage.ObjNotExist, "Table Name"));
            var context = this.Context;

            var mappingInfo = context
                .MappingTables
                .FirstOrDefault(it => it.EntityName.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            name = (mappingInfo == null ? name : mappingInfo.DbTableName);
            if (name.Contains("."))
            {
                return string.Join(".", name.ToLower().Split('.').Select(it => SqlTranslationLeft + it + SqlTranslationRight));
            }
            else if (name.Contains("("))
            {
                return name.ToLower();
            }
            else
            {
                return SqlTranslationLeft + name.ToLower() + SqlTranslationRight;
            }
        }
    }
}
