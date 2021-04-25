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
    public partial class MyDxDataGridIntComboBoxColumn : DxDataGridComboBoxColumn<int>
    {
        [Parameter]
        public int IntialFilter { get; set; } = 0;

        private void SetInitFilter()
        {
            var c = new ValueFilter(Field, IntialFilter, ComparisonOperator.Equal);
            var s = FilterService;
            s.SetFilter(Field, c);
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
    }
}
