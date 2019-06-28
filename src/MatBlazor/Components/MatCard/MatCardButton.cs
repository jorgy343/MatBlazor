namespace MatBlazor
{
    public class MatCardButton : MatButton
    {
        public MatCardButton()
        {
            ClassMapper
                .Add("mdc-card__action")
                .Add("mdc-card__action--button");
        }
    }
}