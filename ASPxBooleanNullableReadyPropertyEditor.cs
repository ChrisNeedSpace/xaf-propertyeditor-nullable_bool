using System;
using System.Reflection;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web.ASPxEditors;

namespace SampleProject.Module.Web.Infrastructure
{
    [PropertyEditor(typeof(bool), true)]
    public class ASPxBooleanNullableReadyPropertyEditor : ASPxBooleanPropertyEditor
    {
        public ASPxBooleanNullableReadyPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)  { }

        protected override object CreateControlCore()
        {
            var control = base.CreateControlCore();
            if (IsNullable)
            {
                var checkbox = Editor as ASPxCheckBox;
                if (checkbox != null)
                    checkbox.AllowGrayed = true;
            }
            return control;
        }

        protected override object GetControlValueCore()
        {
            bool isComboBoxUsed = (IsDefinedBoolCaption || IsDefinedBoolImages);
            return isComboBoxUsed ? (((ASPxComboBox)Editor).SelectedIndex == 1) : (object)ToBool(((ASPxCheckBox)Editor).CheckState);
        }

        private bool IsNullable
        {
            get 
            {
                Type objType = ObjectType;
                foreach (var propertyName in PropertyName.Split('.'))
                {
                    PropertyInfo prop = objType.GetProperty(propertyName);
                    if (prop == null)
                        return false;
                    objType = prop.PropertyType;
                }
                return objType == typeof(bool?);
            }
        }

        private bool? ToBool(DevExpress.Web.ASPxClasses.CheckState checkState)
        {
            switch (checkState)
            {
                case DevExpress.Web.ASPxClasses.CheckState.Checked: return true;
                case DevExpress.Web.ASPxClasses.CheckState.Unchecked: return false;
                case DevExpress.Web.ASPxClasses.CheckState.Indeterminate:
                default: return null;
            }
        }
		
		///// <summary>
        ///// In case of not resetting a value with ImmediatePostData
        ///// </summary>
        //protected override void ReadEditModeValueCore()
        //{
        //    base.ReadEditModeValueCore();
        //    if (PropertyValue == null)
        //    {
        //        var checkbox = Editor as ASPxCheckBox;
        //        if (checkbox != null)
        //            checkbox.CheckState = DevExpress.Web.ASPxClasses.CheckState.Indeterminate;
        //    }
        //}
    }
}
