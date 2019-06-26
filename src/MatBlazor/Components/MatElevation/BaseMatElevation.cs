using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Cards contain content and actions about a single subject.
    /// </summary>
    public class BaseMatElevation : BaseMatDomComponent
    {
        private int _elevation;

        public BaseMatElevation()
        {
            ClassMapper
                .Add($"mdc-elevation-{Elevation}");
        }

        /// <summary>
        /// Defines the level of elevation. The higher the number the higher the element will appear. This must
        /// be a value between 1 and 24 inclusive.
        /// </summary>
        [Parameter]
        protected int Elevation
        {
            get => _elevation;
            set
            {
                _elevation = value;
                ClassMapper.MakeDirty();
            }
        }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }
    }
}