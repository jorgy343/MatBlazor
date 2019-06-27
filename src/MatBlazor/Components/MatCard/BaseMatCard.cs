using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Cards contain content and actions about a single subject.
    /// </summary>
    public class BaseMatCard : BaseMatDomComponent
    {
        public BaseMatCard()
        {
            ClassMapper
                .Add("mdc-card")
                .If("mdc-card--outlined", () => Outlined);
        }

        [Parameter]
        public bool Outlined { get; set; }

        [Parameter]
        public bool PrimaryAction { get; set; }

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        [Parameter]
        protected RenderFragment ActionButtons { get; set; }

        [Parameter]
        protected RenderFragment ActionIcons { get; set; }

        [Parameter]
        public EventCallback<UIMouseEventArgs> PrimaryActionOnClick { get; set; }
    }
}