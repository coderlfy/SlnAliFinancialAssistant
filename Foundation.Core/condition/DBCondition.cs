using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foundation.Core
{
    public class DBCondition
    {
        private const string conditionInitFormat 
            = " ({0} {1} '{2}') {3} ";
        private const string conditionLeftLikeFormat
            = " ({0} {1} '%{2}') {3} ";
        private const string conditionRightLikeFormat
            = " ({0} {1} '{2}%') {3} ";
        private const string conditionBothLikeFormat
            = " ({0} {1} '%{2}%') {3} ";
        private const string conditionEmptyIsNullFormat 
            = " ({0} is null) {1} ";
        private const string conditionIsNotNullFormat 
            = " ({0} is not null) {1} ";
        private const string conditionInValuesFormat 
            = " ({0} in ({1})) {2} ";

        private string _alisaOfTable;

        public string _AlisaOfTable
        {
            get { return _alisaOfTable; }
            set { _alisaOfTable = value; }
        }
        
        private string _paramsName;

        public string _ParamsName
        {
            get { return _paramsName; }
            set { _paramsName = value; }
        }

        private string _fieldName;

        public string _FieldName
        {
            get { return _fieldName; }
            set { _fieldName = value; }
        }

        private object _paramValue;

        public object _ParamValue
        {
            get { return _paramValue; }
            set { _paramValue = value; }
        }

        private EnumCondition _enumCondition;

        public EnumCondition _EnumCondition
        {
            get { return _enumCondition; }
            set { _enumCondition = value; }
        }

        private EnumConditionsRelation _conditionsRelation;

        public EnumConditionsRelation _ConditionsRelation
        {
            get { return _conditionsRelation; }
            set { _conditionsRelation = value; }
        }

        private EnumSqlType _fieldType;

        public EnumSqlType _FieldType
        {
            get { return _fieldType; }
            set { _fieldType = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conditionType"></param>
        /// <param name="fieldName"></param>
        /// <param name="paramValue"></param>
        /// <param name="fieldtype"></param>
        /// <param name="conditionsRelation"></param>
        /// <param name="aliasOfTable"></param>
        /// <returns></returns>
        public string ToString(
            EnumCondition conditionType,
    object fieldName, object paramValue, 
            EnumSqlType fieldtype,
    EnumConditionsRelation conditionsRelation, 
            string aliasOfTable)
        {
            #region
            string condition = "";
            string relation = (conditionsRelation == EnumConditionsRelation.And) ? "and" : "or";
            string fieldnamewithalias = string.IsNullOrEmpty(aliasOfTable)
                ? string.Format("[{0}]", fieldName)
                : string.Format("{0}.[{1}]", aliasOfTable, fieldName);
            switch (conditionType)
            {
                case EnumCondition.IsNotNull:
                    condition += String.Format(conditionIsNotNullFormat,
                        fieldnamewithalias, relation);
                    break;
                case EnumCondition.EmptyIsNull:
                    condition += String.Format(conditionEmptyIsNullFormat,
                        fieldnamewithalias, relation);
                    break;
                case EnumCondition.Equal:
                    this.checkParam(paramValue, delegate{
                        if (fieldtype == EnumSqlType.bit)
                            paramValue = Convert.ToBoolean(paramValue) ? "1" : "0";
                        condition += String.Format(conditionInitFormat,
                            fieldnamewithalias, "=", paramValue, relation);
                    });
                    break;
                case EnumCondition.LikeBoth:
                    this.checkParam(paramValue, delegate{
                        condition += String.Format(conditionBothLikeFormat,
                            fieldnamewithalias, "like", paramValue, relation);
                    });
                    break;
                case EnumCondition.LikeLeft:
                    this.checkParam(paramValue, delegate
                    {
                        condition += String.Format(conditionLeftLikeFormat,
                            fieldnamewithalias, "like", paramValue, relation);
                    });
                    break;
                case EnumCondition.LikeRight:
                    this.checkParam(paramValue, delegate
                    {
                        condition += String.Format(conditionRightLikeFormat,
                            fieldnamewithalias, "like", paramValue, relation);
                    });
                    break;
                case EnumCondition.Greater:
                    this.checkParam(paramValue, delegate
                    {
                        condition += String.Format(conditionInitFormat,
                            fieldnamewithalias, ">", paramValue, relation);
                    });
                    break;
                case EnumCondition.GreaterOrEqual:
                    this.checkParam(paramValue, delegate
                    {
                        condition += String.Format(conditionInitFormat,
                            fieldnamewithalias, ">=", paramValue, relation);
                    });
                    break;
                case EnumCondition.LessOrEqual:
                    this.checkParam(paramValue, delegate
                    {
                        condition += String.Format(conditionInitFormat,
                            fieldnamewithalias, "<=", paramValue, relation);
                    });
                    break;
                case EnumCondition.Less:
                    this.checkParam(paramValue, delegate
                    {
                        condition += String.Format(conditionInitFormat,
                            fieldnamewithalias, "<", paramValue, relation);
                    });
                    break;
                case EnumCondition.InValues:
                    this.checkParam(paramValue, delegate
                    {
                        condition += String.Format(conditionInValuesFormat,
                            fieldnamewithalias, paramValue, relation);
                    });
                    break;
                default:
                    break;
            }
            return condition;
            #endregion
        }
        public delegate void CombinationCondition();
        private void checkParam(
            object paramValue, CombinationCondition fn)
        {
            #region
            if (paramValue !=null)
                if(!string.IsNullOrEmpty(paramValue.ToString()))
                    if(fn!=null)
                        fn();
            #endregion
        }
    }
}
 