using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Blazor;
using DevExpress.Blazor.Internal;
using DevExpress.Blazor.Internal.Grid;
using FootballScores.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace FootballScores.Components
{
   
    internal class MyDxDataGridDateEditColumnFilterEditor : DxDateEdit<DateTime?>
    {
        
        public MyDxDataGridDateEditColumnFilterEditor()
        {
            base.AllowNullInternal = true;
            base.PickerDisplayMode = DatePickerDisplayMode.Auto;
            CustomDisabledDate = OnCustomDisabledDate;
        }

        void OnCustomDisabledDate(CalendarCustomDisabledDateEventArgs args)
        {
            if (EnableDates != null && EnableDates.Count() > 0)
            {
                if (EnableDates.Find((s) => s.Value.Day == args.Date.Day && s.Value.Month == args.Date.Month && s.Value.Year == args.Date.Year) != null)
                    args.IsDisabled = false;
                else
                    args.IsDisabled = true;
            }
            else
            {
                args.IsDisabled = false;
            }
        }

        [Parameter]
        public DateTime? NullableValue
        {
            get
            {
                return base.DateEditState.GetValue();
            }
            set
            {
                base.DateEditState.SetValue(value, true, false);
            }
        }

        [Parameter]
        public Action<DateTime?> NullableValueChanged
        {
            get;
            set;
        }

        protected override DataEditorClearButtonDisplayMode ClearButtonDisplayModeInternal
        {
            get
            {
                return DataEditorClearButtonDisplayMode.Auto;
            }
        }

        [Parameter]
        public List<DateTime?> EnableDates
        {
            get;
            set;
        }

        protected override void OnValueChangedInternal()
        {
            Action<DateTime?> nullValueChanged = NullableValueChanged;
            if (nullValueChanged != null)
            {
                nullValueChanged.Invoke(NullableValue);
            }
            base.OnValueChangedInternal();
        }
    }

    public partial class MyDxDateGridColumn : DxDataGridDateEditColumn 
    {
        [Parameter]
        public DateTime? IntialFilterDateTime { get; set; } = null;

        [Parameter]
        public IEnumerable<DateTime?> EnableDates { get; set; } = null;

        private void SetInitFilter()
        {
            if (IntialFilterDateTime != null)
            {
                var c = new DateDayFilter(Field, IntialFilterDateTime.Value);
                var s = FilterService;
                s.SetFilter(Field, c);
            }
        }

        protected override Task OnInitializedAsync()
        {
            SetInitFilter();
            return base.OnInitializedAsync();
        }

        protected override void OnInitialized()
        {
            SetInitFilter();
            base.OnInitialized();
        }

        internal object GetFilterValue()
        {
            return FilterService.GetFilterEditorValue(Field);
        }

        internal void OnFilterChanged(DateTime? value)
        {
            FilterService.SetFilter(Field, this.CreateFilterStateCore(value));
        }

        protected override int RenderFilterEditor(int sequenceOffset, RenderTreeBuilder builder)
        {
            builder.OpenComponent<MyDxDataGridDateEditColumnFilterEditor>(sequenceOffset);

            builder.AddAttribute(sequenceOffset + 1, "NullableValue", GetFilterValue());
            builder.AddAttribute(sequenceOffset + 2, "Format", this.EditorFormat);
            builder.AddAttribute(sequenceOffset + 3, "DisplayFormat", this.EditorDisplayFormat);

            Action<DateTime?> nullValueChange = date => OnFilterChanged(date);
            builder.AddAttribute(sequenceOffset + 4, "NullableValueChanged", nullValueChange);
            builder.AddAttribute(sequenceOffset + 5, "EnableDates", this.EnableDates);
            builder.AddAttribute(sequenceOffset + 6, "ShowClearButton", false);
           
            builder.CloseComponent();
            return sequenceOffset + 6;
        }
    }
}
