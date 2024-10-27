using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VSudoTrans.DESKTOP.Utils
{
    public static class AssemblyHelper
    {
        public static object GetValueProperty(object objectToGet, string propName)
        {
            object result = "";
            if (objectToGet != null)
            {
                var prop = objectToGet.GetType().GetProperty(propName);
                if (prop != null)
                {
                    result = prop.GetValue(objectToGet);
                }
            }

            return result;
        }

        public static void SetValueProperty(object objectToSet, string propName, object propValue)
        {
            if (objectToSet != null)
            {
                var prop = objectToSet.GetType().GetProperty(propName);
                if (prop != null)
                {
                    prop.SetValue(objectToSet, propValue);
                }
            }
        }

        public static object InvokeMethod(object ObjectToInvoke, string methodName, object[] parameters)
        {
            object result = null;

            if (ObjectToInvoke != null)
            {
                var method = ObjectToInvoke.GetType().GetMethod(methodName);
                result = method.Invoke(ObjectToInvoke, parameters);
            }

            return result;
        }

        public static IEnumerable<T> GetControlsOfType<T>(Control root) where T : Control
        {
            var t = root as T;
            if (t != null)
                yield return t;

            var container = root as ContainerControl;
            if (container != null)
                foreach (Control c in container.Controls)
                    foreach (var i in GetControlsOfType<T>(c))
                        yield return i;
        }

        public static Control GetControlByDataBinding(Control.ControlCollection controls, string key)
        {
            return
                controls
                .Cast<Control>()
                .FirstOrDefault(control =>
                    control.DataBindings
                    .Cast<Binding>()
                    .Any(binding => binding.BindingMemberInfo.BindingField == key));
        }
    }
}
