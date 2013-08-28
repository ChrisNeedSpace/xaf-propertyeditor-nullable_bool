using System;
using System.Reflection;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Utils;
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
                if (Editor is ASPxCheckBox)
                    ((ASPxCheckBox)Editor).AllowGrayed = true;
                else if (Editor is ASPxComboBox)
                    ((ASPxComboBox)Editor).Items.Insert(0, new ListEditItem(CaptionHelper.NullValueText, null));
            }
            return control;
        }

        protected override object GetControlValueCore()
        {
            bool isComboBoxUsed = (IsDefinedBoolCaption || IsDefinedBoolImages);
            return isComboBoxUsed ? (object)ToBool(((ASPxComboBox)Editor).SelectedIndex) : (object)ToBool(((ASPxCheckBox)Editor).CheckState);
        }

        protected override void ReadEditModeValueCore()
        {
            base.ReadEditModeValueCore();
            
            bool? value = PropertyValue as bool?;
            if (IsDefinedBoolImages || IsDefinedBoolCaption)
            {
                if (IsNullable)
                    ((ASPxComboBox)Editor).SelectedIndex = !value.HasValue ? 0 : (value.Value ? 2 : 1);
                else if (PropertyValue != null)
                    ((ASPxComboBox)Editor).SelectedIndex = value.Value ? 1 : 0;
            }
            else if (PropertyValue != null)
                ((ASPxCheckBox)Editor).Checked = value.Value;
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
		
		private bool? ToBool(int selectedIndex)
        {
            bool isNullable = IsNullable;
            if (!isNullable)
            {
                return selectedIndex == 1;
            }
            else
            {
                if (selectedIndex <= 0)
                    return null;
                return selectedIndex == 2;
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