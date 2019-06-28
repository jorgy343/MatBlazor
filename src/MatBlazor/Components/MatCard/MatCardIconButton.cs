namespace MatBlazor.Components.MatCard
{
    public class MatCardIconButton : MatIconButton
    {
        public MatCardIconButton()
        {
            ClassMapper
                .Add("mdc-card__action")
                .Add("mdc-card__action--icon");
        }
    }
}