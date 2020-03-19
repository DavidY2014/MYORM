using System;
using System.Collections.Generic;
using System.Text;

namespace MYORM.Framwork.Validate
{
    public static class DataValidateExtend
    {
        public static bool ValidateModel<T>(this T t)
        {
            Type type = typeof(T);
            foreach(var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(MYRequiredAttribute),true))
                {
                    object oValue = prop.GetValue(t);
                    if (oValue == null || string.IsNullOrEmpty(oValue.ToString()))
                    {
                        return false;
                    }
                }
            }
            return true;

        }

    }
}
