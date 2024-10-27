using DevExpress.XtraEditors.DXErrorProvider;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VSTS.DESKTOP.Utils
{
    public static class MyValidationHelper
    {
        //Untuk ketika pakai wizzard next dan back tidak kena validasi
        public static void ClearError(DXValidationProvider fDxValidationProvider)
        {
            IList<Control> invalidControls = fDxValidationProvider.GetInvalidControls();
            for (int i = invalidControls.Count - 1; i >= 0; i--)
            {
                ConditionValidationRule conditionValidationRule = new ConditionValidationRule();
                fDxValidationProvider.SetValidationRule(invalidControls[i], conditionValidationRule);
                fDxValidationProvider.RemoveControlError(invalidControls[i]);
            }
        }

        public static void SetValidationClear(DXValidationProvider fDxValidationProvider, Control fControl)
        {
            ConditionValidationRule conditionValidationRule = new ConditionValidationRule();
            fDxValidationProvider.SetValidationRule(fControl, conditionValidationRule);
            fDxValidationProvider.RemoveControlError(fControl);
        }

        public static void SetValidation(DXValidationProvider fDxValidationProvider, Control fControl, ConditionOperator fConditionOperator = ConditionOperator.IsNotBlank, string fErrorText = "", object value1 = null, object value2 = null, ErrorType fErorrType = ErrorType.Critical)
        {
            ConditionValidationRule conditionValidationRule = new ConditionValidationRule();
            conditionValidationRule.ConditionOperator = fConditionOperator;
            conditionValidationRule.Value1 = value1;
            conditionValidationRule.Value2 = value2;

            if (fErrorText.Trim() == "")
            {
                switch (fConditionOperator)
                {
                    case ConditionOperator.None:
                        break;
                    case ConditionOperator.Equals:
                        break;
                    case ConditionOperator.NotEquals:
                        break;
                    case ConditionOperator.Between:
                        break;
                    case ConditionOperator.NotBetween:
                        break;
                    case ConditionOperator.Less:
                        fErrorText = "Inputan Kurang dari  = " + value1 + " Karakter";
                        break;
                    case ConditionOperator.Greater:
                        fErrorText = "Inputan Lebih dari  = " + value1 + " Karakter";
                        break;
                    case ConditionOperator.GreaterOrEqual:
                        fErrorText = "Inputan Lebih dari  = " + value1 + " Karakter";
                        break;
                    case ConditionOperator.LessOrEqual:
                        fErrorText = "Inputan Kurang dari  = " + value1 + " Karakter";
                        break;
                    case ConditionOperator.BeginsWith:
                        break;
                    case ConditionOperator.EndsWith:
                        break;
                    case ConditionOperator.Contains:
                        break;
                    case ConditionOperator.NotContains:
                        break;
                    case ConditionOperator.Like:
                        break;
                    case ConditionOperator.NotLike:
                        break;
                    case ConditionOperator.IsBlank:
                        break;
                    case ConditionOperator.IsNotBlank:
                        fErrorText = "Inputan tidak boleh kosong ...";
                        break;
                    case ConditionOperator.AnyOf:
                        break;
                    case ConditionOperator.NotAnyOf:
                        break;
                    default:
                        break;
                }
            }

            conditionValidationRule.ErrorText = fErrorText;
            conditionValidationRule.ErrorType = fErorrType;
            fDxValidationProvider.SetValidationRule(fControl, conditionValidationRule);
        }
    }
}
